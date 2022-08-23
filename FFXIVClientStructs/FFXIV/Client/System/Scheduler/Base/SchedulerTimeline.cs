namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::SchedulerTimeline
//   Client::System::Scheduler::Base::TimelineController
//     Client::System::Scheduler::Base::SchedulerState

// Size at least 0x248
// ctor E8 ?? ?? ?? ?? 48 89 43 ?? 48 89 98
[StructLayout(LayoutKind.Explicit, Size=0x248)]
public partial struct SchedulerTimeline
{
    [FieldOffset(0)] public TimelineController TimelineController;

    [MemberFunction("E8 ?? ?? ?? ?? 83 7F ?? ?? 75 ?? 0F B6 87")]
    public partial ulong LoadTimelineResources();

    [VirtualFunction(28)]
    public partial int GetOwningGameObjectIndex();
}