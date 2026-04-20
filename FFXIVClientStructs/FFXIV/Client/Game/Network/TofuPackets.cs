using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x49A)]
public partial struct TofuStartSharingPacket {
    [FieldOffset(0x0)] public ulong SenderContentId;
    [FieldOffset(0x8)] public uint Checksum; // uses BoardContent to create checksum
    [FieldOffset(0x10)] public TofuPackedBoard BoardContent;
    [FieldOffset(0x420), FixedSizeArray(isString: true)] internal FixedSizeArray60<byte> _folderName;
    [FieldOffset(0x45C), FixedSizeArray(isString: true)] internal FixedSizeArray60<byte> _boardName;
    [FieldOffset(0x498)] public byte BoardIndexInSharedFolder; // 1-based
    [FieldOffset(0x499)] public byte TotalBoardsInSharedFolder;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct TofuStopSharingPacket;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public partial struct TofuRealTimeUpdatePacket {
    [FieldOffset(0x0)] public uint Checksum; // based off: field = 0x8, size = 0x38
    [FieldOffset(0x8)] private uint Unk8; // constantly changing, doesnt seem to be server time
    [FieldOffset(0xC)] private uint UnkC; // Operation Flag, first byte is main op flag, second (and third?) byte is argument(?), fourth byte seems like a bool(?)
    [FieldOffset(0x10)] private byte Unk10; // Contains object index... sometimes (add object/move layer is different)
    [FieldOffset(0x11)] private byte Unk11; // Payload start, position, scale, text content, etc
}

[StructLayout(LayoutKind.Explicit, Size = 0x09)]
public partial struct TofuConfirmationPacket {
    [FieldOffset(0x0)] public ulong ReceiverContentId;
    [FieldOffset(0x8)] public byte BoardIndexInFolder; 
}
