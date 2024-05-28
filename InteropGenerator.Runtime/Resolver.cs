using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InteropGenerator.Runtime;

public sealed partial class Resolver {
    private static readonly Lazy<Resolver> Instance = new(() => new Resolver());

    private readonly List<Address> _addresses = new();

    private readonly List<Address>?[] _preResolveArray = new List<Address>[256];

    private nint _baseAddress;
    private bool _cacheChanged;
    private FileInfo? _cacheFile;
    private int _dataSectionOffset;
    private int _dataSectionSize;

    private bool _hasResolved;
    private bool _isSetup;
    private int _rdataSectionOffset;
    private int _rdataSectionSize;
    private int _targetLength;

    private nint _targetSpace;

    private ConcurrentDictionary<string, long>? _textCache;

    private int _textSectionOffset;
    private int _textSectionSize;
    private int _totalBuckets;

    private Resolver() {
    }

    public static Resolver GetInstance => Instance.Value;
    public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

    public void SetupSearchSpace(nint moduleCopy = 0, FileInfo? cacheFile = null) {
        if (_isSetup) return;
        var module = Process.GetCurrentProcess().MainModule;
        if (module == null)
            throw new Exception("[FFXIVClientStructs.Resolver] Unable to access process module.");

        _baseAddress = module.BaseAddress;

        _targetSpace = moduleCopy == 0 ? _baseAddress : moduleCopy;
        _targetLength = module.ModuleMemorySize;

        _cacheFile = cacheFile;
        if (_cacheFile is not null)
            LoadCache();

        SetupSections();
        _isSetup = true;
    }

    public void SetupSearchSpace(nint memoryPointer, int memorySize, int textSectionOffset, int textSectionSize,
        int dataSectionOffset, int dataSectionSize, int rdataSectionOffset, int rdataSectionSize, FileInfo? cacheFile = null) {
        if (_isSetup) return;
        _baseAddress = memoryPointer;
        _targetSpace = memoryPointer;
        _targetLength = memorySize;
        _textSectionOffset = textSectionOffset;
        _textSectionSize = textSectionSize;
        _dataSectionOffset = dataSectionOffset;
        _dataSectionSize = dataSectionSize;
        _rdataSectionOffset = rdataSectionOffset;
        _rdataSectionSize = rdataSectionSize;

        _cacheFile = cacheFile;
        if (_cacheFile is not null)
            LoadCache();
        _isSetup = true;
    }

    // adapted from Dalamud SigScanner
    private unsafe void SetupSections() {
        ReadOnlySpan<byte> baseAddress = new(_baseAddress.ToPointer(), _targetLength);

        // We don't want to read all of IMAGE_DOS_HEADER or IMAGE_NT_HEADER stuff so we cheat here.
        var ntNewOffset = BitConverter.ToInt32(baseAddress.Slice(0x3C, 4));
        var ntHeader = baseAddress[ntNewOffset..];

        // IMAGE_NT_HEADER
        var fileHeader = ntHeader[4..];
        var numSections = BitConverter.ToInt16(ntHeader.Slice(6, 2));

        // IMAGE_OPTIONAL_HEADER
        var optionalHeader = fileHeader[20..];

        var sectionHeader = optionalHeader[240..]; // IMAGE_OPTIONAL_HEADER64

        // IMAGE_SECTION_HEADER
        var sectionCursor = sectionHeader;
        for (var i = 0; i < numSections; i++) {
            var sectionName = BitConverter.ToInt64(sectionCursor);

            // .text
            switch (sectionName) {
                case 0x747865742E: // .text
                    _textSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    _textSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
                case 0x617461642E: // .data
                    _dataSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    _dataSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
                case 0x61746164722E: // .rdata
                    _rdataSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    _rdataSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
            }

            sectionCursor = sectionCursor[40..]; // advance by 40
        }
    }
    private void LoadCache() {
        if (_cacheFile is not { Exists: true }) {
            _textCache = new ConcurrentDictionary<string, long>();
            return;
        }

        try {
            var json = File.ReadAllText(_cacheFile.FullName);
            _textCache = JsonSerializer.Deserialize(json, ResolverJsonContext.Default.ConcurrentDictionaryStringInt64) ?? new ConcurrentDictionary<string, long>();
        } catch {
            _textCache = new ConcurrentDictionary<string, long>();
        }
    }

    private void SaveCache() {
        if (_cacheFile == null || _textCache == null || _cacheChanged == false)
            return;
        var json = JsonSerializer.Serialize(_textCache, ResolverJsonContext.Default.ConcurrentDictionaryStringInt64);
        if (string.IsNullOrWhiteSpace(json))
            return;
        if (_cacheFile.Directory is { Exists: false })
            Directory.CreateDirectory(_cacheFile.Directory.FullName);
        File.WriteAllText(_cacheFile.FullName, json);
    }

    private bool ResolveFromCache() {
        foreach (var address in _addresses) {
            if (_textCache!.TryGetValue(address.CacheKey, out var offset)) {
                address.Value = (nuint)(offset + _baseAddress);
                var firstByte = (byte)address.Bytes[0];
                _preResolveArray[firstByte]!.Remove(address);
                if (_preResolveArray[firstByte]!.Count == 0) {
                    _preResolveArray[firstByte] = null;
                    _totalBuckets--;
                }
            }
        }

        return _addresses.All(a => a.Value != 0);
    }

    // This function is a bit messy, but everything to make it cleaner is slower, so don't bother.
    public unsafe void Resolve() {
        if (_hasResolved)
            return;

        if (_targetSpace == 0)
            throw new Exception("[FFXIVClientStructs.Resolver] Attempted to call Resolve() without initializing the search space.");

        if (_textCache is not null) {
            if (ResolveFromCache())
                return;
        }

        var targetSpan = new ReadOnlySpan<byte>(_targetSpace.ToPointer(), _targetLength)[_textSectionOffset..];

        for (var location = 0; location < _textSectionSize; location++) {
            if (_preResolveArray[targetSpan[location]] is not null) {
                var availableAddresses = _preResolveArray[targetSpan[location]]!.ToArray();

                var targetLocationAsUlong = MemoryMarshal.Cast<byte, ulong>(targetSpan[location..]);

                var avLen = availableAddresses.Length;

                for (var i = 0; i < avLen; i++) {
                    var address = availableAddresses[i];

                    int count;
                    var length = address.Bytes.Length;

                    for (count = 0; count < length; count++) {
                        if ((address.Mask[count] & address.Bytes[count]) != (address.Mask[count] & targetLocationAsUlong[count]))
                            break;
                    }

                    if (count == length) {
                        var outLocation = location;

                        foreach (var relOffset in address.RelativeFollowOffsets) {
                            var relativeOffset =
                                BitConverter.ToInt32(targetSpan.Slice(outLocation + relOffset, 4));
                            outLocation = outLocation + relOffset + 4 + relativeOffset;
                        }

                        address.Value = (nuint)(_baseAddress + _textSectionOffset + outLocation);

                        if (_textCache?.TryAdd(address.CacheKey, outLocation + _textSectionOffset) == true)
                            _cacheChanged = true;

                        _preResolveArray[targetSpan[location]]!.Remove(address);
                        if (_preResolveArray[targetSpan[location]]!.Count == 0) {
                            _preResolveArray[targetSpan[location]] = null;
                            _totalBuckets--;
                            if (_totalBuckets == 0)
                                goto outLoop;
                        }
                    }
                }
            }
        }
outLoop:;

        SaveCache();
        _hasResolved = true;
    }

    public void RegisterAddress(Address address) {
        _addresses.Add(address);

        var firstByte = (byte)address.Bytes[0];

        if (_preResolveArray[firstByte] is null) {
            _preResolveArray[firstByte] = new List<Address>();
            _totalBuckets++;
        }

        _preResolveArray[firstByte]!.Add(address);
    }

    [JsonSerializable(typeof(ConcurrentDictionary<string, long>))]
    [JsonSourceGenerationOptions(WriteIndented = true)]
    private partial class ResolverJsonContext : JsonSerializerContext {
    }
}
