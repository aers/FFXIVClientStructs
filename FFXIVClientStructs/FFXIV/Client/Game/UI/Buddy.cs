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

        // Chocobo: Mount
        // Pet: Pet (summons)
        // Squadron: Unused
        // Trust: DawnGrowMember
        [FieldOffset(0xC)] public byte DataID;
        [FieldOffset(0xD)] public byte Synced;
        [FieldOffset(0x10)] public StatusManager StatusManager;
    }

    [FieldOffset(0x0)] public BuddyMember Companion; // Chocobo Companion
    [FieldOffset(0x300)] public BuddyMember Pet; // Carbuncle, Eos/Selene, Machinists Rook Autoturret/Automaton Queen, Whitemages Lilybell, probably more
    [FixedSizeArray<BuddyMember>(7)]
    [FieldOffset(0x600)] public fixed byte BattleBuddies[0x300 * 7]; // BuddyMember array for Squadron/Trust
    [FieldOffset(0x1B00)] public BuddyMember* CompanionPtr;
    [FieldOffset(0x1B08)] public float TimeLeft;
    [FieldOffset(0x1B0C)] private fixed byte BuddyEquipUnlockBitmask[96 >> 3]; // number of BuddyEquip rows >> 3
    [FieldOffset(0x1B18)] private byte BardingHead;
    [FieldOffset(0x1B19)] private byte BardingChest;
    [FieldOffset(0x1B1A)] private byte BardingFeet;
    [FieldOffset(0x1B1B)] public fixed byte Name[21];
    [FieldOffset(0x1B30)] public uint CurrentXP;
    [FieldOffset(0x1B34)] public byte Rank;
    [FieldOffset(0x1B35)] public byte Stars;
    [FieldOffset(0x1B36)] public byte SkillPoints;
    [FieldOffset(0x1B37)] public byte DefenderLevel;
    [FieldOffset(0x1B38)] public byte AttackerLevel;
    [FieldOffset(0x1B39)] public byte HealerLevel;
    [FieldOffset(0x1B3A)] public byte ActiveCommand;
    [FieldOffset(0x1B3B)] public byte FavoriteFeed;
    [FieldOffset(0x1B3C)] public byte CurrentColorStainId;
    [FieldOffset(0x1B3D)] public byte Mounted; // bool
    [FieldOffset(0x1B48)] public BuddyMember* PetPtr;
    [FieldOffset(0x1B58)] public BuddyMember* SquadronTrustPtr;

    public bool IsBuddyEquipUnlocked(uint buddyEquipId) {
        fixed (BuddyMember** ptr = &CompanionPtr)
            return IsBuddyEquipUnlockedInternal(ptr, buddyEquipId);
    }

    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 50 02 41 B8")]
    private static partial bool IsBuddyEquipUnlockedInternal(BuddyMember** companionPtr, uint buddyEquipId);
}
