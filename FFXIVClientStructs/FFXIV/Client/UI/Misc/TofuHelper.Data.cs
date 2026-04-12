namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public partial struct TofuTransferObject {
    // Different structure to TofuModule's TofuObject
    [FieldOffset(0x10)] public Utf8String Name;
    [FieldOffset(0x78)] public ushort PosX;
    [FieldOffset(0x7A)] public ushort PosY;
    [FieldOffset(0x80)] public ushort Scale;
    [FieldOffset(0x82)] public ushort Angle;
    [FieldOffset(0x84)] public uint RGBA;
    [FieldOffset(0x88)] public bool IsVisible;
    [FieldOffset(0x8A)] public ushort ArgExtra1;
    [FieldOffset(0x8C)] public ushort ArgExtra2;
    [FieldOffset(0x8E)] public ushort ArgExtra3;
    [FieldOffset(0x90)] public Utf8String TextContent;
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray5<TofuObjectArgData> _argDatas;
    [FieldOffset(0x358)] public StdVector<TofuTransferObject> InnerObjects;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct TofuObjectArgData {
    [FieldOffset(0x0)] public Utf8String Name;
}

/// <summary>
/// The packed board is initially constructed in <see cref="TofuBoardOverview.ConstructPackedBoard"/> and then compressed via zlib.
/// Useful Information: https://github.com/xivdev/file-formats/blob/main/imhex/stgy.hexpat
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public partial struct TofuPackedBoard {
    [FieldOffset(0x0)] private ushort Unk0; // increments by 0x11 with number of objects starting at 0x03
    [FieldOffset(0x2)] public SharingType SharingType;
    [FieldOffset(0x6)] private byte Unk6; // lower nibble changes with background
    [FieldOffset(0x410), FixedSizeArray(isString: true)] internal FixedSizeArray60<byte> _boardName;
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
