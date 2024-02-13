namespace FFXIVClientStructs.FFXIV.Component.GUI;

// ctor inlined "E8 ?? ?? ?? ?? 48 8B CD E8 ?? ?? ?? ?? 48 8B CF"
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct AtkTimelineManager {
    [FieldOffset(0x00)] public AtkTimelineResource* Resources;
    [FieldOffset(0x08)] public ushort ResourceCount;
    [FieldOffset(0x0A)] public ushort TimelineCount;
    [FieldOffset(0x0C)] public uint UnkC;
    [FieldOffset(0x10)] public AtkTimeline* Timelines;
    [FieldOffset(0x18)] public ushort TimelineCount2;
    [FieldOffset(0x1C)] public uint Unk1C;
    [FieldOffset(0x20)] public uint AnimationCount;
    [FieldOffset(0x24)] public uint LabelSetCount;
    [FieldOffset(0x28)] public uint KeyFrameCount;
    [FieldOffset(0x30)] public uint LabelSetCount2;
    [FieldOffset(0x34)] public uint KeyFrameCounter2;
    [FieldOffset(0x38)] public AtkTimelineAnimation* Animations;
    [FieldOffset(0x40)] public AtkTimelineLabelSet* LabelSets;
    [FieldOffset(0x48)] public AtkTimelineKeyFrame* KeyFrames;
    [FieldOffset(0x50)] public ulong Unk50;
}
