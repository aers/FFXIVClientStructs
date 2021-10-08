using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonSelectIconString
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
    public unsafe struct AddonSelectIconString
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x238)] public PopupMenuDerive PopupMenu;

        [StructLayout(LayoutKind.Explicit, Size = 0x68)]
        public struct PopupMenuDerive
        {
            [FieldOffset(0x0)] public PopupMenu PopupMenu;
        }
    }
}