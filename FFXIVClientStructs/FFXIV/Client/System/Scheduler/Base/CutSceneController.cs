using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::CutSceneController
//   Client::System::Scheduler::Base::SchedulerState
//   Client::System::Scheduler::Base::LinkList<Client::System::Scheduler::Base::CutSceneController>
[GenerateInterop]
[Inherits<SchedulerState>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 FF 48 8B D9", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x208)]
public unsafe partial struct CutSceneController {
    [FieldOffset(0x30)] public SchedulerResource* SchedulerResource;
    [FieldOffset(0x160)] public uint CutsceneId;
}
