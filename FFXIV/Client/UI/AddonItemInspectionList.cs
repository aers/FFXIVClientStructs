using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonItemInspectionList
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x1230)]
    public unsafe struct AddonItemInspectionList
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    }
}
