using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonSalvageDialog
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x250)]
    public unsafe struct AddonSalvageDialog
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x228)] public AtkComponentButton* DesynthesizeButton;
        [FieldOffset(0x230)] public AtkComponentCheckBox* CheckBox;
        [FieldOffset(0x240)] public AtkComponentCheckBox* CheckBox2;  // What's this for?
    }
}
