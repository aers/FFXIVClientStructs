using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs;

/// <summary>
///     A SigScanner facilitates searching for memory signatures in a given ProcessModule.
/// </summary>
public sealed class SigScanner : IDisposable
{
    private long moduleCopyOffset;
    private IntPtr moduleCopyPtr;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SigScanner" /> class.
    /// </summary>
    /// <param name="module">The ProcessModule to be used for scanning.</param>
    /// <param name="doCopy">
    ///     Whether or not to copy the module upon initialization for search operations to use, as to not get
    ///     disturbed by possible hooks.
    /// </param>
    public SigScanner(ProcessModule module, bool doCopy = false)
    {
        Module = module;
        Is32BitProcess = !Environment.Is64BitProcess;
        IsCopy = doCopy;
        OwnsCopy = true;

        // Limit the search space to .text section.
        SetupSearchSpace(module);

        if (IsCopy)
            SetupCopiedSegments();
    }

    public SigScanner(ProcessModule module, IntPtr moduleCopy)
    {
        Module = module;
        Is32BitProcess = !Environment.Is64BitProcess;
        IsCopy = true;
        OwnsCopy = false;

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
    public IntPtr SearchBase => IsCopy ? moduleCopyPtr : Module.BaseAddress;

    /// <summary>
    ///     Gets the base address of the .text section search area.
    /// </summary>
    public IntPtr TextSectionBase => new(SearchBase.ToInt64() + TextSectionOffset);

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
    public IntPtr DataSectionBase => new(SearchBase.ToInt64() + DataSectionOffset);

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
    public IntPtr RDataSectionBase => new(SearchBase.ToInt64() + RDataSectionOffset);

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

    private IntPtr TextSectionTop => TextSectionBase + TextSectionSize;

    /// <summary>
    ///     Free the memory of the copied module search area on object disposal, if applicable.
    /// </summary>
    public void Dispose()
    {
        if (OwnsCopy)
            Marshal.FreeHGlobal(moduleCopyPtr);
    }

    /// <summary>
    ///     Scan memory for a signature.
    /// </summary>
    /// <param name="baseAddress">The base address to scan from.</param>
    /// <param name="size">The amount of bytes to scan.</param>
    /// <param name="signature">The signature to search for.</param>
    /// <returns>The found offset.</returns>
    public static IntPtr Scan(IntPtr baseAddress, int size, string signature)
    {
        var (needle, mask) = ParseSignature(signature);
        var index = IndexOf(baseAddress, size, needle, mask);
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
    public IntPtr GetStaticAddressFromSig(string signature, int offset = 0)
    {
        var instrAddr = ScanText(signature);
        instrAddr = IntPtr.Add(instrAddr, offset);
        var bAddr = (long) Module.BaseAddress;
        long num;

        do
        {
            instrAddr = IntPtr.Add(instrAddr, 1);
            num = Marshal.ReadInt32(instrAddr) + (long) instrAddr + 4 - bAddr;
        } while (!(num >= DataSectionOffset && num <= DataSectionOffset + DataSectionSize)
                 && !(num >= RDataSectionOffset && num <= RDataSectionOffset + RDataSectionSize));

        return IntPtr.Add(instrAddr, Marshal.ReadInt32(instrAddr) + 4);
    }

    /// <summary>
    ///     Scan for a byte signature in the .data section.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>The real offset of the found signature.</returns>
    public IntPtr ScanData(string signature)
    {
        var scanRet = Scan(DataSectionBase, DataSectionSize, signature);

        if (IsCopy)
            scanRet = new IntPtr(scanRet.ToInt64() - moduleCopyOffset);

        return scanRet;
    }

    /// <summary>
    ///     Scan for a byte signature in the whole module search area.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>The real offset of the found signature.</returns>
    public IntPtr ScanModule(string signature)
    {
        var scanRet = Scan(SearchBase, Module.ModuleMemorySize, signature);

        if (IsCopy)
            scanRet = new IntPtr(scanRet.ToInt64() - moduleCopyOffset);

        return scanRet;
    }

    /// <summary>
    ///     Resolve a RVA address.
    /// </summary>
    /// <param name="nextInstAddr">The address of the next instruction.</param>
    /// <param name="relOffset">The relative offset.</param>
    /// <returns>The calculated offset.</returns>
    public IntPtr ResolveRelativeAddress(IntPtr nextInstAddr, int relOffset)
    {
        if (Is32BitProcess) throw new NotSupportedException("32 bit is not supported.");
        return nextInstAddr + relOffset;
    }

    /// <summary>
    ///     Scan for a byte signature in the .text section.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>The real offset of the found signature.</returns>
    public IntPtr ScanText(string signature)
    {
        var mBase = IsCopy ? moduleCopyPtr : TextSectionBase;

        var scanRet = Scan(mBase, TextSectionSize, signature);

        if (IsCopy)
            scanRet = new IntPtr(scanRet.ToInt64() - moduleCopyOffset);

        var insnByte = Marshal.ReadByte(scanRet);

        if (insnByte == 0xE8 || insnByte == 0xE9)
            return ReadCallSig(scanRet);

        return scanRet;
    }

    /// <summary>
    ///     Helper for ScanText to get the correct address for IDA sigs that mark the first CALL location.
    /// </summary>
    /// <param name="sigLocation">The address the CALL sig resolved to.</param>
    /// <returns>The real offset of the signature.</returns>
    private static IntPtr ReadCallSig(IntPtr sigLocation)
    {
        var jumpOffset = Marshal.ReadInt32(IntPtr.Add(sigLocation, 1));
        return IntPtr.Add(sigLocation, 5 + jumpOffset);
    }

    private static (byte[] Needle, bool[] Mask) ParseSignature(string signature)
    {
        if (signature.Contains(" ? "))
            signature = signature.Replace("?", "??");
        signature = signature.Replace(" ", string.Empty);
        if (signature.Length % 2 != 0)
            throw new ArgumentException("Signature without whitespaces must be divisible by two.", nameof(signature));
        var needleLength = signature.Length / 2;
        var needle = new byte[needleLength];
        var mask = new bool[needleLength];
        for (var i = 0; i < needleLength; i++)
        {
            var hexString = signature.Substring(i * 2, 2);
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
    private static unsafe int IndexOf(IntPtr bufferPtr, int bufferLength, byte[] needle, bool[] mask)
    {
        if (needle.Length > bufferLength) return -1;
        var badShift = BuildBadCharTable(needle, mask);
        var last = needle.Length - 1;
        var offset = 0;
        var maxoffset = bufferLength - needle.Length;
        var buffer = (byte*) bufferPtr;

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
        var last = needle.Length - 1;
        var badShift = new int[256];
        for (idx = last; idx > 0 && !mask[idx]; --idx)
        {
        }

        var diff = last - idx;
        if (diff == 0) diff = 1;

        for (idx = 0; idx <= 255; ++idx)
            badShift[idx] = diff;
        for (idx = last - diff; idx < last; ++idx)
            badShift[needle[idx]] = last - idx;
        return badShift;
    }

    private void SetupSearchSpace(ProcessModule module)
    {
        var baseAddress = module.BaseAddress;

        // We don't want to read all of IMAGE_DOS_HEADER or IMAGE_NT_HEADER stuff so we cheat here.
        var ntNewOffset = Marshal.ReadInt32(baseAddress, 0x3C);
        var ntHeader = baseAddress + ntNewOffset;

        // IMAGE_NT_HEADER
        var fileHeader = ntHeader + 4;
        var numSections = Marshal.ReadInt16(ntHeader, 6);

        // IMAGE_OPTIONAL_HEADER
        var optionalHeader = fileHeader + 20;

        IntPtr sectionHeader;
        if (Is32BitProcess) // IMAGE_OPTIONAL_HEADER32
            sectionHeader = optionalHeader + 224;
        else // IMAGE_OPTIONAL_HEADER64
            sectionHeader = optionalHeader + 240;

        // IMAGE_SECTION_HEADER
        var sectionCursor = sectionHeader;
        for (var i = 0; i < numSections; i++)
        {
            var sectionName = Marshal.ReadInt64(sectionCursor);

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