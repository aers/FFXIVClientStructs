namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Buddy
// ctor "E8 ?? ?? ?? ?? 48 89 AB ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 AB"
[StructLayout(LayoutKind.Explicit, Size = 0x1B80)]
public unsafe partial struct Buddy {
    [StructLayout(LayoutKind.Explicit, Size = 0x300)]
    public struct BuddyMember {
        [FieldOffset(0x0)] public uint ObjectID;
        [FieldOffset(0x4)] public uint CurrentHealth;

        [FieldOffset(0x8)] public uint MaxHealth;

        // |----------|----------------|
        // | Type     | Sheet          |
        // |----------|----------------|
        // | Chocobo  | Mount          |
        // | Pet      | Pet            |
        // | Squadron | Unused         |
        // | Trust    | DawnGrowMember |
        // |----------|----------------|
        [FieldOffset(0xC)] public byte DataID;
        [FieldOffset(0xD)] public byte Synced;
        [FieldOffset(0x10)] public StatusManager StatusManager;
    }

    [FieldOffset(0x0)] public BuddyMember Companion;
    [FieldOffset(0x300)] public BuddyMember Pet;
    [FixedSizeArray<BuddyMember>(7)]
    [FieldOffset(0x600)] public fixed byte BattleBuddies[0x300 * 7]; // BuddyMember array for Squadron/Trust // TODO: move this to offset 0 and make it 9 entries in length
    [FieldOffset(0x1B00)] public CompanionInfo CompanionInfo;
    [FieldOffset(0x1B00), Obsolete("Use CompanionInfo.Companion")] public BuddyMember* CompanionPtr;
    [FieldOffset(0x1B08), Obsolete("Use CompanionInfo.TimeLeft")] public float TimeLeft;
    [FieldOffset(0x1B0C), Obsolete("Use CompanionInfo.BuddyEquipUnlockBitmask")] private fixed byte BuddyEquipUnlockBitmask[96 >> 3]; // number of BuddyEquip rows >> 3
    [FieldOffset(0x1B18), Obsolete("Use CompanionInfo.BardingHead")] private byte BardingHead;
    [FieldOffset(0x1B19), Obsolete("Use CompanionInfo.BardingChest")] private byte BardingChest;
    [FieldOffset(0x1B1A), Obsolete("Use CompanionInfo.BardingFeet")] private byte BardingFeet;
    [FieldOffset(0x1B1B), Obsolete("Use CompanionInfo.NameBytes or CompanionInfo.Name for a string")] public fixed byte Name[21];
    [FieldOffset(0x1B30), Obsolete("Use CompanionInfo.CurrentXP")] public uint CurrentXP;
    [FieldOffset(0x1B34), Obsolete("Use CompanionInfo.Rank")] public byte Rank;
    [FieldOffset(0x1B35), Obsolete("Use CompanionInfo.Stars")] public byte Stars;
    [FieldOffset(0x1B36), Obsolete("Use CompanionInfo.SkillPoints")] public byte SkillPoints;
    [FieldOffset(0x1B37), Obsolete("Use CompanionInfo.DefenderLevel")] public byte DefenderLevel;
    [FieldOffset(0x1B38), Obsolete("Use CompanionInfo.AttackerLevel")] public byte AttackerLevel;
    [FieldOffset(0x1B39), Obsolete("Use CompanionInfo.HealerLevel")] public byte HealerLevel;
    [FieldOffset(0x1B3A), Obsolete("Use CompanionInfo.ActiveCommand")] public byte ActiveCommand;
    [FieldOffset(0x1B3B), Obsolete("Use CompanionInfo.FavoriteFeed")] public byte FavoriteFeed;
    [FieldOffset(0x1B3C), Obsolete("Use CompanionInfo.CurrentColorStainId")] public byte CurrentColorStainId;
    [FieldOffset(0x1B3D), Obsolete("Use CompanionInfo.Mounted")] public byte Mounted; // bool
    [FieldOffset(0x1B48)] public PetInfo PetInfo;
    [FieldOffset(0x1B48), Obsolete("Use PetInfo.Pet")] public BuddyMember* PetPtr;
    [FieldOffset(0x1B58)] public DutyHelperInfo DutyHelperInfo;
    [FieldOffset(0x1B58), Obsolete("Use DutyHelperInfo.DutyHelpers")] public BuddyMember* SquadronTrustPtr;

    [Obsolete("Use CompanionInfo.IsBuddyEquipUnlocked")]
    public bool IsBuddyEquipUnlocked(uint buddyEquipId)
        => CompanionInfo.IsBuddyEquipUnlocked(buddyEquipId);
}

// sizes for Info structs are estimated

// Chocobo Companion
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct CompanionInfo {
    [FieldOffset(0)] public Buddy.BuddyMember* Companion;
    [FieldOffset(0x8)] public float TimeLeft;
    [FieldOffset(0xC)] public fixed byte BuddyEquipUnlockBitmask[96 >> 3]; // number of BuddyEquip rows >> 3
    [FieldOffset(0x18)] public byte BardingHead;
    [FieldOffset(0x19)] public byte BardingChest;
    [FieldOffset(0x1A)] public byte BardingFeet;
    [FieldOffset(0x1B), FixedString("Name")] public fixed byte NameBytes[21];
    [FieldOffset(0x30)] public uint CurrentXP;
    [FieldOffset(0x34)] public byte Rank;
    [FieldOffset(0x35)] public byte Stars;
    [FieldOffset(0x36)] public byte SkillPoints;
    [FieldOffset(0x37)] public byte DefenderLevel;
    [FieldOffset(0x38)] public byte AttackerLevel;
    [FieldOffset(0x39)] public byte HealerLevel;
    [FieldOffset(0x3A)] public byte ActiveCommand;
    [FieldOffset(0x3B)] public byte FavoriteFeed;
    [FieldOffset(0x3C)] public byte CurrentColorStainId;
    [FieldOffset(0x3D)] public byte Mounted; // bool

    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 50 02 41 B8")]
    public partial bool IsBuddyEquipUnlocked(uint buddyEquipId);
}

// Carbuncle, Eos/Selene, Machinists Rook Autoturret/Automaton Queen, Whitemages Lilybell, probably more
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct PetInfo {
    [FieldOffset(0)] public Buddy.BuddyMember* Pet;
    [FieldOffset(0x8)] public byte Order; // PetAction RowId
    [FieldOffset(0x9)] public byte Stance; // PetAction RowId
}

// Squadron, Trust, Duty Support
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct DutyHelperInfo {
    [FieldOffset(0)] public Buddy.BuddyMember* DutyHelpers; // 7 members
    [FieldOffset(0x9)] public bool HasHelpers;
    [FieldOffset(0xC)] public fixed uint ENpcIds[7];
}
