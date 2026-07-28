using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFrontlineRecord
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FrontlineRecord")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x14F0)]
public unsafe partial struct AddonFrontlineRecord {
    [FieldOffset(0x248)] private AtkTextNode* Unk248;
    [FieldOffset(0x250)] public AtkComponentButton* LeaveButton;
}
