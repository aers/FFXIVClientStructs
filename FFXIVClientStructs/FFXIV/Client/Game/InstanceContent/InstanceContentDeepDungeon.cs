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
    [FieldOffset(0x1EFC)] public byte Unk_1EFC;

    [FieldOffset(0x1F00)] public uint BonusLootItemId;
    [FieldOffset(0x1F04)] public byte Floor;
    [FieldOffset(0x1F05)] public byte ReturnProgress;
    [FieldOffset(0x1F06)] public byte PassageProgress;

    [FieldOffset(0x1F08)] public byte WeaponLevel;
    [FieldOffset(0x1F09)] public byte ArmorLevel;
    [FieldOffset(0x1F0A)] public byte SyncedGearLevel;
    [FieldOffset(0x1F0B)] public byte HoardCount;

    [FieldOffset(0x1F10)] public char* MapDataPtr;
    [FieldOffset(0x1F20), FixedSizeArray] internal FixedSizeArray3<LayoutInfo> _layoutInfos;

    [FieldOffset(0x28F4)] public int Unk_28F4;

    [FieldOffset(0x2900), FixedSizeArray] internal FixedSizeArray25<byte> _mapData; // list of RoomFlags

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x338)]
    public partial struct LayoutInfo {
        // row ID from DeepDungeonRoom sheet
        // layout consists of 21 possible rooms - the floorset is a 5x5 grid but the corners are never accessible and have no terrain
        // each row contains an array of 5 IDs:
        //   0 = ID of a SharedGroup corresponding to the whole room
        //   1-4 have 3 possible values:
        //     - 0: this wall is ordinary terrain and cannot be open
        //     - 1: this wall is the room's only entrance so there is no collider blocking it
        //     - otherwise: integer ID of a CollisionBox instance; whether the box is active or not depends on the contents of the MapData array on the parent struct
        [FieldOffset(0x332)] public ushort RoomStartIndex;
    }

    // each DD floor map actually contains two mirrored copies of the same layout; this is usually either 0 or 1, but LayoutInfos[2] *is* referenced in the code - needs more investigation
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

