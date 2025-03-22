namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

// Client::System::Scheduler::Resource::SchedulerResourceManagement
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct SchedulerResourceManagement {
    [FieldOffset(0x08)] public SchedulerResource* Begin;
    [FieldOffset(0x10)] public StdMap<int, SchedulerResource> Resources;
}
