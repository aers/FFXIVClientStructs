namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// ctor E8 ?? ?? ?? ?? 48 89 B3 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 B3 ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0xED8)]
public unsafe partial struct Buddy
{
    [StructLayout(LayoutKind.Explicit, Size = 0x198)]
    public struct BuddyMember
    {
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

    [FieldOffset(0x0)] public BuddyMember Companion;
    [FieldOffset(0x198)] public BuddyMember Pet;
    [FixedSizeArray<BuddyMember>(7)]
    [FieldOffset(0x330)] public fixed byte BattleBuddies[0x198 * 7]; // BuddyMember array for Squadron/Trust
    [FieldOffset(0xE58)] public BuddyMember* CompanionPtr;
    [FieldOffset(0xE58)] private fixed byte BuddyEquipUnlock[1];
    [FieldOffset(0xE60)] public float TimeLeft;
    [FieldOffset(0xE73)] public fixed byte Name[21];
    [FieldOffset(0xE88)] public uint CurrentXP;
    [FieldOffset(0xE8C)] public byte Rank;
    [FieldOffset(0xE8D)] public byte Stars;
    [FieldOffset(0xE8E)] public byte SkillPoints;
    [FieldOffset(0xE8F)] public byte DefenderLevel;
    [FieldOffset(0xE90)] public byte AttackerLevel;
    [FieldOffset(0xE91)] public byte HealerLevel;
    [FieldOffset(0xE92)] public byte ActiveCommand;
    [FieldOffset(0xE93)] public byte FavoriteFeed;
    [FieldOffset(0xE94)] public byte CurrentColorStainId;
    [FieldOffset(0xE95)] public byte Mounted; // bool
    [FieldOffset(0xEA0)] public BuddyMember* PetPtr;
    [FieldOffset(0xEB0)] public BuddyMember* SquadronTrustPtr;

    public bool IsBuddyEquipUnlocked(uint buddyEquipId) {
        fixed(byte* p = BuddyEquipUnlock) {
            return IsBuddyEquipUnlockedInternal(p, buddyEquipId);
        }
    }
    
    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 50 02 41 B8")]
    private static partial bool IsBuddyEquipUnlockedInternal(void* ptr, uint buddyEquipId);
}
