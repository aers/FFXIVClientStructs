namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 48 8B 51 08"
// type 10xx where xx is the component type
// holds an AtkComponentBase derived class
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe struct AtkComponentNode {
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xB0)] public AtkComponentBase* Component;
}
