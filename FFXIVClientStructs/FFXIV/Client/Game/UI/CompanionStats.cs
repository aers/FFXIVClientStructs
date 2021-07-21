using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public unsafe struct CompanionStats
    {
        [FieldOffset(0x0)] public Buddy* Companion;
        [FieldOffset(0x08)] public float TimeLeft;
        [FieldOffset(0x1A)] public fixed byte Name[20];  // 22?
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
    }
}
