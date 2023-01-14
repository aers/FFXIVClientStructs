using Serilog;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace FFXIVClientStructs.Interop;

public sealed partial class Resolver
{
    private static readonly Lazy<Resolver> Instance = new(() => new Resolver());

    private Resolver()
    {
    }
    
    public static Resolver GetInstance => Instance.Value;

    private readonly List<Address>?[] _preResolveArray = new List<Address>[256];
    private int _totalBuckets;

    private readonly List<Address> _addresses = new();
    public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

    private ConcurrentDictionary<string, long>? _textCache;
    private FileInfo? _cacheFile;
    private bool _cacheChanged = false;

    private nint _baseAddress;
    
    private nint _targetSpace;
    private int _targetLength;

    private int _textSectionOffset;
    private int _textSectionSize;
    private int _dataSectionOffset;
    private int _dataSectionSize;
    private int _rdataSectionOffset;
    private int _rdataSectionSize;

    private bool _hasResolved = false;
    private bool _isSetup = false;

    public void SetupSearchSpace(nint moduleCopy = 0, FileInfo? cacheFile = null)
    {
        if (_isSetup) return;
        ProcessModule? module = Process.GetCurrentProcess().MainModule;
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
        int dataSectionOffset, int dataSectionSize, int rdataSectionOffset, int rdataSectionSize, FileInfo? cacheFile = null)
    {
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
    private unsafe void SetupSections()
    {
        ReadOnlySpan<byte> baseAddress = new(_baseAddress.ToPointer(), _targetLength);

        // We don't want to read all of IMAGE_DOS_HEADER or IMAGE_NT_HEADER stuff so we cheat here.
        int ntNewOffset = BitConverter.ToInt32(baseAddress.Slice(0x3C, 4));
        ReadOnlySpan<byte> ntHeader = baseAddress[ntNewOffset..];

        // IMAGE_NT_HEADER
        ReadOnlySpan<byte> fileHeader = ntHeader[4..];
        short numSections = BitConverter.ToInt16(ntHeader.Slice(6, 2));

        // IMAGE_OPTIONAL_HEADER
        ReadOnlySpan<byte> optionalHeader = fileHeader[20..];

        ReadOnlySpan<byte> sectionHeader = optionalHeader[240..]; // IMAGE_OPTIONAL_HEADER64

        // IMAGE_SECTION_HEADER
        ReadOnlySpan<byte> sectionCursor = sectionHeader;
        for (int i = 0; i < numSections; i++)
        {
            long sectionName = BitConverter.ToInt64(sectionCursor);

            // .text
            switch (sectionName)
            {
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
    private void LoadCache()
    {
        if (_cacheFile is not { Exists: true })
        {
            _textCache = new ConcurrentDictionary<string, long>();
            return;
        }

        try
        {
            var json = File.ReadAllText(_cacheFile.FullName);
            _textCache = JsonSerializer.Deserialize<ConcurrentDictionary<string, long>>(json) ?? new ConcurrentDictionary<string, long>();
        }
        catch
        {
            _textCache = new ConcurrentDictionary<string, long>();
        }
    }

    private void SaveCache()
    {
        if (_cacheFile == null || _textCache == null || _cacheChanged == false)
            return;
        var json = JsonSerializer.Serialize(_textCache, new JsonSerializerOptions { WriteIndented = true });
        if (string.IsNullOrWhiteSpace(json))
            return;
        if (_cacheFile.Directory is { Exists: false })
            Directory.CreateDirectory(_cacheFile.Directory.FullName);
        File.WriteAllText(_cacheFile.FullName, json);
    }

    private bool ResolveFromCache()
    {
        foreach (Address address in _addresses)
        {
            if (_textCache!.TryGetValue(address.String, out var offset))
            {
                address.Value = (nuint) (offset + _baseAddress);
                byte firstByte = (byte)address.Bytes[0];
                _preResolveArray[firstByte]!.Remove(address);
                if (_preResolveArray[firstByte]!.Count == 0)
                {
                    _preResolveArray[firstByte] = null;
                    _totalBuckets--;
                }
            }
        }

        return _addresses.All(a => a.Value != 0);
    }

    // This function is a bit messy, but everything to make it cleaner is slower, so don't bother.
    public unsafe void Resolve()
    {
        if (_hasResolved)
            return;
        
        if (_targetSpace == 0)
            throw new Exception("[FFXIVClientStructs.Resolver] Attempted to call Resolve() without initializing the search space.");

        if (_textCache is not null)
        {
            if (ResolveFromCache())
                return;
        }

        ReadOnlySpan<byte> targetSpan = new ReadOnlySpan<byte>(_targetSpace.ToPointer(), _targetLength)[_textSectionOffset..];

        for (int location = 0; location < _textSectionSize; location++)
        {
            if (_preResolveArray[targetSpan[location]] is not null)
            {
                List<Address> availableAddresses = _preResolveArray[targetSpan[location]]!;
                
                ReadOnlySpan<ulong> targetLocationAsUlong = MemoryMarshal.Cast<byte, ulong>(targetSpan[location..]);

                int avLen = availableAddresses.Count;
                
                for(int i = 0; i < avLen; i++)
                {
                    Address address = availableAddresses[i];
                    
                    int count;
                    int length = address.Bytes.Length;

                    for (count = 0; count < length; count++)
                    {
                        if ((address.Mask[count] & address.Bytes[count]) != (address.Mask[count] & targetLocationAsUlong[count]))
                            break;
                    }

                    if (count == length)
                    {
                        int outLocation = location;

                        byte firstByte = (byte) address.Bytes[0];
                        if (firstByte is 0xE8 or 0xE9)
                        {
                            var jumpOffset = BitConverter.ToInt32(targetSpan.Slice(outLocation + 1, 4));
                            outLocation = outLocation + 5 + jumpOffset;
                        }

                        if (address is StaticAddress staticAddress)
                        {
                            int accessOffset =
                                BitConverter.ToInt32(targetSpan.Slice(outLocation + staticAddress.Offset, 4));
                            outLocation = outLocation + staticAddress.Offset + 4 + accessOffset;
                        }

                        address.Value = (nuint) (_baseAddress + _textSectionOffset + outLocation);
                        if (_textCache?.TryAdd(address.String, outLocation + _textSectionOffset) == true)
                            _cacheChanged = true;
                        availableAddresses.Remove(address);
                        if (availableAddresses.Count == 0)
                        {
                            _preResolveArray[targetSpan[location]] = null;
                            _totalBuckets--;
                            if (_totalBuckets == 0)
                                goto outLoop;
                        }

                        break;
                    }
                }
            }
        }
        outLoop: ;

        SaveCache();
        _hasResolved = true;
    }
    
    private void RegisterAddress(Address address)
    {
        _addresses.Add(address);

        byte firstByte = (byte) (address.Bytes[0]);

        if (_preResolveArray[firstByte] is null)
        {
            _preResolveArray[firstByte] = new List<Address>();
            _totalBuckets++;
        }

        _preResolveArray[firstByte]!.Add(address);
    }
}