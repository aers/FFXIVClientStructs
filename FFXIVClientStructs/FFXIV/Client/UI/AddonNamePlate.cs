using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonNamePlate
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("NamePlate")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x490)]
public unsafe partial struct AddonNamePlate {
    [FieldOffset(0x240)] public BakePlateRenderer BakePlate;
    [FieldOffset(0x480)] public NamePlateObject* NamePlateObjectArray; // 0 - 50
    [FieldOffset(0x488)] public byte DoFullUpdate;
    [FieldOffset(0x48A)] public ushort AlternatePartId;

    // Client::UI::AddonNamePlate::BakePlateRenderer
    //   Component::GUI::AtkTextNodeRenderer
    //     Component::GUI::AtkResourceRendererBase
    // might be 238 not 240 but not super relevant here
    [StructLayout(LayoutKind.Explicit, Size = 0x240)]
    public struct BakePlateRenderer {
        [FieldOffset(0x230)] public byte DisableFixedFontResolution; // added in 5.5
    }

    // this is the pre-rendered texture data for a nameplate
    // nameplates are 'baked' into a single texture using the BakePlateRenderer
    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct BakeData {
        [FieldOffset(0x0)] public short U;
        [FieldOffset(0x2)] public short V;
        [FieldOffset(0x4)] public short Width;
        [FieldOffset(0x6)] public short Height;
        [FieldOffset(0xA)] public byte Alpha;
        [FieldOffset(0xB)] public byte IsBaked;
    }

    public static int NumNamePlateObjects => 50;

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public struct NamePlateObject {
        [FieldOffset(0x00)] public BakeData BakeData;
        [FieldOffset(0x10)] public AtkComponentNode* RootComponentNode;
        [FieldOffset(0x18)] public AtkResNode* NameContainer;
        [FieldOffset(0x20)] public AtkTextNode* NameText;
        [FieldOffset(0x28)] public AtkImageNode* NameIcon;
        [FieldOffset(0x30)] public AtkImageNode* MarkerIcon;
        [FieldOffset(0x38)] public AtkImageNode* GaugeBackground;
        [FieldOffset(0x40)] public AtkImageNode* GaugeFill;
        [FieldOffset(0x48)] public AtkImageNode* GaugeContainer;
        [FieldOffset(0x50)] public AtkCollisionNode* NameplateCollision;
        [FieldOffset(0x58)] public AtkCollisionNode* MarkerCollision;
        [FieldOffset(0x60)] public int Priority;
        [FieldOffset(0x64)] public short TextW;
        [FieldOffset(0x66)] public short TextH;
        [FieldOffset(0x68)] public short IconXAdjust;
        [FieldOffset(0x6A)] public short IconYAdjust;
        [FieldOffset(0x6C)] public UIObjectKind NamePlateKind;
        [FieldOffset(0x6D)] public byte HPLabelState;
        [FieldOffset(0x6E)] public bool ClickThrough;
        [FieldOffset(0x6F)] public bool IsPvpEnemy;
        // [FieldOffset(0x70)] public bool UnkBool;
        [FieldOffset(0x71)] public bool NeedsToBeBaked;
        // [FieldOffset(0x72)] public int UnkBakeState;
        public bool IsVisible => RootComponentNode->IsVisible();

        public bool IsPlayerCharacter => NamePlateKind == UIObjectKind.PlayerCharacter;

        public bool IsLocalPlayer => IsPlayerCharacter && ClickThrough;
    }
}
