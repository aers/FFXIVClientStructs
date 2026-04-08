using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x49A)]
public partial struct TofuStartSharingPacket {
    [FieldOffset(0x0)] public TofuSharePacketData Data;

    [StructLayout(LayoutKind.Explicit, Size = 0x49A)]
    public partial struct TofuSharePacketData {
        [FieldOffset(0x0)] public ulong SenderContentId;
        [FieldOffset(0x8)] public uint Checksum; // uses 0x410 of BoardContent to create checksum
        [FieldOffset(0x10)] private TofuPackedBoard BoardContent;
        [FieldOffset(0x498)] public byte BoardIndexInSharedFolder; // 1-based
        [FieldOffset(0x499)] public byte TotalBoardsInSharedFolder;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct TofuStopSharingPacket {
    //
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public partial struct TofuRealTimeUpdatePacket {
    [FieldOffset(0x0)] public uint Checksum; // based off: field = 0x8, size = 0x38
}

[StructLayout(LayoutKind.Explicit, Size = 0x09)]
public partial struct TofuConfirmationPacket {
    [FieldOffset(0x0)] public ulong ReceiverContentId;
    [FieldOffset(0x8)] public byte BoardIndexInFolder; 
}
