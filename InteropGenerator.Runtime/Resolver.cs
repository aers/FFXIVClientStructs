using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace InteropGenerator.Runtime;

public sealed class Resolver {
    private static readonly Lazy<Resolver> Instance = new(() => new Resolver());

    public readonly HashSet<Address> Addresses = new();

    private readonly List<Address>?[] _preResolveArray = new List<Address>[256];

    private nint _baseAddress;
    private bool _cacheChanged;
    private FileInfo? _cacheFile;
    
    private bool _isSetup;

    private ResolverCache? _resolverCache;
    private int _targetLength;

    private nint _targetSpace;

    private int _textSectionOffset;
    private int _textSectionSize;
    private int _totalBuckets;

    private Resolver() {
    }

    public static Resolver GetInstance => Instance.Value;

    public void Setup(nint moduleCopyPointer = 0, string version = "", FileInfo? cacheFile = null) {
        if (_isSetup) return;
        var module = Process.GetCurrentProcess().MainModule;
        if (module == null)
            throw new Exception("[InteropGenerator.Runtime.Resolver] Unable to access process module.");

        Setup(module.BaseAddress, module.ModuleMemorySize, moduleCopyPointer, version, cacheFile);
    }

    public void Setup(nint modulePointer, int moduleSize, nint moduleCopyPointer = 0, string version = "", FileInfo? cacheFile = null) {
        _baseAddress = modulePointer;

        _targetSpace = moduleCopyPointer == 0 ? _baseAddress : moduleCopyPointer;
        _targetLength = moduleSize;

        _cacheFile = cacheFile;
        if (_cacheFile is not null)
            LoadCache(version);

        SetupSections();
        _isSetup = true;
    }

    public void Setup(nint memoryPointer, int memorySize, int textSectionOffset, int textSectionSize, string version = "", FileInfo? cacheFile = null) {
        if (_isSetup) return;
        _baseAddress = memoryPointer;
        _targetSpace = memoryPointer;
        _targetLength = memorySize;
        _textSectionOffset = textSectionOffset;
        _textSectionSize = textSectionSize;

        _cacheFile = cacheFile;
        if (_cacheFile is not null)
            LoadCache(version);
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
            if (sectionName == 0x747865742E) {
                // .text
                _textSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                _textSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
            }

            sectionCursor = sectionCursor[40..]; // advance by 40
        }
    }
    private void LoadCache(string version) {
        if (_cacheFile is not { Exists: true }) {
            _resolverCache = new ResolverCache(version, new ConcurrentDictionary<string, long>());
            return;
        }

        try {
            var json = File.ReadAllText(_cacheFile.FullName);
            _resolverCache = JsonSerializer.Deserialize(json, ResolverCacheSerializerContext.Default.ResolverCache);
            if (_resolverCache is null ||
                _resolverCache.Version != version)
                _resolverCache = new ResolverCache(version, new ConcurrentDictionary<string, long>());
        } catch {
            _resolverCache = new ResolverCache(version, new ConcurrentDictionary<string, long>());
        }
    }

    private void SaveCache() {
        if (_cacheFile == null || _resolverCache == null || _cacheChanged == false)
            return;
        var json = JsonSerializer.Serialize(_resolverCache, ResolverCacheSerializerContext.Default.ResolverCache);
        if (string.IsNullOrWhiteSpace(json))
            return;
        if (_cacheFile.Directory is { Exists: false })
            Directory.CreateDirectory(_cacheFile.Directory.FullName);
        File.WriteAllText(_cacheFile.FullName, json);
    }

    private bool ResolveFromCache() {
        foreach (var address in Addresses) {
            if (address.Value == 0) {
                if (_resolverCache!.Cache.TryGetValue(address.CacheKey, out var offset)) {
                    address.Value = (nuint)(offset + _baseAddress);
                    var firstByte = (byte)address.Bytes[0];
                    if (_preResolveArray[firstByte] != null) {
                        _preResolveArray[firstByte]!.Remove(address);
                        if (_preResolveArray[firstByte]!.Count == 0) {
                            _preResolveArray[firstByte] = null;
                            _totalBuckets--;
                        }
                    }
                }
            }
        }

        return Addresses.All(a => a.Value != 0);
    }

    // This function is a bit messy, but everything to make it cleaner is slower, so don't bother.
    public unsafe void Resolve() {
        if (_targetSpace == 0)
            throw new Exception("[FFXIVClientStructs.Resolver] Attempted to call Resolve() without initializing the search space.");

        if (_resolverCache is not null) {
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

                        if (_resolverCache?.Cache.TryAdd(address.CacheKey, outLocation + _textSectionOffset) == true)
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
    }

    public void RegisterAddress(Address address) {
        if (Addresses.Add(address)) {
            var firstByte = (byte)address.Bytes[0];

            if (_preResolveArray[firstByte] is null) {
                _preResolveArray[firstByte] = new List<Address>();
                _totalBuckets++;
            }

            _preResolveArray[firstByte]!.Add(address);
        }
    }
    
    public void UnregisterAddress(Address address) {
        if (Addresses.Remove(address) &&
            address.Value != 0) {
            var firstByte = (byte)address.Bytes[0];

            if (_preResolveArray[firstByte] != null) {
                _preResolveArray[firstByte]!.Remove(address);
                if (_preResolveArray[firstByte]!.Count == 0) {
                    _preResolveArray[firstByte] = null;
                    _totalBuckets--;
                }
            }
        }
    }
}
