namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public partial struct AtkTimelineAnimation {
    [FieldOffset(0x00)] public ushort StartFrameIdx;
    [FieldOffset(0x02)] public ushort EndFrameIdx;
    [FixedSizeArray<AtkTimelineKeyGroup>(8)]
    [FieldOffset(0x08)] public unsafe fixed byte KeyGroups[8 * 16]; // 8 * AtkTimelineKeyGroup
}
