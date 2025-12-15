using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Node;

// Client::LayoutEngine::Node::ChildNodeContainer
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ChildNodeContainer {
    [FieldOffset(0x08)] public SharedGroupLayoutInstance* Owner;
    [FieldOffset(0x10)] public StdVector<Pointer<ChildNodeInstance>> Instances;

    [VirtualFunction(0)]
    public partial ChildNodeContainer* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? F6 87 ?? ?? ?? ?? ?? 75 0E")]
    public partial void ApplyTransforms();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 47 10 48 85 C0 74 09")]
    public partial void SetCollidersActive(bool active);
}
