using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;
using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::LayerManager
//   Client::LayoutEngine::IManagerBase
//     Client::System::Common::NonCopyable
/// <summary>
/// Layer is a flat list of instances that are always loaded together.
/// </summary>
[GenerateInterop]
[Inherits<IManagerBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct LayerManager {
    [FieldOffset(0x18)] public ushort LayerGroupId;
    [FieldOffset(0x1A)] public ushort FestivalId;
    [FieldOffset(0x1C)] public ushort FestivalSubId;
    [FieldOffset(0x1E)] public byte Flags;
    //[FieldOffset(0x1F)] public byte u1F;
    //[FieldOffset(0x20)] public ushort u20;
    [FieldOffset(0x28)] public StdMap<uint, Pointer<ILayoutInstance>> Instances;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 94 24 ?? ?? ?? ?? 48 89 84 24 ?? ?? ?? ?? 4C 8B E8")]
    public partial TimeLineLayoutInstance* CreateTimelineInstance(SharedGroupLayoutInstance* group, int instanceKey, int subId, byte a5, byte a6, FileSceneTimeline* fileData, LayoutSharedGroupObject* timelineObj);
}
