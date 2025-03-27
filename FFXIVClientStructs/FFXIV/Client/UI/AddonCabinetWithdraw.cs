using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCabinetWithdraw
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CabinetWithdraw")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x63B8)]
public unsafe partial struct AddonCabinetWithdraw {
    [FieldOffset(0x6040)] public AtkComponentRadioButton* ArtifactArmorRadioButton;
    [FieldOffset(0x6048)] public AtkComponentRadioButton* SeasonalGear1RadioButton;
    [FieldOffset(0x6050)] public AtkComponentRadioButton* SeasonalGear2RadioButton;
    [FieldOffset(0x6058)] public AtkComponentRadioButton* SeasonalGear3RadioButton;
    [FieldOffset(0x6060)] public AtkComponentRadioButton* SeasonalGear4RadioButton;
    [FieldOffset(0x6068)] public AtkComponentRadioButton* SeasonalGear5RadioButton;
    [FieldOffset(0x6070)] public AtkComponentRadioButton* AchievementsRadioButton;
    [FieldOffset(0x6078)] public AtkComponentRadioButton* ExclusiveExtrasRadioButton;
    [FieldOffset(0x6080)] public AtkComponentRadioButton* SearchRadioButton;
}
