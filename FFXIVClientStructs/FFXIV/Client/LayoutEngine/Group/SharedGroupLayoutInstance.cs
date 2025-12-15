using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Node;
using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SharedGroupLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//   Client::System::Resource::ResourceEventListener
/// <summary>
/// A set of instances used together. Can be nested up to 4 levels deep.
/// Each prefab is a scene, however it has some limitations (only single embedded layer group with a single layer is supported).
/// </summary>
[GenerateInterop]
[Inherits<ILayoutInstance>, Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct SharedGroupLayoutInstance {
    [FieldOffset(0x038)] public ResourceHandle* ResourceHandle;
    [FieldOffset(0x040)] public LayoutSharedGroupObject* TimelineObject;
    [FieldOffset(0x050)] public Transform Transform;
    [FieldOffset(0x080)] public ChildNodeContainer Instances;
    // [FieldOffset(0x0A8)] public ChildNodeContainer uA8;

    [FieldOffset(0xD0)] public TimeLineContainer TimeLineContainer;
    // [FieldOffset(0x108)] public ILayoutInstance* ExtraTimelineInstance; // not sure of purpose
    [FieldOffset(0x110)] public SGActionController* ActionController1;
    [FieldOffset(0x118)] public SGActionController* ActionController2;

    [FieldOffset(0x120)] public uint PrefabFlags1; // 0x1 = load started; 0x3 = load failed or contents added; 0x4 = failed to add contents
    [FieldOffset(0x12C)] public uint PrefabFlags2; // 0x8 = colliders active

    // [FieldOffset(0x14C), FixedSizeArray] internal FixedSizeArray16<byte> _timelineIndices; // used by EventObjAnimation ActorControl packet, some kind of simple lookup table

    [MemberFunction("E8 ?? ?? ?? ?? 41 FF C7 48 8D 76 04")]
    public partial bool InitAnimationHandlers(void* fileData);
    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 8F ?? ?? ?? ?? 83 E9 01")]
    public partial void InitTimelines(void* fileData);
}
