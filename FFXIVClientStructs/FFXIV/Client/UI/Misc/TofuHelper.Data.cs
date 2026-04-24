using System.Runtime.CompilerServices;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

/// <summary>
/// The unpacked board is initially constructed in <see cref="TofuBoardOverview.ConstructUnpackedBoard"/> and then compressed via zlib. <br/>
/// Useful Information: https://github.com/xivdev/file-formats/blob/main/imhex/stgy.hexpat
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x410)]
public unsafe partial struct TofuPackedBoard {
    [FieldOffset(0x0)] public ushort UnpackedSize;
    [FieldOffset(0x2)] public SharingType SharingType;
    [FieldOffset(0x3), FixedSizeArray] internal FixedSizeArray1037<byte> _data;

    /// <summary>
    /// Decompresses the packed board to an unpacked board.
    /// </summary>
    /// <returns> <see langword="true"/> if decompression was successful. </returns>
    public bool TryDecompressTo(TofuUnpackedBoard* target) {
        if (UnpackedSize > TofuUnpackedBoard.StructSize)
            return false;

        int size = UnpackedSize;

        if (target->ReadPackedBoard(&size, Data.GetPointer(0), StructSize - 3) != 0)
            return false;

        return size == UnpackedSize;
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x820)]
public unsafe partial struct TofuUnpackedBoard {
    [FieldOffset(0x0)] public byte Background;
    [FieldOffset(0x1)] public byte NumberOfObjects;
    [FieldOffset(0x2)] public byte NumberOfTextObjects;

    public byte* ObjectsPointer => (byte*)Unsafe.AsPointer(ref this) + 0x3;
    public byte* TextLengthsPointer => ObjectsPointer + NumberOfObjects * TofuUnpackedObject.StructSize;
    public byte* TextObjectsPointer => TextLengthsPointer + NumberOfTextObjects;

    public Span<TofuUnpackedObject> Objects => new(ObjectsPointer, NumberOfObjects);
    public Span<byte> TextLengths => new(TextLengthsPointer, NumberOfTextObjects);

    public Span<byte> GetTextSpan(int index) {
        if (index >= NumberOfTextObjects)
            return [];

        var lengths = TextLengths;
        var currentPtr = TextObjectsPointer;

        for (var i = 0; i < index; i++) {
            currentPtr += lengths[i];
        }

        return new Span<byte>(currentPtr, lengths[index]);
    }

    public string GetText(int index) => Encoding.UTF8.GetString(GetTextSpan(index));

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 ?? 39 6C 24")]
    public partial int ReadPackedBoard(int* outPacketSize, byte* packedData, int packedDataLength);
}

[StructLayout(LayoutKind.Explicit, Size = StructSize)]
public partial struct TofuUnpackedObject {
    public const int StructSize = 0x11;

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
