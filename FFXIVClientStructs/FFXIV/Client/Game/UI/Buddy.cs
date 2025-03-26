namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Buddy
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x23FC)]
public unsafe partial struct Buddy {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray9<BuddyMember> _battleBuddies; // BuddyMember array for Companion/Squadron/Trust
    [FieldOffset(0x2370)] public CompanionInfo CompanionInfo;
    [FieldOffset(0x23C0)] public PetInfo PetInfo;
    [FieldOffset(0x23D0)] public DutyHelperInfo DutyHelperInfo;

    [StructLayout(LayoutKind.Explicit, Size = 0x3F0)]
    public struct BuddyMember {
        [FieldOffset(0x0)] public uint EntityId;
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
        [FieldOffset(0xC)] public byte DataId;
        [FieldOffset(0xD)] public byte Synced;
        [FieldOffset(0x10)] public StatusManager StatusManager;
    }
}

// sizes for Info structs are estimated

// Chocobo Companion
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct CompanionInfo {
    [FieldOffset(0)] public Buddy.BuddyMember* Companion;
    [FieldOffset(0x8)] public float TimeLeft;
    [FieldOffset(0xC), FixedSizeArray] internal FixedSizeArray13<byte> _buddyEquipUnlockBitmask; // number of BuddyEquip rows / 8
    [FieldOffset(0x19)] public byte BardingHead;
    [FieldOffset(0x1A)] public byte BardingChest;
    [FieldOffset(0x1B)] public byte BardingFeet;
    [FieldOffset(0x1C), FixedSizeArray(isString: true)] internal FixedSizeArray21<byte> _name;

    [FieldOffset(0x34)] public uint CurrentXP;
    [FieldOffset(0x38)] public byte Rank;
    [FieldOffset(0x39)] public byte Stars;
    [FieldOffset(0x3A)] public byte SkillPoints;
    [FieldOffset(0x3B)] public byte DefenderLevel;
    [FieldOffset(0x3C)] public byte AttackerLevel;
    [FieldOffset(0x3D)] public byte HealerLevel;
    [FieldOffset(0x3E)] public byte ActiveCommand;
    [FieldOffset(0x3F)] public byte FavoriteFeed;
    [FieldOffset(0x40)] public byte CurrentColorStainId;
    [FieldOffset(0x41)] public bool Mounted;

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
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct DutyHelperInfo {
    [FieldOffset(0)] public Buddy.BuddyMember* DutyHelpers; // 7 members
    [FieldOffset(0x9)] public bool HasHelpers;
    [FieldOffset(0xC), FixedSizeArray] internal FixedSizeArray7<uint> _ENpcIds;
}
