namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Node;

// Client::LayoutEngine::Node::ChildNodeInstance
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct ChildNodeInstance {
    [FieldOffset(0x10)] public ILayoutInstance* Instance;
    [FieldOffset(0x20)] public Transform Transform;

    [VirtualFunction(0)]
    public partial ChildNodeInstance* Dtor(byte freeFlags);
}
