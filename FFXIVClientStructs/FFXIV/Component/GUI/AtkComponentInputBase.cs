using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentInputBase
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x1D8
// ctor E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 86 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 06 
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe struct AtkComponentInputBase
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC8)] public AtkTextNode* AtkTextNode;
    [FieldOffset(0xE0)] public Utf8String UnkText1;
    [FieldOffset(0x148)] public Utf8String UnkText2;
}