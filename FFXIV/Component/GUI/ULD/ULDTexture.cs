using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct ULDTexture
    {
        [FieldOffset(0x0)] public uint Id;
        [FieldOffset(0x8)] public AtkTexture AtkTexture;
    }
}
