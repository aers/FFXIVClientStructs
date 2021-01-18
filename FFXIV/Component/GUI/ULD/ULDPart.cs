using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct ULDPart
    {
        [FieldOffset(0x0)] public ULDTexture* ULDTexture; // union ID+texture pointer replaced by loader
        [FieldOffset(0x8)] public ushort U;
        [FieldOffset(0xA)] public ushort V;
        [FieldOffset(0xC)] public ushort Width;
        [FieldOffset(0xE)] public ushort Height;
    }
}
