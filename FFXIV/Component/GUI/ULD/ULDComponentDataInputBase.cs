using FFXIVClientStructs.FFXIV;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct ULDComponentDataInputBase
    {
        [FieldOffset(0x00)] public ULDComponentDataBase Base;
        [FieldOffset(0x0C)] public ByteColor FocusColor;
    }
}
