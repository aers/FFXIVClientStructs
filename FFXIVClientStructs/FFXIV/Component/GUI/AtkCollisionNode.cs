using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkCollisionNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13"
// type 8
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkCollisionNode : ICreatable {
    [FieldOffset(0xB0)] public ushort CollisionType;
    [FieldOffset(0xB2)] public ushort Uses;
    [FieldOffset(0xB8)] public AtkComponentBase* LinkedComponent;

    [MemberFunction("E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 5D")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 48 32 DB")]
    public partial bool CheckCollisionAtCoords(short x, short y, bool inclusive);
}

public enum CollisionType : ushort {
    Hit = 0x0,
    Focus = 0x1,
    Move = 0x2
}
