using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonNamePlate
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x460)]
    public unsafe struct AddonNamePlate
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x220)] public BakePlateRenderer BakePlate;
        [FieldOffset(0x450)] public NamePlateObject* NamePlateObjectArray;  // 0 - 50


        // Client::UI::AddonNamePlate::BakePlateRenderer
        //   Component::GUI::AtkTextNodeRenderer
        //     Component::GUI::AtkResourceRendererBase
        [StructLayout(LayoutKind.Explicit, Size = 0x230)]
        public unsafe struct BakePlateRenderer { }

        public static int NumNamePlateObjects => 50;

        [StructLayout(LayoutKind.Explicit, Size = 0x70)]
        public unsafe struct NamePlateObject
        {
            [FieldOffset(0x0)] public AtkComponentNode* ComponentNode;
            [FieldOffset(0x8)] public AtkResNode* ResNode;
            [FieldOffset(0x10)] public AtkTextNode* TextNode10;
            [FieldOffset(0x18)] public AtkImageNode* IconImageNode;
            [FieldOffset(0x20)] public AtkImageNode* ImageNode2;
            [FieldOffset(0x28)] public AtkImageNode* ImageNode3;
            [FieldOffset(0x30)] public AtkImageNode* ImageNode4;
            [FieldOffset(0x38)] public AtkImageNode* ImageNode5;
            [FieldOffset(0x40)] public AtkCollisionNode* CollisionNode1;
            [FieldOffset(0x48)] public AtkCollisionNode* CollisionNode2;
            [FieldOffset(0x50)] public int Layer;
            [FieldOffset(0x54)] public short TextW;
            [FieldOffset(0x56)] public short TextH;
            [FieldOffset(0x58)] public short IconXAdjust;
            [FieldOffset(0x5A)] public short IconYAdjust;
            [FieldOffset(0x5C)] public short UnkType;   // For lack of a better name, it is NOT ObjectKind
            [FieldOffset(0x5E)] public short IsLocalPlayerValue;
            [FieldOffset(0x60)] public byte IsVisibleByte;
            [FieldOffset(0x6A)] public byte ComponentNodeScale;

            public bool IsPlayerCharacter => UnkType == 0;

            public bool IsLocalPlayer => IsLocalPlayerValue == 1;

            public bool IsVisible => IsVisibleByte == 0;
        }
    }
}
