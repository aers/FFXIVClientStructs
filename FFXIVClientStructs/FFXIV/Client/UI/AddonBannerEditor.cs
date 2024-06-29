using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBannerEditor
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 03 E8 ?? ?? ?? ?? 48 8B D0 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 ED 48 8D BB"
[Addon("BannerEditor")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xB40)]
public unsafe partial struct AddonBannerEditor {
    [FieldOffset(0x2E8)] public AtkComponentDropDownList* PresetDropdown;
    [FieldOffset(0x308)] public AtkComponentDropDownList* BackgroundDropdown;
    [FieldOffset(0x328)] public AtkComponentDropDownList* FrameDropdown;
    [FieldOffset(0x348)] public AtkComponentDropDownList* AccentDropdown;
    [FieldOffset(0x368)] public AtkComponentDropDownList* PoseDropdown;
    [FieldOffset(0x388)] public AtkComponentDropDownList* ExpressionDropdown;

    [FieldOffset(0x3C8), FixedSizeArray] internal FixedSizeArray15<Utf8String> _filterNames;
    [FieldOffset(0x9E0)] public AtkComponentCheckBox* PlayAnimationCheckbox;
    [FieldOffset(0x9E8)] public AtkComponentCheckBox* HeadFacingCameraCheckbox;
    [FieldOffset(0x9F0)] public AtkComponentCheckBox* EyesFacingCameraCheckbox;
    [FieldOffset(0x9F8)] public AtkComponentButton* ResetCameraButton;
    [FieldOffset(0xA00)] public AtkComponentButton* ResetHeadDirectionButton;
    [FieldOffset(0xA08)] public AtkComponentButton* ResetEyesDirectionButton;
    [FieldOffset(0xA20)] public AtkComponentButton* SaveButton;
    [FieldOffset(0xA28)] public AtkComponentButton* CloseButton;
    [FieldOffset(0xA30)] public AtkComponentButton* ApplyEquipmentButton;
    [FieldOffset(0xA38)] public AtkComponentSlider* AmbientLightingColorRedSlider;
    [FieldOffset(0xA40)] public AtkComponentSlider* AmbientLightingColorGreenSlider;
    [FieldOffset(0xA48)] public AtkComponentSlider* AmbientLightingColorBlueSlider;
    [FieldOffset(0xA50)] public AtkComponentSlider* AmbientLightingBrightnessSlider;
    [FieldOffset(0xA58)] public AtkComponentSlider* DirectionalLightingColorRedSlider;
    [FieldOffset(0xA60)] public AtkComponentSlider* DirectionalLightingColorGreenSlider;
    [FieldOffset(0xA68)] public AtkComponentSlider* DirectionalLightingColorBlueSlider;
    [FieldOffset(0xA70)] public AtkComponentSlider* DirectionalLightingBrightnessSlider;
    [FieldOffset(0xA78)] public AtkComponentSlider* DirectionalLightingVerticalAngleSlider;
    [FieldOffset(0xA80)] public AtkComponentSlider* DirectionalLightingHorizontalAngleSlider;
    [FieldOffset(0xA89)] public AtkComponentSlider* CameraZoomSlider;
    [FieldOffset(0xA90)] public AtkComponentSlider* ImageRotation;

    [FieldOffset(0xAE8)] public AtkResNode* WarningSymbol;

    [FieldOffset(0xB20)] public short NumPresets;

    [FieldOffset(0xB3B)] public bool IsWarningSymbolShown;
}
