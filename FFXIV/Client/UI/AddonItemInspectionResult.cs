using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonItemInspectionResult
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
    public unsafe struct AddonItemInspectionResult
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    }
}
