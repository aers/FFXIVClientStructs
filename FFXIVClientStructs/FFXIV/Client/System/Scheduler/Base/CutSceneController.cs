using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::CutSceneController
//   Client::System::Scheduler::Base::SchedulerState
//   Client::System::Scheduler::Base::LinkList<Client::System::Scheduler::Base::CutSceneController>
[GenerateInterop]
[Inherits<SchedulerState>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 FF 48 89 01 48 89 79 08 48 8B D9 40 88 79 10", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct CutSceneController {
    [FieldOffset(0x18)] public LinkedList<CutSceneController> LinkedList; // generator can't inherit from generics, so we put this here
    [FieldOffset(0x30)] public SchedulerResource* SchedulerResource;
    [FieldOffset(0x168)] public uint CutsceneId;
}
