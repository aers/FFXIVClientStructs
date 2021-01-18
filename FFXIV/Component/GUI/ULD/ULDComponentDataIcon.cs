using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{

    [StructLayout(LayoutKind.Explicit, Size = 0x2C)]
    public unsafe struct ULDComponentDataIcon
    {
        [FieldOffset(0x00)] public ULDComponentDataBase Base;
        [FieldOffset(0x0C)] public fixed uint Nodes[8];
    }
}
