using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

/// <summary>
/// The unpacked board is initially constructed in <see cref="TofuBoardOverview.ConstructUnpackedBoard"/> and then compressed via zlib. <br/>
/// Useful Information: https://github.com/xivdev/file-formats/blob/main/imhex/stgy.hexpat
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = StructSize)]
public unsafe partial struct TofuPackedBoard {
    private const int StructSize = 0x410;

    [FieldOffset(0x0)] public ushort PackedSize;
    [FieldOffset(0x2)] public SharingType SharingType;

    /// <summary>
    /// Uncompresses the packed board content to a readable format.
    /// </summary>
    /// <returns> A struct of the unpacked board. </returns>
    public TofuUnpackedBoard Uncompress() {
        var headerSize = 0x3;
        var uncompressedSize = 0x820;

        var compressedBoard = (byte*)Unsafe.AsPointer(ref this) + headerSize; // 0x78 0x9C zlib flag
        using var memoryStream = new UnmanagedMemoryStream(compressedBoard, StructSize - headerSize);
        using var zlib = new ZLibStream(memoryStream, CompressionMode.Decompress);

        // zlib.ReadExactly *sometimes* causes crashes: "Unable to read beyond the end of the stream."
        int offset = 0;
        var buffer = new byte[uncompressedSize];
        while (offset < buffer.Length) {
            var bytesRead = zlib.Read(buffer, offset, buffer.Length - offset);
            if (bytesRead <= 0) break;
            offset += bytesRead;
        }
        return MemoryMarshal.Read<TofuUnpackedBoard>(buffer);
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x820)]
public unsafe partial struct TofuUnpackedBoard {
    private const uint ObjectOffset = 0x3;
    private const uint ObjectSize = 0x11;

    [FieldOffset(0x0)] public byte Background;
    [FieldOffset(0x1)] public byte NumberOfObjects;
    [FieldOffset(0x2)] public byte NumberOfTextObjects; 

    public Span<TofuUnpackedObject> Objects => new((byte*)Unsafe.AsPointer(ref this) + ObjectOffset, NumberOfObjects);
    private Span<byte> TextLength => new((byte*)Unsafe.AsPointer(ref this) + ObjectOffset + NumberOfObjects * ObjectSize, NumberOfTextObjects);
    public string[] TextContents {
        get {
            var textPtr = (byte*)Unsafe.AsPointer(ref this) + ObjectOffset + (NumberOfObjects * ObjectSize) + NumberOfTextObjects;
            var result = new string[NumberOfTextObjects];
            for (int i = 0; i < NumberOfTextObjects; i++) {
                var length = TextLength[i];
                result[i] = Encoding.UTF8.GetString(textPtr, length);
                textPtr += length;
            }
            return result;
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x11)]
public partial struct TofuUnpackedObject {
    private const ushort TextFlag = 0x4000;
    private const ushort NegativeAngleFlag = 0x8000;
    
    [FieldOffset(0x0)] public ushort PosXRaw; // Can contain embedded flags
    [FieldOffset(0x2)] public ushort PosY;
    [FieldOffset(0x4)] public TofuObjectType ObjectType;
    [FieldOffset(0x6)] public ushort ArgExtra1;
    [FieldOffset(0x8)] public ushort ArgExtra2;
    [FieldOffset(0xA)] public ushort ArgExtra3;
    [FieldOffset(0xC)] public byte ColourPaletteIndex;
    [FieldOffset(0xD)] public byte Transparency;
    [FieldOffset(0xE)] public byte Scale;
    [FieldOffset(0xF)] public byte AngleRaw;
    [FieldOffset(0x10)] public bool IsVisible;

    public ushort PosX => (ushort)(PosXRaw & ~TextFlag & ~NegativeAngleFlag);
    public short Angle => (short)((PosXRaw & NegativeAngleFlag) != 0 ? -AngleRaw : AngleRaw);
    public bool HasText => (PosXRaw & TextFlag) != 0;
}

[Flags]
public enum SharingType : byte {
    Normal = 0,
    RealTime = 1,
    Folder = 4,
}

[Flags]
public enum SendState : uint {
    None = 0,
    Intermediate = 1,
    Last = 2,
}
