using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler;

// Client::System::Scheduler::ScheduleManagement
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct ScheduleManagement {
    [StaticAddress("48 C7 05 ?? ?? ?? ?? ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8B CB", 3)]
    public static partial ScheduleManagement* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 8B 03 48 8B CB")]
    public partial CutSceneController* CreateCutSceneController(byte* path, uint id, byte a4);
}
