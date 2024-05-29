namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::TimelineController
//   Client::System::Scheduler::Base::SchedulerState
// ctor "80 61 ?? ?? 48 8D 05 ?? ?? ?? ?? 80 61 ?? ?? 33 D2"
[GenerateInterop(isInherited: true)]
[Inherits<SchedulerState>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct TimelineController {
    // [FieldOffset(0x28)] public nint TmbhData;

    [FieldOffset(0x34)] public float CurrentTimestamp;
}
