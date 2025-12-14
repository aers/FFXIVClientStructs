using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Clip;

// Client::System::Scheduler::Clip::BaseClip
//   Client::System::Scheduler::Base::SchedulerState
//   Client::System::Scheduler::Base::LinkList<Client::System::Scheduler::Base::BaseClip>
[GenerateInterop(isInherited: true)]
[Inherits<SchedulerState>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 D2 48 89 01 48 89 51 08 48 8B C1", 3, 63)]
public unsafe partial struct BaseClip {
    [FieldOffset(0x18)] public Base.LinkedList<BaseClip> List;

    [VirtualFunction(9)] public partial void ProcessEvent(int eventType, void* unknown);
    [VirtualFunction(47)] public partial void Event10(void* unknown);
    [VirtualFunction(49)] public partial void Event15(float dt);
    [VirtualFunction(51)] public partial void Event16(float dt);
}
