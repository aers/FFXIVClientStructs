namespace FFXIVClientStructs.FFXIV.Client.Network;

// Client::Network::PacketDispatcher
//   Client::Network::Protocol::Zone::PacketReceiverCallbackInterface
//   Client::Network::Protocol::Chat::PacketReceiverCallbackInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 51 ?? 48 89 01 48 8B D9 48 8D 05", 3)]
public unsafe partial struct PacketDispatcher {
    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 48 8B F2")]
    public static partial void HandleSocialPacket(uint targetId, nint packet);

    [MemberFunction("48 89 5C 24 08 57 48 83 EC 20 48 8B 0D ?? ?? ?? ?? 48 8B FA E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 4A")]
    public static partial void HandleMarketBoardItemRequestStartPacket(uint targetId, nint packet);

    [MemberFunction("40 55 56 41 56 48 8B EC 48 83 EC ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 48 8B 0D ?? ?? ?? ?? 4C 8B F2")]
    public static partial void HandleMarketBoardPurchasePacket(uint targetId, nint packet);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 40 B8 00 00 00 E0")]
    public static partial void HandleEventPlayPacket(ulong objectId, uint eventId, ushort stage, ulong a4, uint* payload, byte payloadSize);

    [MemberFunction("E8 ?? ?? ?? ?? EB 10 48 8B 0D")]
    public static partial void SendEventCompletePacket(uint eventId, ushort stage, byte a3, uint* payload, byte payloadSize, void* a6);

    [VirtualFunction(1)]
    public partial void OnReceivePacket(uint targetId, nint packet);
}
