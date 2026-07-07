using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json;

namespace InteropGenerator.Runtime;

public sealed class Resolver {
    private static readonly Lazy<Resolver> Instance = new(() => new Resolver());

    public readonly HashSet<Address> Addresses = new();

    private nint _baseAddress;
    private bool _cacheChanged;
    private FileInfo? _cacheFile;

    private bool _isSetup;

    private ResolverCache? _resolverCache;
    private int _targetLength;

    private nint _targetSpace;

    private int _textSectionOffset;
    private int _textSectionSize;

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
            if (sectionName == 0x747865742E) { // .text
                _textSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                _textSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                break;
            }

            sectionCursor = sectionCursor[40..]; // advance by 40
        }
    }

    private void LoadCache(string version) {
        try {
            if (_cacheFile is { Exists: true }) {
                using var file = File.OpenRead(_cacheFile.FullName);
                _resolverCache = JsonSerializer.Deserialize(file, ResolverCacheSerializerContext.Default.ResolverCache);

                if (_resolverCache?.Version == version)
                    return;
            }
        } catch { }

        _resolverCache = new ResolverCache(version, new ConcurrentDictionary<string, long>());
    }

    private void SaveCache() {
        if (_cacheFile == null || _resolverCache == null || !_cacheChanged)
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
            if (address.Value == 0 && _resolverCache!.Cache.TryGetValue(address.CacheKey, out var offset))
                address.Value = (nint)(offset + _baseAddress);
        }
        return Addresses.All(a => a.Value != 0);
    }

    public unsafe void Resolve() {
        if (_targetSpace == 0)
            throw new Exception("[InteropGenerator.Runtime.Resolver] Attempted to call Resolve() without initializing the search space.");

        if (_resolverCache is not null && ResolveFromCache())
            return;

        var remainingAddresses = Addresses.Where(a => a.Value == 0);
        int remainingCount = remainingAddresses.Count();
        if (remainingCount == 0)
            return;

        var buckets = new Address[256][];
        foreach (var group in remainingAddresses.GroupBy(a => (byte)a.Bytes[0]))
            buckets[group.Key] = [.. group];

        var partitioner = Partitioner.Create(0, _textSectionSize, _textSectionSize / Environment.ProcessorCount);

        Parallel.ForEach(partitioner, (range, loopState) => {
            var textPtr = (byte*)_targetSpace + _textSectionOffset;

            for (int location = range.Item1; !loopState.IsStopped && location < range.Item2; location++) {
                var currentByte = textPtr[location];
                var bucket = buckets[currentByte];
                if (bucket is null)
                    continue;

                var targetLocationAsUlong = (ulong*)(textPtr + location);

                for (int i = 0; i < bucket.Length; i++) {
                    var address = bucket[i];
                    if (Volatile.Read(ref address.Value) != 0)
                        continue;

                    int count;
                    var length = address.Bytes.Length;

                    for (count = 0; count < length; count++) {
                        if ((address.Mask[count] & address.Bytes[count]) != (address.Mask[count] & targetLocationAsUlong[count]))
                            break;
                    }

                    if (count != length)
                        continue;

                    int outLocation = location;
                    foreach (ushort relOffset in address.RelativeFollowOffsets) {
                        int relativeOffset = *(int*)(textPtr + outLocation + relOffset);
                        outLocation = outLocation + relOffset + 4 + relativeOffset;
                    }

                    nint finalAddress = _baseAddress + _textSectionOffset + outLocation;

                    if (Interlocked.CompareExchange(ref address.Value, finalAddress, 0) == 0) {
                        if (_resolverCache?.Cache.TryAdd(address.CacheKey, outLocation + _textSectionOffset) == true)
                            _cacheChanged |= true;

                        if (Interlocked.Decrement(ref remainingCount) == 0) {
                            loopState.Stop();
                            return;
                        }
                    }
                }
            }
        });

        SaveCache();
    }

    public void RegisterAddress(Address address) {
        Addresses.Add(address);
    }

    public void UnregisterAddress(Address address) {
        Addresses.Remove(address);
    }
}
