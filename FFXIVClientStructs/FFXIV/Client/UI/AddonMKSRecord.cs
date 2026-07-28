using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMKSRecord
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MKSRecord")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1698)]
public unsafe partial struct AddonMKSRecord {
    [FieldOffset(0x238)] public AtkComponentList* ResultList;
    [FieldOffset(0x248)] private AtkResNode* Unk248;
    [FieldOffset(0x250)] public AtkComponentButton* QuitButton;
    [FieldOffset(0x258)] private AtkComponentButton* Unk258;
}
