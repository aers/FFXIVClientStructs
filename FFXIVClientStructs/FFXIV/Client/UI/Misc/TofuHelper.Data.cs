namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

/// <summary>
/// The packed board is initially constructed in <see cref="TofuBoardOverview.ConstructPackedBoard"/> and then compressed via zlib. <br/>
/// Useful Information: https://github.com/xivdev/file-formats/blob/main/imhex/stgy.hexpat
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x410)]
public partial struct TofuPackedBoard {
    [FieldOffset(0x0)] private ushort Unk0; // increments by 0x11 with number of objects starting at 0x03
    [FieldOffset(0x2)] public SharingType SharingType;
    [FieldOffset(0x6)] private byte Unk6; // lower nibble changes with background
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
