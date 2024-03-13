using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::SchedulerTimeline
//   Client::System::Scheduler::Base::TimelineController
//     Client::System::Scheduler::Base::SchedulerState
// ctor "E8 ?? ?? ?? ?? 48 89 43 ?? 48 89 98"
[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public unsafe partial struct SchedulerTimeline {
    [FieldOffset(0)] public TimelineController TimelineController;

    // [FieldOffset(0x90)] public TimelineGroup* TimelineGroup;
    [FieldOffset(0x98)] public SchedulerResource* SchedulerResource;

    [FieldOffset(0xA8)] public byte* ActionTimelineKey;
    [FieldOffset(0xB0)] public byte* FaceLibraryPath;

    [FieldOffset(0x18C)] public uint OwningGameObjectIndex;

    [MemberFunction("E8 ?? ?? ?? ?? 83 7F ?? ?? 75 ?? 0F B6 87")]
    public partial ulong LoadTimelineResources();

    [MemberFunction("E8 ?? ?? ?? ?? EB CA 48 8B 4C 24")]
    public partial void UpdateBanner(float delta, byte a3 = 0); // not sure on the naming, but this advances the animation forward

    [VirtualFunction(28)]
    public partial int GetOwningGameObjectIndex();
}
