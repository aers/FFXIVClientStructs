namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public partial struct SpectatorListPacket {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray8<uint> _spectatorIds;
    [FieldOffset(0x20)] private byte Flag; // Used as a count for spectator ids, maybe?
}
