using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe struct ULDComponentDataTextNineGrid
    {
        [FieldOffset(0x00)] public ULDComponentDataBase Base;
        [FieldOffset(0x0C)] public fixed uint Nodes[2];
        [FieldOffset(0x14)] public uint TextId;
    }
}
