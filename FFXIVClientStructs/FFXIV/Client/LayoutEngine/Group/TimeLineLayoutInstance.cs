using FFXIVClientStructs.FFXIV.Client.System.Scheduler;
using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct TimeLineLayoutInstance {
    [FieldOffset(0x30)] public SchedulerInstanceObject* SchedulerObject;
    [FieldOffset(0x38)] public SharedGroupLayoutInstance* Parent;
    [FieldOffset(0x40)] public uint PathCrc;
    [FieldOffset(0x48)] public FileSceneTimeline* DataPtr;
    [FieldOffset(0x50)] public LayoutReferenceObject* TimelineObject;
}
