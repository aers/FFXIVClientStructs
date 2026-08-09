using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentXBMItem
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 26
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe partial struct AtkComponentXBMItem {
    [FieldOffset(0xC0)] public AtkComponentIcon* IconComponent;
    [FieldOffset(0xC8)] public AtkTextNode* NameTextNode;
    [FieldOffset(0xD0)] public AtkTextNode* TypeTextNode;
    [FieldOffset(0xD8)] public AtkTextNode* DescriptionTextNode;
    [FieldOffset(0xE0)] public Utf8String NameText;
    [FieldOffset(0x148)] public Utf8String TypeText;
    [FieldOffset(0x1B0)] public Utf8String DescriptionText;

    [FieldOffset(0x218)] public uint XBMItemId;
    [FieldOffset(0x21C)] public ushort OriginalDescriptionHeight;
    [FieldOffset(0x21E)] public bool ShowPossessionCount;
    [FieldOffset(0x21F)] public bool ResizeDescriptionToText;
    [FieldOffset(0x220)] public bool IsItemLoaded;
}
