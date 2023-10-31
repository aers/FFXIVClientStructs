namespace FFXIVClientStructs.FFXIV.Component.GUI;

// AtkTimelineAnimation but only 1 property
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct AtkTimelineLabelSet {
    [FieldOffset(0x00)] public ushort StartFrameIdx;
    [FieldOffset(0x02)] public ushort EndFrameIdx;
    [FieldOffset(0x08)] public AtkTimelineKeyGroup LabelKeyGroup;
}
