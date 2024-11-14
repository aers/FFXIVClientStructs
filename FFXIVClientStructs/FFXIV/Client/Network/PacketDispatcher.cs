namespace FFXIVClientStructs.FFXIV.Client.Network;

// Client::Network::PacketDispatcher
//   Client::Network::Protocol::Zone::PacketReceiverCallbackInterface
//   Client::Network::Protocol::Chat::PacketReceiverCallbackInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 51 ?? 48 89 01 48 8D 05 ?? ?? ?? ?? 48 89 41 ?? 48 8B C1", 3)]
public unsafe partial struct PacketDispatcher {
    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 48 8B F2")]
    public partial void HandleSocialPacket(nint packet);

    [VirtualFunction(1)]
    public partial void OnReceivePacket(uint targetId, nint packet);
}
