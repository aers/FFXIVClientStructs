using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game
{
    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct Status
    {
        [FieldOffset(0x0)] public ushort StatusID;
        [FieldOffset(0x2)] public byte StackCount;
        [FieldOffset(0x3)] public byte Param;
        [FieldOffset(0x4)] public float RemainingTime;
        // objectID matching the entity that cast the effect - regens will be from the white mage ID etc
        [FieldOffset(0x8)] public uint SourceID; 
    }
}
