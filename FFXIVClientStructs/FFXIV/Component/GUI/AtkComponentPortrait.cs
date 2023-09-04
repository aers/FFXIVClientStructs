namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct AtkComponentPortrait {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC0)] public AtkImageNode* CharacterImageNode;
    [FieldOffset(0xC8)] public AtkImageNode* FrameImageNode;
    [FieldOffset(0xD0)] public AtkImageNode* AccentImageNode;
    [FieldOffset(0xD8)] public AtkCollisionNode* CollisionNode;
    // [FieldOffset(0xE0)] public byte UnkE0;
}
