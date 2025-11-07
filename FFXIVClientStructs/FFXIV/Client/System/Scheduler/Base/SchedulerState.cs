namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::SchedulerState
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct SchedulerState {
    [FieldOffset(8)] public SchedulerStateField8* UnkData;
    [FieldOffset(0x10)] public byte Flags1;
    [FieldOffset(0x11)] public byte Flags2;
}

[Inherits<SchedulerState>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct SchedulerStateField8;
