namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13"
// type 10xx where xx is the component type
// holds an AtkComponentBase derived class
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13", [1, 457])]
public unsafe partial struct AtkComponentNode {
    [FieldOffset(0xB0)] public AtkComponentBase* Component;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }
}
