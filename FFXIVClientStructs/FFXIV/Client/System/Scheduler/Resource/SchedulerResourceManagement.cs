namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

// Client::System::Scheduler::Resource::SchedulerResourceManagement
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct SchedulerResourceManagement {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? 0F 28 CE E8 ?? ?? ?? ?? 48 83 7E ?? ??", 3, isPointer: true)]
    public static partial SchedulerResourceManagement* Instance();

    [FieldOffset(0x08)] public SchedulerResource* Begin;
    [FieldOffset(0x10)] public StdMap<int, SchedulerResource> Resources;
}
