using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBannerEditor
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("BannerEditor")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xB48)]
public unsafe partial struct AddonBannerEditor {
    [FieldOffset(0x238)] public PreviewController PreviewController;
    /// <remarks> [0] Preset, [1] Background, [2] Frame, [3] Accent, [4] Pose, [5] Expression </remarks>
    [FieldOffset(0x2F0), FixedSizeArray] internal FixedSizeArray6<DropdownEntry> _dropdowns;
    [FieldOffset(0x2F0), Obsolete("Use Dropdowns[0].Dropdown")] public AtkComponentDropDownList* PresetDropdown;
    [FieldOffset(0x310), Obsolete("Use Dropdowns[1].Dropdown")] public AtkComponentDropDownList* BackgroundDropdown;
    [FieldOffset(0x330), Obsolete("Use Dropdowns[2].Dropdown")] public AtkComponentDropDownList* FrameDropdown;
    [FieldOffset(0x350), Obsolete("Use Dropdowns[3].Dropdown")] public AtkComponentDropDownList* AccentDropdown;
    [FieldOffset(0x370), Obsolete("Use Dropdowns[4].Dropdown")] public AtkComponentDropDownList* PoseDropdown;
    [FieldOffset(0x390), Obsolete("Use Dropdowns[5].Dropdown")] public AtkComponentDropDownList* ExpressionDropdown;

    [FieldOffset(0x3D0), FixedSizeArray] internal FixedSizeArray15<Utf8String> _filterNames;
    [FieldOffset(0x9E8)] public AtkComponentCheckBox* PlayAnimationCheckbox;
    [FieldOffset(0x9F0)] public AtkComponentCheckBox* HeadFacingCameraCheckbox;
    [FieldOffset(0x9F8)] public AtkComponentCheckBox* EyesFacingCameraCheckbox;
    [FieldOffset(0xA00)] public AtkComponentButton* ResetCameraButton;
    [FieldOffset(0xA08)] public AtkComponentButton* ResetHeadDirectionButton;
    [FieldOffset(0xA10)] public AtkComponentButton* ResetEyesDirectionButton;
    [FieldOffset(0xA28)] public AtkComponentButton* SaveButton;
    [FieldOffset(0xA30)] public AtkComponentButton* CloseButton;
    [FieldOffset(0xA38)] public AtkComponentButton* ApplyEquipmentButton;
    [FieldOffset(0xA40)] public AtkComponentSlider* AmbientLightingColorRedSlider;
    [FieldOffset(0xA48)] public AtkComponentSlider* AmbientLightingColorGreenSlider;
    [FieldOffset(0xA50)] public AtkComponentSlider* AmbientLightingColorBlueSlider;
    [FieldOffset(0xA58)] public AtkComponentSlider* AmbientLightingBrightnessSlider;
    [FieldOffset(0xA60)] public AtkComponentSlider* DirectionalLightingColorRedSlider;
    [FieldOffset(0xA68)] public AtkComponentSlider* DirectionalLightingColorGreenSlider;
    [FieldOffset(0xA70)] public AtkComponentSlider* DirectionalLightingColorBlueSlider;
    [FieldOffset(0xA78)] public AtkComponentSlider* DirectionalLightingBrightnessSlider;
    [FieldOffset(0xA80)] public AtkComponentSlider* DirectionalLightingVerticalAngleSlider;
    [FieldOffset(0xA88)] public AtkComponentSlider* DirectionalLightingHorizontalAngleSlider;
    [FieldOffset(0xA90)] public AtkComponentSlider* CameraZoomSlider;
    [FieldOffset(0xA98)] public AtkComponentSlider* ImageRotation;

    [FieldOffset(0xAF0)] public AtkResNode* WarningSymbol;

    [FieldOffset(0xB28)] public short NumPresets;

    [FieldOffset(0xB43)] public bool IsWarningSymbolShown;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct DropdownEntry {
        [FieldOffset(0x00)] public AtkComponentDropDownList* Dropdown;
        [FieldOffset(0x08)] public AtkComponentButton* PrevButton;
        [FieldOffset(0x10)] public AtkComponentButton* NextButton;
        [FieldOffset(0x18)] public AtkComponentButton* ListButton;
    }
}
