using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBannerEditor
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 03 E8 ?? ?? ?? ?? 48 8B D0 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? B9"
[Addon("BannerEditor")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonBannerEditor {
    [FieldOffset(0x2E8)] public AtkComponentDropDownList* PresetDropdown;
    [FieldOffset(0x308)] public AtkComponentDropDownList* BackgroundDropdown;
    [FieldOffset(0x328)] public AtkComponentDropDownList* FrameDropdown;
    [FieldOffset(0x348)] public AtkComponentDropDownList* AccentDropdown;
    [FieldOffset(0x368)] public AtkComponentDropDownList* PoseDropdown;
    [FieldOffset(0x388)] public AtkComponentDropDownList* ExpressionDropdown;

    [FieldOffset(0x3C8)] public AtkComponentCheckBox* PlayAnimationCheckbox;
    [FieldOffset(0x3D0)] public AtkComponentCheckBox* HeadFacingCameraCheckbox;
    [FieldOffset(0x3D8)] public AtkComponentCheckBox* EyesFacingCameraCheckbox;

    [FieldOffset(0x408)] public AtkComponentButton* ApplyEquipmentButton;
    [FieldOffset(0x410)] public AtkComponentButton* SaveButton;
    [FieldOffset(0x418)] public AtkComponentButton* CloseButton;

    [FieldOffset(0x420)] public AtkComponentSlider* AmbientLightingColorRedSlider;
    [FieldOffset(0x428)] public AtkComponentSlider* AmbientLightingColorGreenSlider;
    [FieldOffset(0x430)] public AtkComponentSlider* AmbientLightingColorBlueSlider;
    [FieldOffset(0x438)] public AtkComponentSlider* AmbientLightingBrightnessSlider;
    [FieldOffset(0x440)] public AtkComponentSlider* DirectionalLightingColorRedSlider;
    [FieldOffset(0x448)] public AtkComponentSlider* DirectionalLightingColorGreenSlider;
    [FieldOffset(0x450)] public AtkComponentSlider* DirectionalLightingColorBlueSlider;
    [FieldOffset(0x458)] public AtkComponentSlider* DirectionalLightingBrightnessSlider;
    [FieldOffset(0x460)] public AtkComponentSlider* DirectionalLightingVerticalAngleSlider;
    [FieldOffset(0x468)] public AtkComponentSlider* DirectionalLightingHorizontalAngleSlider;
    [FieldOffset(0x470)] public AtkComponentSlider* CameraZoomSlider;
    [FieldOffset(0x478)] public AtkComponentSlider* ImageRotation;

    [FieldOffset(0x4D0)] public AtkResNode* WarningSymbol;

    [FieldOffset(0x4DC)] public short NumPresets;

    [FieldOffset(0x4F3)] public bool IsWarningSymbolShown;
}
