using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTalk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Talk")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xE90)]
public unsafe partial struct AddonTalk {
    [FieldOffset(0x230)] public AtkTextNode* AtkTextNode220;
    [FieldOffset(0x238)] public AtkTextNode* AtkTextNode228;
    [FieldOffset(0x240)] public AtkResNode* AtkResNode230;
    [FieldOffset(0x248)] public AtkTextNode* AtkTextNode238;
    [FieldOffset(0x250)] public AtkTextNode* AtkTextNode240;
    [FieldOffset(0x258)] public AtkTextNode* AtkTextNode248;

    [FieldOffset(0x278)] public Utf8String String268;
    [FieldOffset(0x2E0)] public Utf8String String2D0;
    [FieldOffset(0x348)] public Utf8String String338;
    [FieldOffset(0x418)] public Utf8String String408;
    [FieldOffset(0x480)] public Utf8String String470;
    [FieldOffset(0x4E8)] public Utf8String String4D8;
    [FieldOffset(0x550)] public Utf8String String540;

    // there are 16 more strings here with 0x20 bytes between them
    // might be an array of structs that have Utf8String + other things

    [FieldOffset(0xE28)] public AtkAddonControl AddonControl;
}
