using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::LayoutSharedGroupObject
//   Client::System::Scheduler::Instance::LayoutReferenceObject
[GenerateInterop]
[Inherits<LayoutReferenceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct LayoutSharedGroupObject {
    [FieldOffset(0x80)] public SharedGroupLayoutInstance* Instance;
    [FieldOffset(0x88)] public StdMap<uint, Pointer<LayoutReferenceObject>> SubIdToInstance;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6B 10")]
    public partial void InsertObject(ILayoutInstance* inst);
}
