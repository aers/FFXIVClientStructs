namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentDeepDungeon
//   Client::Game::InstanceContent::InstanceContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 E8 ?? ?? ?? ?? C6 87"
[StructLayout(LayoutKind.Explicit, Size = 0x27D8)]
public unsafe partial struct InstanceContentDeepDungeon {
    [FieldOffset(0x00)] public InstanceContentDirector InstanceContentDirector;

    [FixedSizeArray<DeepDungeonPartyInfo>(4)]
    [FieldOffset(0x1D48)] public fixed byte Party[0x08 * 4];
    [FixedSizeArray<DeepDungeonItemInfo>(16)]
    [FieldOffset(0x1D68)] public fixed byte Items[0x03 * 16];
    [FixedSizeArray<DeepDungeonChestInfo>(16)]
    [FieldOffset(0x1D98)] public fixed byte Chests[0x02 * 16];

    [FieldOffset(0x1DC8)] public uint BonusLootItemId;
    [FieldOffset(0x1DCC)] public byte Floor;
    [FieldOffset(0x1DCD)] public byte ReturnProgress;
    [FieldOffset(0x1DCE)] public byte PassageProgress;

    [FieldOffset(0x1DD0)] public byte WeaponLevel;
    [FieldOffset(0x1DD1)] public byte ArmorLevel;
    [FieldOffset(0x1DD2)] public byte HoardCount;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct DeepDungeonPartyInfo {
        [FieldOffset(0x00)] public uint ObjectId;
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
