namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct AtkTimelineLabel {
    [FieldOffset(0x00)] public ushort LabelId;
    [FieldOffset(0x02)] public AtkTimelineJumpBehavior JumpBehavior;
    [FieldOffset(0x03)] public byte JumpLabelId;
}
