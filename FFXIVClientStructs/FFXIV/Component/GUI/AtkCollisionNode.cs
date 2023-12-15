using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum CollisionType : ushort {
    Hit = 0x0,
    Focus = 0x1,
    Move = 0x2
}

// Component::GUI::AtkCollisionNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget

// size = 0xB8
// common CreateAtkNode function E8 ?? ?? ?? ?? 48 8B 4E 08 49 8B D5 
// type 8
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkCollisionNode : ICreatable {
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xB0)] public ushort CollisionType;
    [FieldOffset(0xB2)] public ushort Uses;
    [FieldOffset(0xB8)] public AtkComponentBase* LinkedComponent;

    [MemberFunction("E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 5D")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 1E FE C3")]
    public partial bool CheckCollisionAtCoords(int x, int y, bool inclusive);
}
