using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// AddonNamePlate::OnUpdate notes
// uses NumberArrayData index 5, StringArrayData index 4

// NumberArrayData
//  index 0 - int, active nameplate count
//  index 1 - bool, force re-bake of nameplates
//  index 2 - int, nameplate size config (100, 120, 140)
//  index 3 - bool, toggle nameplate text render style (0 = new, 1 = old)
//  index 4 - bool, do full update 
//  index 5-24 repeated 50 times: nameplate specific data

// Client::UI::AddonNamePlate
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x470)]
public unsafe struct AddonNamePlate
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public BakePlateRenderer BakePlate;
    [FieldOffset(0x460)] public NamePlateObject* NamePlateObjectArray; // 0 - 50
    [FieldOffset(0x468)] public byte DoFullUpdate;
    [FieldOffset(0x46A)] public ushort AlternatePartId;

    // Client::UI::AddonNamePlate::BakePlateRenderer
    //   Component::GUI::AtkTextNodeRenderer
    //     Component::GUI::AtkResourceRendererBase
    // might be 238 not 240 but not super relevant here
    [StructLayout(LayoutKind.Explicit, Size = 0x240)]
    public struct BakePlateRenderer
    {
        [FieldOffset(0x230)] public byte DisableFixedFontResolution; // added in 5.5
    }

    // this is the pre-rendered texture data for a nameplate
    // nameplates are 'baked' into a single texture using the BakePlateRenderer
    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct BakeData
    {
        [FieldOffset(0x0)] public short U;
        [FieldOffset(0x2)] public short V;
        [FieldOffset(0x4)] public short Width;
        [FieldOffset(0x6)] public short Height;
        [FieldOffset(0xA)] public byte Alpha;
        [FieldOffset(0xB)] public byte IsBaked;
    }

    public static int NumNamePlateObjects => 50;

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public struct NamePlateObject
    {
        [FieldOffset(0x00)] public BakeData BakeData;
        [FieldOffset(0x10)] public AtkComponentNode* RootNode;
        [FieldOffset(0x18)] public AtkResNode* ResNode;
        [FieldOffset(0x20)] public AtkTextNode* NameText;
        [FieldOffset(0x28)] public AtkImageNode* IconImageNode;
        [FieldOffset(0x30)] public AtkImageNode* ImageNode2;
        [FieldOffset(0x38)] public AtkImageNode* ImageNode3;
        [FieldOffset(0x40)] public AtkImageNode* ImageNode4;
        [FieldOffset(0x48)] public AtkImageNode* ImageNode5;
        [FieldOffset(0x50)] public AtkCollisionNode* CollisionNode1;
        [FieldOffset(0x58)] public AtkCollisionNode* CollisionNode2;
        [FieldOffset(0x60)] public int Priority;
        [FieldOffset(0x64)] public short TextW;
        [FieldOffset(0x66)] public short TextH;
        [FieldOffset(0x68)] public short IconXAdjust;
        [FieldOffset(0x6A)] public short IconYAdjust;
        [FieldOffset(0x6C)] public byte NameplateKind; // not ObjectKind -> needs its own enum
        [FieldOffset(0x6D)] public byte HasHPBar;
        [FieldOffset(0x6E)] public byte ClickThrough;
        [FieldOffset(0x6F)] public byte IsPvpEnemy;
        [FieldOffset(0x70)] public byte NeedsToBeBaked;

        public bool IsVisible => BakeData.IsBaked == 1;

        public bool IsPlayerCharacter => NameplateKind == 0;

        public bool IsLocalPlayer => IsPlayerCharacter && ClickThrough == 1;
    }
}