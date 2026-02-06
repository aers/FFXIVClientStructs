using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Game.Network;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Network;

// Client::Network::PacketDispatcher
//   Client::Network::Protocol::Zone::PacketReceiverCallbackInterface
//   Client::Network::Protocol::Chat::PacketReceiverCallbackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 51 ?? ?? ?? ?? 48 8B D9 48 8D 05 ?? ?? ?? ?? 48 89 41", 3)]
public unsafe partial struct PacketDispatcher {
    [FieldOffset(0x10)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0x18)] public uint GameSessionRandom;
    [FieldOffset(0x1C)] public uint LastPacketRandom;
    [FieldOffset(0x20)] public uint Key0;
    [FieldOffset(0x24)] public uint Key1;
    [FieldOffset(0x28)] public uint Key2;

    [MemberFunction("40 55 53 57 41 54 41 56 48 8D AC 24 ?? ?? ?? ?? B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 2B E0 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 85 ?? ?? ?? ?? 8B 85")]
    public static partial void HandleActorControlPacket(
        uint entityId,
        uint category,
        uint arg1,
        uint arg2,
        uint arg3,
        uint arg4,
        uint arg5,
        uint arg6,
        uint arg7,
        uint arg8,
        GameObjectId targetId,
        bool isRecorded);

    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 48 8B F2")]
    public static partial void HandleSocialPacket(uint targetId, nint packet);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 48 8B DA E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74")]
    public static partial void HandleMarketBoardItemRequestStartPacket(uint targetId, nint packet);

    [MemberFunction("40 55 56 41 56 48 8B EC 48 83 EC ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 48 8B 0D ?? ?? ?? ?? 48 8B F2 E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B 10")]
    public static partial void HandleMarketBoardPurchasePacket(uint targetId, nint packet);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 40 B8 00 00 00 E0")]
    public static partial void HandleEventPlayPacket(GameObjectId objectId, EventId eventId, short scene, ulong sceneFlags, uint* sceneData, byte sceneDataCount);

    [Obsolete("Use HandleInventoryItemUpdatePacket")]
    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 0F B7 5A")]
    public static partial void HandleUpdateInventorySlotPacket(uint targetId, UpdateInventorySlotPacket* packet);

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 0F B7 5A")]
    public static partial void HandleInventoryItemUpdatePacket(uint targetId, InventoryItemPacket* packet);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 3D ?? ?? ?? ?? 75 ?? 48 8D 53")]
    public static partial void HandleInventoryItemPacket(uint targetId, InventoryItemPacket* packet);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 83 F8 ?? 75 ?? 48 8D 53")]
    public static partial void HandleInventoryItemCurrencyPacket(uint targetId, InventoryItemCurrencyPacket* packet);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5B ?? 48 85 DB 0F 85 ?? ?? ?? ?? 4D 85 FF")]
    public static partial void HandleInventoryItemSymbolicPacket(uint targetId, InventoryItemSymbolicPacket* packet);

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B DA 8B F9 0F B6 92")]
    public static partial void HandleSpawnPlayerPacket(uint targetId, SpawnPlayerPacket* packet);

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B DA 8B F9 E8 ?? ?? ?? ?? 3C ?? 75 ?? E8 ?? ?? ?? ?? 3C ?? 75 ?? 80 BB ?? ?? ?? ?? ?? 75 ?? 8B 05 ?? ?? ?? ?? 39 43 ?? 0F 85 ?? ?? ?? ?? 0F B6 53 ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F B6 53 ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 44 24 ?? C7 44 24 ?? ?? ?? ?? ?? BA ?? ?? ?? ?? 66 90 48 8D 80 ?? ?? ?? ?? ?? ?? ?? 0F 10 4B ?? 48 8D 9B ?? ?? ?? ?? 0F 11 40 ?? 0F 10 43 ?? 0F 11 48 ?? 0F 10 4B ?? 0F 11 40 ?? 0F 10 43 ?? 0F 11 48 ?? 0F 10 4B ?? 0F 11 40 ?? 0F 10 43 ?? 0F 11 48 ?? 0F 10 4B ?? 0F 11 40 ?? 0F 11 48 ?? 48 83 EA ?? 75 ?? ?? ?? ?? 4C 8D 44 24")]
    public static partial void HandleSpawnNpcPacket(uint targetId, SpawnNpcPacket* packet);

    [MemberFunction("40 53 57 48 83 EC ?? F6 42")]
    public static partial void HandleSpawnObjectPacket(uint targetId, SpawnObjectPacket* packet);

    [MemberFunction("48 89 74 24 ?? 57 48 83 EC ?? 0F B6 42 ?? 48 8D 0D")]
    public static partial void HandleSpawnTreasurePacket(uint targetId, SpawnTreasurePacket* packet);

    [MemberFunction("E8 ?? ?? ?? ?? EB 10 48 8B 0D")]
    public static partial void SendEventCompletePacket(EventId eventId, short scene, byte a3, uint* payload, byte payloadSize, void* a6);

    [VirtualFunction(1)]
    public partial void OnReceivePacket(uint targetId, nint packet);
}
