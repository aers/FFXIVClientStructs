namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler;

[StructLayout(LayoutKind.Explicit, Size = 0xA78)]
public partial struct TimelineGroup {
    [FieldOffset(0x08)] public Base.LinkedList<TimelineGroup> List;
    // [FieldOffset(0x18)] public SchedulerTimeline* SomeTimeline;
    // [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray4<SchedulerTimeline> _timelinesInline;
}
