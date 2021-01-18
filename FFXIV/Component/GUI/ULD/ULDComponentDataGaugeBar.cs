using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{

    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public unsafe struct ULDComponentDataGaugeBar
    {
        [FieldOffset(0x00)] public ULDComponentDataBase Base;
        [FieldOffset(0x0C)] public fixed uint Nodes[6];
        [FieldOffset(0x24)] public ushort MarginV;
        [FieldOffset(0x26)] public ushort MarginH;
        [FieldOffset(0x28)] public byte Vertical;
        [FieldOffset(0x2C)] public int Indicator;
        [FieldOffset(0x30)] public int Min;
        [FieldOffset(0x34)] public int Max;
        [FieldOffset(0x38)] public int Value;
    }
}
