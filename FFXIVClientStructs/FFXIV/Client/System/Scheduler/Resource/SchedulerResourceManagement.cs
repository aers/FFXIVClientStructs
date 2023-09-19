namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct SchedulerResourceManagement {
    [FieldOffset(0x00)] public void** vtbl;
    [FieldOffset(0x08)] public SchedulerResource* Begin;
    [FieldOffset(0x10)] public void* Unknown;
    [FieldOffset(0x18)] public ulong NumResources;
}
