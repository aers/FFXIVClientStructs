using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI.ULD
{

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct ULDComponentDataInputBase
    {
        [FieldOffset(0x00)] public ULDComponentDataBase Base;
        [FieldOffset(0x0C)] public FFXIVByteColor FocusColor;
    }
}
