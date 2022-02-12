using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTalk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0xE80)]
public unsafe struct AddonTalk
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* AtkTextNode220;
    [FieldOffset(0x228)] public AtkTextNode* AtkTextNode228;
    [FieldOffset(0x230)] public AtkResNode* AtkResNode230;
    [FieldOffset(0x238)] public AtkTextNode* AtkTextNode238;
    [FieldOffset(0x240)] public AtkTextNode* AtkTextNode240;
    [FieldOffset(0x248)] public AtkTextNode* AtkTextNode248;

    [FieldOffset(0x268)] public Utf8String String268;
    [FieldOffset(0x2D0)] public Utf8String String2D0;
    [FieldOffset(0x338)] public Utf8String String338;
    [FieldOffset(0x408)] public Utf8String String408;
    [FieldOffset(0x470)] public Utf8String String470;
    [FieldOffset(0x4D8)] public Utf8String String4D8;
    [FieldOffset(0x540)] public Utf8String String540;

    // there are 16 more strings here with 0x20 bytes between them
    // might be an array of structs that have Utf8String + other things

    [FieldOffset(0xE18)] public AtkEventTarget AtkEventTarget;
    [FieldOffset(0xE20)] public AtkEventListenerUnk1 AtkEventListenerUnk;
}