namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentIcon
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 15
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct AtkComponentIcon {
    [FieldOffset(0x00)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC0)] public long IconId;
    [FieldOffset(0xC8)] public AtkUldAsset* Texture;
    [FieldOffset(0xD0)] public AtkResNode* IconAdditionsContainer;
    [FieldOffset(0xD8)] public AtkResNode* ComboBorder;
    [FieldOffset(0xE0)] public AtkResNode* Frame;
    [FieldOffset(0xE8)] public long Unknown0E8;
    [FieldOffset(0xF0)] public AtkImageNode* IconImage;
    [FieldOffset(0xF8)] public AtkImageNode* FrameIcon;
    [FieldOffset(0x100)] public AtkImageNode* UnknownImageNode;
    [FieldOffset(0x108)] public AtkTextNode* QuantityText;
    [FieldOffset(0x114)] public IconComponentFlags Flags;
}

[Flags]
public enum IconComponentFlags : uint {
    None = 0x00,
    DyeIcon = 0x08,
    Macro = 0x10,
    GlamourIcon = 0x20,
    Moving = 0x100,
    Casting = 0x400,
    InventoryItem = 0x800
}
