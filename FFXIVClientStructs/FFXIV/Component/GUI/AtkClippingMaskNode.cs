using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkClippingMaskNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 17"
// type 10
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 17", [1, 396])]
public unsafe partial struct AtkClippingMaskNode : ICreatable {
    [FieldOffset(0xB0)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB8)] public ushort PartId;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }
}
