using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonNaviMap
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_NaviMap")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3A90)]
public unsafe partial struct AddonNaviMap {
    [FieldOffset(0x238), Obsolete("Use NaviMap")] public Atk2DMap Atk2DMap;
    [FieldOffset(0x238)] public Atk2DNaviMap NaviMap;

    [FieldOffset(0x1588)] public AtkResNode* PlayerCone;
    [FieldOffset(0x1590)] public AtkCollisionNode* MainCollision;
    [FieldOffset(0x1598)] public AtkResNode* Coords;
    [FieldOffset(0x15A0)] public AtkTextNode* CoordsText;
    [FieldOffset(0x15A8)] public AtkImageNode* Sun;
    [FieldOffset(0x15B0)] public AtkImageNode* WeatherIcon;
    [FieldOffset(0x15B8)] public AtkCollisionNode* WeatherIconCollision;
    [FieldOffset(0x15C0)] public AtkComponentCheckBox* LockNorthCheckbox;
    [FieldOffset(0x15C8)] public AtkComponentButton* ZoomOutButton;
    [FieldOffset(0x15D0)] public AtkComponentButton* ZoomInButton;
    [FieldOffset(0x15D8)] public AtkComponentNode* MapBase;
    [FieldOffset(0x15E0)] public AtkImageNode* MapImage;
    [FieldOffset(0x15E8)] public AtkUldAsset* MapImageAsset;
    [FieldOffset(0x15F0)] public AtkImageNode* Mask;

    [FieldOffset(0x3A78)] public float MarkerPositionScaling; // Same as Atk2DMap.MarkerPositionScaling
    [FieldOffset(0x3A7C)] public short MapTextureWidth;
    [FieldOffset(0x3A7E)] public short MapTextureHeight;

    [FieldOffset(0x38B0)] public AtkRenderTexture RenderTexture;
}
