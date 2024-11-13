using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMaterializeDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonMaterializeDialog {
    [FieldOffset(0x238)] public AtkTextNode* Text;
    [FieldOffset(0x240)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x248)] public AtkTextNode* ItemName;
    [FieldOffset(0x250)] public AtkComponentButton* YesButton;
    [FieldOffset(0x258)] public AtkComponentButton* NoButton;
}
