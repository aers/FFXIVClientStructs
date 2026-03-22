using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAreaMap
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AreaMap")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x7E0)]
public unsafe partial struct AddonAreaMap {
    [FieldOffset(0x238)] private AtkResNode* ContainerNode; // Same as RootNode 
    [FieldOffset(0x240)] public AtkComponentMap* ComponentMap;
    [FieldOffset(0x258)] public AtkComponentButton* WorldMapButton;
    [FieldOffset(0x260)] public AtkComponentButton* ZoomInButton;
    [FieldOffset(0x268)] public AtkComponentButton* ZoomOutButton;
    [FieldOffset(0x270)] public AtkComponentButton* MapUpButton; // Opens parent map/region/world map
    [FieldOffset(0x278)] public AtkComponentCheckBox* ShowMapMarkersCheckbox;
    [FieldOffset(0x280)] public AtkComponentCheckBox* ShowMapTextCheckbox;
    [FieldOffset(0x288)] public AtkComponentCheckBox* FollowPlayerCheckbox;
    [FieldOffset(0x290)] public AtkComponentCheckBox* FadeWhenUnfocusedCheckbox;
    [FieldOffset(0x298)] public AtkComponentCheckBox* LockMapCheckbox; // Prevents closing map with esc
    [FieldOffset(0x2A0)] public AtkComponentSlider* ZoomSlider;
    [FieldOffset(0x2A8)] public AtkResNode* LocationContainerNode;
    [FieldOffset(0x2B0)] public AtkComponentDropDownList* RegionDropDownList;
    [FieldOffset(0x2B8)] public AtkComponentDropDownList* TerritoryDropDownList;
    [FieldOffset(0x2C0)] public AtkTextNode* AreaTextNode;
    [FieldOffset(0x2C8)] public AtkTextNode* SubAreaTextNode;
    [FieldOffset(0x2D0)] public AtkResNode* LayerSelectionContainerNode;
    [FieldOffset(0x2D8), FixedSizeArray] internal FixedSizeArray16<Pointer<AtkComponentRadioButton>> _worldRadioButtons;
    [FieldOffset(0x358)] public AtkResNode* CurrentPositionContainerNode;
    [FieldOffset(0x360)] public AtkTextNode* CurrentPositionTextNode;
    [FieldOffset(0x368)] public AtkResNode* CursorPositionContainerNode;
    [FieldOffset(0x370)] public AtkTextNode* CursorPositionTextNode;
    [FieldOffset(0x378)] public AtkComponentButton* CloseButton;
    [FieldOffset(0x380)] public AtkComponentButton* ResizeButton;
    [FieldOffset(0x388)] public AtkResNode* TitleContainerNode;
    [FieldOffset(0x390)] public AtkTextNode* TitleTextNode;
    [FieldOffset(0x398)] public AtkImageNode* CrosshairImageNode;
    [FieldOffset(0x3A0)] public AtkNineGridNode* LocationBackgroundNode;
    [FieldOffset(0x3A8)] public Atk2DAreaMap AreaMap;

    [FieldOffset(0x7B0)] public ushort MouseXInteger;
    [FieldOffset(0x7B2)] public ushort MouseXDecimal;
    [FieldOffset(0x7B4)] public ushort MouseYInteger;
    [FieldOffset(0x7B6)] public ushort MouseYDecimal;

    public Vector2 MouseCoords => new(MouseXInteger + MouseXDecimal / 100f, MouseYInteger + MouseYDecimal / 100f);
}
