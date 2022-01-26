using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AddonContextMenu
    {
        [FieldOffset(0x0)] public unsafe AddonInterface AddonInterface;
        [FieldOffset(0x160)] public unsafe AtkValue* AtkValues;
        [FieldOffset(0x1CA)] public ushort AtkValuesCount;
        [FieldOffset(0x690)] public bool IsInitialMenu;
    }
}
