namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AtkTimelineResource {
    [FieldOffset(0x00)] public uint Id;
    [FieldOffset(0x04)] public ushort AnimationCount;
    // Never observed to be more than 1
    [FieldOffset(0x06)] public ushort LabelSetCount;
    [FieldOffset(0x08)] public AtkTimelineAnimation* Animations;
    [FieldOffset(0x10)] public AtkTimelineLabelSet* LabelSets;
}
