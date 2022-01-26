using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct AddonInterface
    {
        [FieldOffset(0x8)] public byte Name;
        [FieldOffset(0x1D2)] public ushort ParentAddonId;
    }
}
