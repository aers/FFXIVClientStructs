using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::LayoutReferenceObject
//   Client::System::Scheduler::SchedulerInstanceObject
[GenerateInterop(isInherited: true)]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct LayoutReferenceObject {
    [VirtualFunction(47)] public partial ILayoutInstance* GetLayoutInstance1();
    [VirtualFunction(48)] public partial ILayoutInstance* GetLayoutInstance2();
    [VirtualFunction(49)] public partial SharedGroupLayoutInstance* GetParentInstance1();
    [VirtualFunction(50)] public partial SharedGroupLayoutInstance* GetParentInstance2();
}
