namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentDeepDungeon
//   Client::Game::InstanceContent::InstanceContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 E8 ?? ?? ?? ?? C6 87"
[GenerateInterop]
[Inherits<InstanceContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x27D8)]
public unsafe partial struct InstanceContentDeepDungeon {
    [FieldOffset(0x1D50), FixedSizeArray] internal FixedSizeArray4<DeepDungeonPartyInfo> _party;
    [FieldOffset(0x1D70), FixedSizeArray] internal FixedSizeArray16<DeepDungeonItemInfo> _items;
    [FieldOffset(0x1DA0), FixedSizeArray] internal FixedSizeArray16<DeepDungeonChestInfo> _chests;

    [FieldOffset(0x1DD0)] public uint BonusLootItemId;
    [FieldOffset(0x1DD4)] public byte Floor;
    [FieldOffset(0x1DD5)] public byte ReturnProgress;
    [FieldOffset(0x1DD6)] public byte PassageProgress;

    [FieldOffset(0x1DD8)] public byte WeaponLevel;
    [FieldOffset(0x1DD9)] public byte ArmorLevel;
    [FieldOffset(0x1DDA)] public byte HoardCount;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct DeepDungeonPartyInfo {
        [FieldOffset(0x00)] public uint EntityId;
        [FieldOffset(0x04)] public sbyte RoomIndex;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x03)]
    public struct DeepDungeonItemInfo {
        [FieldOffset(0x00)] public byte ItemId;
        [FieldOffset(0x01)] public byte Count;
        [FieldOffset(0x02)] public byte Flags;

        public bool IsUsable => (Flags & (1 << 0)) != 0;
        public bool IsActive => (Flags & (1 << 1)) != 0;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x02)]
    public struct DeepDungeonChestInfo {
        [FieldOffset(0x00)] public byte ChestType;
        [FieldOffset(0x01)] public sbyte RoomIndex;
    }
}
