namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public partial struct AtkTimelineAnimation {
    [FieldOffset(0x00)] public ushort StartFrameIdx;
    [FieldOffset(0x02)] public ushort EndFrameIdx;
    [FieldOffset(0x08)] internal FixedSizeArray8<AtkTimelineKeyGroup> _keyGroups;
}
