namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentDeepDungeon
//   Client::Game::InstanceContent::InstanceContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
// ctor "48 89 5C 24 ?? 57 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 89 03 48 8D 8B"
[GenerateInterop]
[Inherits<InstanceContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x2920)]
public unsafe partial struct InstanceContentDeepDungeon {
    [FieldOffset(0x1E88), FixedSizeArray] internal FixedSizeArray4<DeepDungeonPartyInfo> _party;
    [FieldOffset(0x1EA8), FixedSizeArray] internal FixedSizeArray16<DeepDungeonItemInfo> _items;
    [FieldOffset(0x1ED8), FixedSizeArray] internal FixedSizeArray16<DeepDungeonChestInfo> _chests;
    [FieldOffset(0x1EF8), FixedSizeArray] internal FixedSizeArray3<byte> _magicite;

    [FieldOffset(0x1F00)] public uint BonusLootItemId;
    [FieldOffset(0x1F04)] public byte Floor;
    [FieldOffset(0x1F05)] public byte ReturnProgress;
    [FieldOffset(0x1F06)] public byte PassageProgress;

    [FieldOffset(0x1F08)] public byte WeaponLevel;
    [FieldOffset(0x1F09)] public byte ArmorLevel;
    [FieldOffset(0x1F0A)] public byte SyncedGearLevel;
    [FieldOffset(0x1F0B)] public byte HoardCount;

    [FieldOffset(0x28CE)] public byte DeepDungeonId; // 1-3

    [FieldOffset(0x2900), FixedSizeArray] internal FixedSizeArray25<RoomFlags> _mapData;

    // each DD floor map actually contains two mirrored copies of the same layout; this is usually either 0 or 1, but LayoutInfos[2] *is* referenced in the code - might be HoH hall of fallacies? (large rectangular room with no walls)
    [FieldOffset(0x291A)] public byte ActiveLayoutIndex;
    // seen values:
    // 1 - normal
    // 6 - in boss arena
    [FieldOffset(0x291B)] public byte LayoutInitializationType;

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

    [Flags]
    public enum RoomFlags : byte {
        None = 0,
        ConnectionN = 1,
        ConnectionS = 1 << 1,
        ConnectionW = 1 << 2,
        ConnectionE = 1 << 3,
        Return = 1 << 4,
        Passage = 1 << 5,
        Home = 1 << 6,
        Revealed = 1 << 7
    }
}
