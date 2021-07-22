using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    // ctor E8 ? ? ? ? 48 89 B3 ? ? ? ? 48 8D 05 ? ? ? ? 48 89 B3 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0x860)]
    public unsafe struct Buddy
    {
        [StructLayout(LayoutKind.Explicit, Size = 0x198)]
        public unsafe struct BuddyMember
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
        [FieldOffset(0x330)] public fixed byte BattleBuddies[0x198 * 3]; // BuddyMember array for Squadron/Trust
        [FieldOffset(0x7F8)] public BuddyMember* CompanionPtr;
        [FieldOffset(0x800)] public float TimeLeft;
        [FieldOffset(0x812)] public fixed byte Name[21];
        [FieldOffset(0x828)] public uint CurrentXP;
        [FieldOffset(0x82A)] public byte Rank;
        [FieldOffset(0x82B)] public byte Stars;
        [FieldOffset(0x82C)] public byte SkillPoints;
        [FieldOffset(0x82D)] public byte DefenderLevel;
        [FieldOffset(0x82E)] public byte AttackerLevel;
        [FieldOffset(0x82F)] public byte HealerLevel;
        [FieldOffset(0x830)] public byte ActiveCommand;
        [FieldOffset(0x831)] public byte FavoriteFeed;
        [FieldOffset(0x832)] public byte CurrentColorStainId;
        [FieldOffset(0x833)] public byte Mounted; // bool
        [FieldOffset(0x840)] public BuddyMember* PetPtr;
        [FieldOffset(0x850)] public BuddyMember* SquadronTrustPtr;
    }
}
