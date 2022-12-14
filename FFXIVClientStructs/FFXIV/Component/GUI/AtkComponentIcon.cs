namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentIcon
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x118
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 15
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe struct AtkComponentIcon
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0x0C0)] public long IconId;
    [FieldOffset(0x0C8)] public AtkUldAsset* Texture;
    [FieldOffset(0x0D0)] public AtkResNode* IconAdditionsContainer;
    [FieldOffset(0x0D8)] public AtkResNode* ComboBorder;
    [FieldOffset(0x0E0)] public AtkResNode* Frame;
    [FieldOffset(232)] public long Unknown0E8;
    [FieldOffset(0x0F0)] public AtkImageNode* IconImage;
    [FieldOffset(0x0F8)] public AtkImageNode* FrameIcon;
    [FieldOffset(0x100)] public AtkImageNode* UnknownImageNode;
    [FieldOffset(0x108)] public AtkTextNode* QuantityText;
    [FieldOffset(0x114)] public IconComponentFlags Flags;
}

[Flags]
public enum IconComponentFlags : uint
{
    None = 0x00,
    DyeIcon = 0x08,
    Macro = 0x10,
    GlamourIcon = 0x20,
    Moving = 0x100,
    Casting = 0x400,
    InventoryItem = 0x800
}