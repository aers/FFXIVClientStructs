using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMaterializeDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe struct AddonMaterializeDialog
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* Text;
    [FieldOffset(0x228)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x230)] public AtkTextNode* ItemName;
    [FieldOffset(0x238)] public AtkComponentButton* YesButton;
    [FieldOffset(0x240)] public AtkComponentButton* NoButton;
}