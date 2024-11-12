using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentIcon
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 15
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct AtkComponentIcon : ICreatable {
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

    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 51 08 48 8D 05 ?? ?? ?? ?? 48 89 51 10 48 89 51 18 48 89 51 20 48 89 51 28 48 89 51 30 48 89 51 38 48 89 51 40 89 51 48 48 89 51 50 48 89 51 58 48 89 51 60 48 89 51 68 89 51 70 48 89 51 78 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 66 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 88 91 ?? ?? ?? ?? 48 89 01 48 8B C1 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ??")]
    public partial void Ctor();
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
