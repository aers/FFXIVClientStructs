namespace FFXIVClientStructs.FFXIV.Application.Network;

// Application::Network::ZoneClient
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct ZoneClient {
    [FieldOffset(0x0)] public Utf8String Host;
    [FieldOffset(0x68)] public ushort Port;
    [FieldOffset(0x6C)] public TransportLayers TransportLayer;
    [FieldOffset(0x72)] private short Unk72; // value set to 333 in function E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? (7.41)
    /// <remarks>
    /// Contains the string bytes %u of LocalPlayer.EntityId
    /// </remarks>
    [FieldOffset(0x78)] public StdVector<byte> HostFullDetails;
    [FieldOffset(0x90)] public int KeepAliveZone;
    [FieldOffset(0x94)] public int KeepAliveInvervalZone;
    [FieldOffset(0x98)] private nint ChannelManager;
    [MemberFunction("48 83 EC ?? 48 8B 89 ?? ?? ?? ?? 48 85 C9 74 ?? 44 89 44 24 ?? 4C 8D 44 24 ?? 44 89 4C 24 ?? 44 0F B6 4C 24")]
    public partial bool SendPacket(nint packet, uint a3, uint a4, bool a5);
}
