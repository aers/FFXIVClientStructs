namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentIcon
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x118
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 15
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct AtkComponentIcon
{
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

    /// <summary>
    /// Sets multiply RGB to 50 if true, 100 if false
    /// </summary>
    /// <param name="disable">true - set multiply RGB to 50 false - set multiply RGB to 100</param>
    /// <returns>*(AtkImageNode + 0xF0)</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 17 B8")]
    public partial nint SetDisabledColor(bool disable);
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