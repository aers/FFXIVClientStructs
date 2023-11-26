namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkDragDropInterface {
    [FieldOffset(0x00), CExportIgnore] public void* vtbl;
    [FieldOffset(0x08)] public AtkComponentNode* ComponentNode;
    [FieldOffset(0x10)] public AtkResNode* ActiveNode;
    // [FieldOffset(0x18)] public void* UnkBuffer; // Points to a buffer of 12 bytes? (freed on dtor)
    // [FieldOffset(0x20)] public uint Unk2;
    // [FieldOffset(0x24)] public uint Unk3;
    // [FieldOffset(0x28)] public nint Unk4;

    [VirtualFunction(1)]
    public partial void GetScreenPosition(float* screenX, float* screenY);

    [VirtualFunction(3)]
    public partial AtkComponentNode* GetComponentNode();

    [VirtualFunction(4)]
    public partial void SetComponentNode(AtkComponentNode* node);

    [VirtualFunction(5)]
    public partial AtkResNode* GetActiveNode();

    [VirtualFunction(7)]
    public partial AtkComponentBase* GetComponent();
}
