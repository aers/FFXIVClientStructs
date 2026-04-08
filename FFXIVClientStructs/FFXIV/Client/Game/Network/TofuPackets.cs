using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x4AA)]
public partial struct TofuStartSharingPacket {
    [FieldOffset(0x2)] public ushort OpCode;
    [FieldOffset(0x10)] public ulong SenderContentId;
    [FieldOffset(0x18)] public uint CheckSum; // uses 0x410 of BoardContent to create checksum
    [FieldOffset(0x20)] private TofuPackedBoard BoardContent;
    [FieldOffset(0x4A8)] public byte BoardIndexInSharedFolder; // 1-based
    [FieldOffset(0x4A9)] public byte TotalBoardsInSharedFolder;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct TofuStopSharingPacket {
    [FieldOffset(0x2)] public ushort OpCode;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public partial struct TofuRealTimeUpdatePacket {
    [FieldOffset(0x2)] public ushort OpCode;
    [FieldOffset(0x10)] public uint CheckSum; // based off: field = 0x18, size = 0x38
}

[StructLayout(LayoutKind.Explicit, Size = 0x19)]
public partial struct TofuConfirmationPacket {
    [FieldOffset(0x2)] public ushort OpCode;
    [FieldOffset(0x10)] public ulong ReceiverContentId;
    [FieldOffset(0x18)] public byte BoardIndexInFolder; 
}
