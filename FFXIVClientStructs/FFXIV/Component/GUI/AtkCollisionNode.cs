using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum CollisionType : ushort
{
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
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct AtkCollisionNode : ICreatable
{
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xA8)] public ushort CollisionType;
    [FieldOffset(0xAA)] public ushort Uses;
    [FieldOffset(0xB0)] public AtkComponentBase* LinkedComponent;

    [MemberFunction("E9 ?? ?? ?? ?? 81 FB ?? ?? ?? ?? 72 24")]
    public partial void Ctor();
}