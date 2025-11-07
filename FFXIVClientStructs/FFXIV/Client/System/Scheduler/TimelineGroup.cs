namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler;

[StructLayout(LayoutKind.Explicit, Size = 0xA78)]
public unsafe partial struct TimelineGroup {
    [FieldOffset(0x10)] public TimelineGroup* Other;
}
