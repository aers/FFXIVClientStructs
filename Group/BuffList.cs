using FFXIVClientStructs.Client.Game.Character;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Group
{
    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public unsafe struct Buff
    {
        [FieldOffset(0x0)] public ushort StatusID;
        [FieldOffset(0x2)] public ushort UnkParam; // might indicate no-duration buffs? idk
        [FieldOffset(0x4)] public float RemainingTime;
        [FieldOffset(0x8)] public ushort SourceID; // objectID matching the entity that cast the effect - regens will be from the white mage ID etc
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x190)]
    public unsafe struct BuffList
    {
        [FieldOffset(0x0)] public Character* Owner; // THIS IS NULL IN THE PARTY LIST, this class is used elsewhere and the pointer is filled in
        [FieldOffset(0x8)] public fixed byte Buffs[0xC * 30];
        [FieldOffset(0x170)] public uint Unk_170;
        [FieldOffset(0x174)] public ushort Unk_174;
        [FieldOffset(0x178)] public long Unk_178;
        [FieldOffset(0x180)] public byte Unk_180;
    }
}
