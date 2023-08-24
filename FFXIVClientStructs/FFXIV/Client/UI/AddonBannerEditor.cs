using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 03 E8 ?? ?? ?? ?? 48 8B D0 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? B9"
[Addon("BannerEditor")]
[StructLayout(LayoutKind.Explicit, Size = 0x4E8)]
public unsafe struct AddonBannerEditor {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2D8)] public AtkComponentDropDownList* PresetDropdown;
    [FieldOffset(0x2F8)] public AtkComponentDropDownList* BackgroundDropdown;
    [FieldOffset(0x318)] public AtkComponentDropDownList* FrameDropdown;
    [FieldOffset(0x338)] public AtkComponentDropDownList* AccentDropdown;
    [FieldOffset(0x358)] public AtkComponentDropDownList* PoseDropdown;
    [FieldOffset(0x378)] public AtkComponentDropDownList* ExpressionDropdown;

    [FieldOffset(0x3B8)] public AtkComponentCheckBox* PlayAnimationCheckbox;
    [FieldOffset(0x3C0)] public AtkComponentCheckBox* HeadFacingCameraCheckbox;
    [FieldOffset(0x3C8)] public AtkComponentCheckBox* EyesFacingCameraCheckbox;

    [FieldOffset(0x3F8)] public AtkComponentButton* ApplyEquipmentButton;
    [FieldOffset(0x400)] public AtkComponentButton* SaveButton;
    [FieldOffset(0x408)] public AtkComponentButton* CloseButton;

    [FieldOffset(0x410)] public AtkComponentSlider* AmbientLightingColorRedSlider;
    [FieldOffset(0x418)] public AtkComponentSlider* AmbientLightingColorGreenSlider;
    [FieldOffset(0x420)] public AtkComponentSlider* AmbientLightingColorBlueSlider;
    [FieldOffset(0x428)] public AtkComponentSlider* AmbientLightingBrightnessSlider;
    [FieldOffset(0x430)] public AtkComponentSlider* DirectionalLightingColorRedSlider;
    [FieldOffset(0x438)] public AtkComponentSlider* DirectionalLightingColorGreenSlider;
    [FieldOffset(0x440)] public AtkComponentSlider* DirectionalLightingColorBlueSlider;
    [FieldOffset(0x448)] public AtkComponentSlider* DirectionalLightingBrightnessSlider;
    [FieldOffset(0x450)] public AtkComponentSlider* DirectionalLightingVerticalAngleSlider;
    [FieldOffset(0x458)] public AtkComponentSlider* DirectionalLightingHorizontalAngleSlider;
    [FieldOffset(0x460)] public AtkComponentSlider* CameraZoomSlider;
    [FieldOffset(0x468)] public AtkComponentSlider* ImageRotation;

    [FieldOffset(0x4C0)] public AtkResNode* WarningSymbol;

    [FieldOffset(0x4CC)] public short NumPresets;

    [FieldOffset(0x4E3)] public bool IsWarningSymbolShown;
}
