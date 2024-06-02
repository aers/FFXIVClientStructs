namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

// Client::System::Scheduler::Resource::SchedulerResourceManagement
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct SchedulerResourceManagement {
    [FieldOffset(0x08)] public SchedulerResource* Begin;
    [FieldOffset(0x10)] public void* Unknown; // TODO: SchedulerResources map/set<T>, see LoadActionTmb
    [FieldOffset(0x18)] public ulong NumResources;
}
