namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// ctor E8 ? ? ? ? 48 89 B3 ? ? ? ? 48 8D 05 ? ? ? ? 48 89 B3 ? ? ? ? 
[StructLayout(LayoutKind.Explicit, Size = 0xED8)]
public unsafe struct Buddy
{
    [StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
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
    [FieldOffset(0x1A0)] public BuddyMember Pet; // bad offset?
    [FieldOffset(0x340)] public fixed byte BattleBuddies[0x198 * 7]; // BuddyMember array for Squadron/Trust
    [FieldOffset(0xE68)] public BuddyMember* CompanionPtr;
    [FieldOffset(0xE70)] public float TimeLeft;
    [FieldOffset(0xE83)] public fixed byte Name[21];
    [FieldOffset(0xE98)] public uint CurrentXP;
    [FieldOffset(0xE9C)] public byte Rank;
    [FieldOffset(0xE9D)] public byte Stars;
    [FieldOffset(0xE9E)] public byte SkillPoints;
    [FieldOffset(0xE9F)] public byte DefenderLevel;
    [FieldOffset(0xEA0)] public byte AttackerLevel;
    [FieldOffset(0xEA1)] public byte HealerLevel;
    [FieldOffset(0xEA2)] public byte ActiveCommand;
    [FieldOffset(0xEA3)] public byte FavoriteFeed;
    [FieldOffset(0xEA4)] public byte CurrentColorStainId;
    [FieldOffset(0xEA5)] public byte Mounted; // bool
    [FieldOffset(0xEB0)] public BuddyMember* PetPtr;
    [FieldOffset(0xEC0)] public BuddyMember* SquadronTrustPtr;
}