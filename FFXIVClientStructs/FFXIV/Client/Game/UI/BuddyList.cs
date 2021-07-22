using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    // This is a guess, need to find the ctor/dtor
    [StructLayout(LayoutKind.Explicit, Size = 0x7F8)]
    public unsafe struct BuddyList
    {
        [FieldOffset(0x0)] public Buddy Companion;
        [FieldOffset(0x198)] public Buddy Pet;
        [FieldOffset(0x330)] public fixed byte BattleBuddies[0x198 * 3];
    }
}
