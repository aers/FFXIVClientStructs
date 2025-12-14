using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::LayoutMemberObject
//   Client::System::Scheduler::Instance::LayoutReferenceObject
[GenerateInterop]
[Inherits<LayoutReferenceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct LayoutMemberObject {
    [FieldOffset(0x80)] public BgPartsLayoutInstance* Instance;
    [FieldOffset(0x88)] public SharedGroupLayoutInstance* Parent;
}
