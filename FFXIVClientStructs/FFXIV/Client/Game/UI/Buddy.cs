using FFXIVClientStructs.FFXIV.Group;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    [StructLayout(LayoutKind.Explicit, Size = 0x198)]
    public unsafe struct Buddy
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
}
