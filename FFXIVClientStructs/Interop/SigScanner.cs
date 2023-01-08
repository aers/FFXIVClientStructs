using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace FFXIVClientStructs;

/// <summary>
///     A SigScanner facilitates searching for memory signatures in a given ProcessModule.
/// </summary>
public sealed class SigScanner : IDisposable
{
    private readonly FileInfo cacheFile;
    private bool cacheChanged;
    private long moduleCopyOffset;
    private nint moduleCopyPtr;
    private ConcurrentDictionary<string, long> textCache;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SigScanner" /> class.
    /// </summary>
    /// <param name="module">The ProcessModule to be used for scanning.</param>
    /// <param name="doCopy">
    ///     Whether or not to copy the module upon initialization for search operations to use, as to not get
    ///     disturbed by possible hooks.
    /// </param>
    /// <param name="cacheFile">The FileInfo to use as Signature Cache File</param>
    public SigScanner(ProcessModule module, bool doCopy = false, FileInfo cacheFile = null)
    {
        Module = module;
        Is32BitProcess = !Environment.Is64BitProcess;
        IsCopy = doCopy;
        OwnsCopy = true;
        this.cacheFile = cacheFile;
        if (this.cacheFile != null)
            Load();

        // Limit the search space to .text section.
        SetupSearchSpace(module);

        if (IsCopy)
            SetupCopiedSegments();
    }

    public SigScanner(ProcessModule module, nint moduleCopy, FileInfo cacheFile = null)
    {
        Module = module;
        Is32BitProcess = !Environment.Is64BitProcess;
        IsCopy = true;
        OwnsCopy = false;
        this.cacheFile = cacheFile;
        if (this.cacheFile != null)
            Load();

        // Limit the search space to .text section.
        SetupSearchSpace(module);

        moduleCopyPtr = moduleCopy;
        moduleCopyOffset = moduleCopyPtr.ToInt64() - Module.BaseAddress.ToInt64();
    }

    /// <summary>
    ///     Gets a value indicating whether or not the search on this module is performed on a copy.
    /// </summary>
    public bool IsCopy { get; }

    public bool OwnsCopy { get; }

    /// <summary>
    ///     Gets a value indicating whether or not the ProcessModule is 32-bit.
    /// </summary>
    public bool Is32BitProcess { get; }

    /// <summary>
    ///     Gets the base address of the search area. When copied, this will be the address of the copy.
    /// </summary>
    public nint SearchBase => IsCopy ? moduleCopyPtr : Module.BaseAddress;

    /// <summary>
    ///     Gets the base address of the .text section search area.
    /// </summary>
    public nint TextSectionBase => new(SearchBase.ToInt64() + TextSectionOffset);

    /// <summary>
    ///     Gets the offset of the .text section from the base of the module.
    /// </summary>
    public long TextSectionOffset { get; private set; }

    /// <summary>
    ///     Gets the size of the text section.
    /// </summary>
    public int TextSectionSize { get; private set; }

    /// <summary>
    ///     Gets the base address of the .data section search area.
    /// </summary>
    public nint DataSectionBase => new(SearchBase.ToInt64() + DataSectionOffset);

    /// <summary>
    ///     Gets the offset of the .data section from the base of the module.
    /// </summary>
    public long DataSectionOffset { get; private set; }

    /// <summary>
    ///     Gets the size of the .data section.
    /// </summary>
    public int DataSectionSize { get; private set; }

    /// <summary>
    ///     Gets the base address of the .rdata section search area.
    /// </summary>
    public nint RDataSectionBase => new(SearchBase.ToInt64() + RDataSectionOffset);

    /// <summary>
    ///     Gets the offset of the .rdata section from the base of the module.
    /// </summary>
    public long RDataSectionOffset { get; private set; }

    /// <summary>
    ///     Gets the size of the .rdata section.
    /// </summary>
    public int RDataSectionSize { get; private set; }

    /// <summary>
    ///     Gets the ProcessModule on which the search is performed.
    /// </summary>
    public ProcessModule Module { get; }

    private nint TextSectionTop => TextSectionBase + TextSectionSize;

    /// <summary>
    ///     Free the memory of the copied module search area on object disposal, if applicable.
    /// </summary>
    public void Dispose()
    {
        if (OwnsCopy)
            Marshal.FreeHGlobal(moduleCopyPtr);
    }

    private void Load()
    {
        if (cacheFile is not { Exists: true })
        {
            textCache = new ConcurrentDictionary<string, long>();
            return;
        }

        try
        {
            string json = File.ReadAllText(cacheFile.FullName);
            textCache = JsonSerializer.Deserialize<ConcurrentDictionary<string, long>>(json) ??
                        new ConcurrentDictionary<string, long>();
        }
        catch
        {
            textCache = new ConcurrentDictionary<string, long>();
        }
    }

    internal void Save()
    {
        if (cacheFile == null || textCache == null || cacheChanged == false)
            return;
        string json = JsonSerializer.Serialize(textCache, new JsonSerializerOptions { WriteIndented = true });
        if (string.IsNullOrWhiteSpace(json))
            return;
        if (cacheFile.Directory is { Exists: false })
            Directory.CreateDirectory(cacheFile.Directory.FullName);
        File.WriteAllText(cacheFile.FullName, json);
    }

    /// <summary>
    ///     Scan memory for a signature.
    /// </summary>
    /// <param name="baseAddress">The base address to scan from.</param>
    /// <param name="size">The amount of bytes to scan.</param>
    /// <param name="signature">The signature to search for.</param>
    /// <returns>The found offset.</returns>
    public static nint Scan(nint baseAddress, int size, string signature)
    {
        (byte[] needle, bool[] mask) = ParseSignature(signature);
        int index = IndexOf(baseAddress, size, needle, mask);
        if (index < 0)
            throw new KeyNotFoundException($"Can't find a signature of {signature}");
        return baseAddress + index;
    }

    /// <summary>
    ///     Scan for a .data address using a .text function.
    ///     This is intended to be used with IDA sigs.
    ///     Place your cursor on the line calling a static address, and create and IDA sig.
    /// </summary>
    /// <param name="signature">The signature of the function using the data.</param>
    /// <param name="offset">The offset from function start of the instruction using the data.</param>
    /// <returns>An IntPtr to the static memory location.</returns>
    public nint GetStaticAddressFromSig(string signature, int offset = 0)
    {
        nint instrAddr = ScanText(signature);
        instrAddr = nint.Add(instrAddr, offset);
        long bAddr = (long)Module.BaseAddress;
        long num;

        do
        {
            instrAddr = nint.Add(instrAddr, 1);
            num = Marshal.ReadInt32(instrAddr) + (long)instrAddr + 4 - bAddr;
        } while (!(num >= DataSectionOffset && num <= DataSectionOffset + DataSectionSize)
                 && !(num >= RDataSectionOffset && num <= RDataSectionOffset + RDataSectionSize));

        return nint.Add(instrAddr, Marshal.ReadInt32(instrAddr) + 4);
    }

    /// <summary>
    ///     Scan for a byte signature in the .data section.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>The real offset of the found signature.</returns>
    public nint ScanData(string signature)
    {
        nint scanRet = Scan(DataSectionBase, DataSectionSize, signature);

        if (IsCopy)
            scanRet = new nint(scanRet.ToInt64() - moduleCopyOffset);

        return scanRet;
    }

    /// <summary>
    ///     Scan for a byte signature in the whole module search area.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>The real offset of the found signature.</returns>
    public nint ScanModule(string signature)
    {
        nint scanRet = Scan(SearchBase, Module.ModuleMemorySize, signature);

        if (IsCopy)
            scanRet = new nint(scanRet.ToInt64() - moduleCopyOffset);

        return scanRet;
    }

    /// <summary>
    ///     Resolve a RVA address.
    /// </summary>
    /// <param name="nextInstAddr">The address of the next instruction.</param>
    /// <param name="relOffset">The relative offset.</param>
    /// <returns>The calculated offset.</returns>
    public nint ResolveRelativeAddress(nint nextInstAddr, int relOffset)
    {
        if (Is32BitProcess) throw new NotSupportedException("32 bit is not supported.");
        return nextInstAddr + relOffset;
    }

    /// <summary>
    ///     Scan for a byte signature in the .text section.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>The real offset of the found signature.</returns>
    public nint ScanText(string signature)
    {
        nint mBase = IsCopy ? moduleCopyPtr : TextSectionBase;

        if (textCache != null && textCache.TryGetValue(signature, out long offset))
            return Module.BaseAddress + (nint)offset;

        nint scanRet = Scan(mBase, TextSectionSize, signature);

        if (IsCopy)
            scanRet = new nint(scanRet.ToInt64() - moduleCopyOffset);

        byte insnByte = Marshal.ReadByte(scanRet);

        if (insnByte == 0xE8 || insnByte == 0xE9)
            scanRet = ReadCallSig(scanRet);

        if (textCache?.TryAdd(signature, scanRet.ToInt64() - Module.BaseAddress.ToInt64()) == true)
            cacheChanged = true;

        return scanRet;
    }

    /// <summary>
    ///     Helper for ScanText to get the correct address for IDA sigs that mark the first CALL location.
    /// </summary>
    /// <param name="sigLocation">The address the CALL sig resolved to.</param>
    /// <returns>The real offset of the signature.</returns>
    private static nint ReadCallSig(nint sigLocation)
    {
        int jumpOffset = Marshal.ReadInt32(nint.Add(sigLocation, 1));
        return nint.Add(sigLocation, 5 + jumpOffset);
    }

    private static (byte[] Needle, bool[] Mask) ParseSignature(string signature)
    {
        if (signature.Contains(" ? "))
            signature = signature.Replace("?", "??");
        signature = signature.Replace(" ", string.Empty);
        if (signature.Length % 2 != 0)
            throw new ArgumentException("Signature without whitespaces must be divisible by two.", nameof(signature));
        int needleLength = signature.Length / 2;
        byte[] needle = new byte[needleLength];
        bool[] mask = new bool[needleLength];
        for (int i = 0; i < needleLength; i++)
        {
            string hexString = signature.Substring(i * 2, 2);
            if (hexString == "??" || hexString == "**")
            {
                needle[i] = 0;
                mask[i] = true;
                continue;
            }

            needle[i] = byte.Parse(hexString, NumberStyles.AllowHexSpecifier);
            mask[i] = false;
        }

        return (needle, mask);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe int IndexOf(nint bufferPtr, int bufferLength, byte[] needle, bool[] mask)
    {
        if (needle.Length > bufferLength) return -1;
        int[] badShift = BuildBadCharTable(needle, mask);
        int last = needle.Length - 1;
        int offset = 0;
        int maxoffset = bufferLength - needle.Length;
        byte* buffer = (byte*)bufferPtr;

        while (offset <= maxoffset)
        {
            int position;
            for (position = last; needle[position] == *(buffer + position + offset) || mask[position]; position--)
                if (position == 0)
                    return offset;

            offset += badShift[*(buffer + offset + last)];
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int[] BuildBadCharTable(byte[] needle, bool[] mask)
    {
        int idx;
        int last = needle.Length - 1;
        int[] badShift = new int[256];
        for (idx = last; idx > 0 && !mask[idx]; --idx)
        {
        }

        int diff = last - idx;
        if (diff == 0) diff = 1;

        for (idx = 0; idx <= 255; ++idx)
            badShift[idx] = diff;
        for (idx = last - diff; idx < last; ++idx)
            badShift[needle[idx]] = last - idx;
        return badShift;
    }

    private void SetupSearchSpace(ProcessModule module)
    {
        nint baseAddress = module.BaseAddress;

        // We don't want to read all of IMAGE_DOS_HEADER or IMAGE_NT_HEADER stuff so we cheat here.
        int ntNewOffset = Marshal.ReadInt32(baseAddress, 0x3C);
        nint ntHeader = baseAddress + ntNewOffset;

        // IMAGE_NT_HEADER
        nint fileHeader = ntHeader + 4;
        short numSections = Marshal.ReadInt16(ntHeader, 6);

        // IMAGE_OPTIONAL_HEADER
        nint optionalHeader = fileHeader + 20;

        nint sectionHeader;
        if (Is32BitProcess) // IMAGE_OPTIONAL_HEADER32
            sectionHeader = optionalHeader + 224;
        else // IMAGE_OPTIONAL_HEADER64
            sectionHeader = optionalHeader + 240;

        // IMAGE_SECTION_HEADER
        nint sectionCursor = sectionHeader;
        for (int i = 0; i < numSections; i++)
        {
            long sectionName = Marshal.ReadInt64(sectionCursor);

            // .text
            switch (sectionName)
            {
                case 0x747865742E: // .text
                    TextSectionOffset = Marshal.ReadInt32(sectionCursor, 12);
                    TextSectionSize = Marshal.ReadInt32(sectionCursor, 8);
                    break;
                case 0x617461642E: // .data
                    DataSectionOffset = Marshal.ReadInt32(sectionCursor, 12);
                    DataSectionSize = Marshal.ReadInt32(sectionCursor, 8);
                    break;
                case 0x61746164722E: // .rdata
                    RDataSectionOffset = Marshal.ReadInt32(sectionCursor, 12);
                    RDataSectionSize = Marshal.ReadInt32(sectionCursor, 8);
                    break;
            }

            sectionCursor += 40;
        }
    }

    private unsafe void SetupCopiedSegments()
    {
        // .text
        moduleCopyPtr = Marshal.AllocHGlobal(Module.ModuleMemorySize);
        Buffer.MemoryCopy(
            Module.BaseAddress.ToPointer(),
            moduleCopyPtr.ToPointer(),
            Module.ModuleMemorySize,
            Module.ModuleMemorySize);

        moduleCopyOffset = moduleCopyPtr.ToInt64() - Module.BaseAddress.ToInt64();
    }
}