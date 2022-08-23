namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::SchedulerState

// ctor 48 89 5C 24 ?? 57 48 83 EC ?? 48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 E8 ?? ?? ?? ?? 48 8B CF

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct SchedulerState
{
    [FieldOffset(0)] public void** VTable;
}
