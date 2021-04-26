using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // this type is used to store data of a bunch of different kinds
    // the enum is not exhaustive, just the ones I care about so far
    public enum ValueType
    {
        Int = 0x3,
        UInt = 0x4,
        String = 0x6
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct AtkValue
    {
        [FieldOffset(0x0)] public ValueType Type;
        // union field
        [FieldOffset(0x8)] public int Int;
        [FieldOffset(0x8)] public uint UInt;
        [FieldOffset(0x8)] public byte* String; // char*
    }
}