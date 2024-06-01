using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

/// <summary>
/// A set of instances used together. Can be nested up to 4 levels deep.
/// Each prefab is a scene, however it has some limitations (only single embedded layer group with a single layer is supported).
/// </summary>
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct SharedGroupLayoutInstance {
    [FieldOffset(0x030)] public void** ResourceEventListener; // base class; contains only vtable
    [FieldOffset(0x038)] public ResourceHandle* ResourceHandle;
    [FieldOffset(0x050)] public Transform Transform;
    [FieldOffset(0x080)] public InstanceList Instances;
    //[FieldOffset(0x0A8)] public InstanceList uA8;
    [FieldOffset(0x120)] public uint PrefabFlags1; // 0x1 = load started; 0x3 = load failed or contents added; 0x4 = failed to add contents
    [FieldOffset(0x12C)] public uint PrefabFlags2; // 0x8 = colliders active

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public unsafe partial struct InstanceData {
        [FieldOffset(0x10)] public ILayoutInstance* Instance;
        [FieldOffset(0x20)] public Transform Transform;

        [VirtualFunction(0)]
        public partial void Dtor(byte freeFlags);
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct InstanceList {
        [FieldOffset(0x08)] public SharedGroupLayoutInstance* Owner;
        [FieldOffset(0x10)] public StdVector<Pointer<InstanceData>> Instances;

        [VirtualFunction(0)]
        public partial void Dtor(byte freeFlags);
    }
}
