using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonHWDLottery
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("HWDLottery")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
public unsafe partial struct AddonHWDLottery {
    [FieldOffset(0x3F8)] private AtkImageNode* Unk3F8;
    [FieldOffset(0x400)] public AtkComponentButton* CloseButton;
    [FieldOffset(0x418)] private AtkCounterNode* Unk418;
}
