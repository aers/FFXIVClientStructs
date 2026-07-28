using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBannerPreview
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("BannerPreview")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonBannerPreview {
    [FieldOffset(0x238)] public AtkComponentPortrait* Portrait;
    [FieldOffset(0x240)] private AtkResNode* Unk240; // I think the "not in frame" warning node
    [FieldOffset(0x248)] public AtkComponentCheckBox* DoNotDisplayAgainCheckbox;
    [FieldOffset(0x250)] private byte Unk250; // "not in frame" state
    [FieldOffset(0x251)] private byte Unk251; // this gates the enabled state for the warning
}
