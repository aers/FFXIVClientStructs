namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget

// holds an AtkComponentBase derived class

// size = 0xB8
// common CreateAtkNode function E8 ?? ?? ?? ?? 48 8B 4E 08 49 8B D5 
// type 10xx where xx is the component type
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct AtkComponentNode
{
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xA8)] public AtkComponentBase* Component;
}