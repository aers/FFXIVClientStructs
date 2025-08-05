using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkCollisionNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 ?? 0F B7 CD"
// type 8
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 ?? 0F B7 CD", [1, 339])]
public unsafe partial struct AtkCollisionNode : ICreatable {
    [FieldOffset(0xB0)] public CollisionType CollisionType;
    [FieldOffset(0xB2)] public ushort Uses;
    [FieldOffset(0xB8)] public AtkComponentBase* LinkedComponent;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }
}

public enum CollisionType : ushort {
    Hit = 0x0,
    Focus = 0x1,
    Move = 0x2
}
