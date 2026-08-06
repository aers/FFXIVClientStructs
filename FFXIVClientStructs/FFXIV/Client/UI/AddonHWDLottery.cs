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
    [FieldOffset(0x408)] private byte Unk408; // some ready flag or something
    [FieldOffset(0x40C)] private int Unk40C; // animation state?
    [FieldOffset(0x410)] public byte Stage; // AtkValues[32]; 2 = revealing, 3 = finished
    [FieldOffset(0x411)] public byte SelectedIndex; // 0-4
    [FieldOffset(0x412)] private byte Unk412; // AtkValues[33 + SelectedIndex] result I think
    [FieldOffset(0x418)] private AtkCounterNode* Unk418;
}
