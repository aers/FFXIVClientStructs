using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
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

        var remainingAddresses = Addresses.Where(a => a.Value == 0).ToArray();
        var remainingCount = remainingAddresses.Length;
        if (remainingCount == 0)
            return;

        var addressValues = (nint*)NativeMemory.AllocZeroed((nuint)remainingCount * (nuint)sizeof(nint));
        var buckets = new BucketAddressEntry*[256];
        var bucketData = new ulong*[256];
        var bucketLengths = new int[256]; // the amount of addresses in a bucket

        try {
            var grouped = remainingAddresses
                .Select((addr, idx) => new { Address = addr, GlobalIndex = idx })
                .GroupBy(item => (byte)item.Address.Bytes[0]);

            foreach (var group in grouped) {
                byte firstByte = group.Key;
                var addresses = group.ToArray();
                bucketLengths[firstByte] = addresses.Length;

                var ulongCount = addresses.Sum(x => x.Address.Bytes.Length) * 2;

                buckets[firstByte] = (BucketAddressEntry*)NativeMemory.Alloc((nuint)addresses.Length * (nuint)sizeof(BucketAddressEntry));
                bucketData[firstByte] = (ulong*)NativeMemory.Alloc((nuint)ulongCount * sizeof(ulong));

                var dataPtr = bucketData[firstByte];
                for (var i = 0; i < addresses.Length; i++) {
                    var address = addresses[i];
                    var bytesLen = address.Address.Bytes.Length;

                    buckets[firstByte][i] = new BucketAddressEntry {
                        ValuePtr = &addressValues[address.GlobalIndex],
                        BytesPtr = dataPtr,
                        MaskPtr = dataPtr + bytesLen,
                        BytesLen = bytesLen,
                        AddressIndex = address.GlobalIndex
                    };

                    fixed (ulong* pSrcBytes = address.Address.Bytes)
                    fixed (ulong* pSrcMask = address.Address.Mask) {
                        Buffer.MemoryCopy(pSrcBytes, dataPtr, bytesLen * sizeof(ulong), bytesLen * sizeof(ulong));
                        Buffer.MemoryCopy(pSrcMask, dataPtr + bytesLen, bytesLen * sizeof(ulong), bytesLen * sizeof(ulong));
                    }

                    dataPtr += bytesLen * 2;
                }
            }

            var partitioner = Partitioner.Create(0, _textSectionSize, _textSectionSize / Environment.ProcessorCount);
            var textPtr = (byte*)_targetSpace + _textSectionOffset;

            Parallel.ForEach(partitioner, (range, loopState) => {
                for (var location = range.Item1; !loopState.IsStopped && location < range.Item2; location++) {
                    var currentByte = textPtr[location];
                    var bucket = buckets[currentByte];
                    if (bucket == null)
                        continue;

                    var bucketLength = bucketLengths[currentByte];
                    if (bucketLength == 0)
                        continue;

                    var targetLocationAsUlong = (ulong*)(textPtr + location);

                    for (var i = 0; i < bucketLength; i++) {
                        ref readonly var target = ref bucket[i];
                        if (*target.ValuePtr != 0)
                            continue;

                        int count;
                        for (count = 0; count < target.BytesLen; count++) {
                            if ((target.MaskPtr[count] & target.BytesPtr[count]) != (target.MaskPtr[count] & targetLocationAsUlong[count]))
                                break;
                        }

                        if (count != target.BytesLen)
                            continue;

                        var outLocation = location;
                        var originalAddress = remainingAddresses[target.AddressIndex];
                        foreach (var relOffset in originalAddress.RelativeFollowOffsets) {
                            var relativeOffset = *(int*)(textPtr + outLocation + relOffset);
                            outLocation = outLocation + relOffset + 4 + relativeOffset;
                        }

                        var finalAddress = _baseAddress + _textSectionOffset + outLocation;

                        if (Interlocked.CompareExchange(ref *target.ValuePtr, finalAddress, 0) == 0) {
                            if (Interlocked.Decrement(ref remainingCount) == 0) {
                                loopState.Stop();
                                return;
                            }
                        }
                    }
                }
            });

            for (var i = 0; i < remainingAddresses.Length; i++) {
                var foundAddress = addressValues[i];

                if (foundAddress != 0) {
                    var address = remainingAddresses[i];

                    address.Value = foundAddress;

                    var outLocation = (int)(foundAddress - _baseAddress - _textSectionOffset);
                    if (_resolverCache?.Cache.TryAdd(address.CacheKey, outLocation + _textSectionOffset) == true)
                        _cacheChanged |= true;
                }
            }
        } finally {
            NativeMemory.Free(addressValues);

            for (var i = 0; i < 256; i++) {
                if (buckets[i] != null)
                    NativeMemory.Free(buckets[i]);

                if (bucketData[i] != null)
                    NativeMemory.Free(bucketData[i]);
            }
        }

        SaveCache();
    }

    [StructLayout(LayoutKind.Sequential)]
    private unsafe struct BucketAddressEntry {
        public nint* ValuePtr;
        public ulong* BytesPtr;
        public ulong* MaskPtr;
        public int BytesLen;
        public int AddressIndex;
    }

    public void RegisterAddress(Address address) {
        Addresses.Add(address);
    }

    public void UnregisterAddress(Address address) {
        Addresses.Remove(address);
    }
}
