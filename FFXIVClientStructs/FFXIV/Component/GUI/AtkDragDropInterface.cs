namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkDragDropInterface {
    [FieldOffset(0x08)] public AtkComponentNode* ComponentNode;
    [FieldOffset(0x10)] public AtkResNode* ActiveNode;
    [FieldOffset(0x18)] public FlyBackAnimationData* FlyBackData;
    [FieldOffset(0x20)] public short DragStartX;
    [FieldOffset(0x22)] public short DragStartY;
    [FieldOffset(0x24)] public DragDropType DragDropType;
    [FieldOffset(0x28)] public short DragDropReferenceIndex; // inventory slot index, action bar slot index, etc.
    [FieldOffset(0x2A)] public bool IsActive;
    [FieldOffset(0x2B)] public SoundEffectSuppression DragDropSoundEffectSuppression;

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

    [VirtualFunction(8)]
    public partial bool HandleMouseUpEvent(AtkEventData.AtkMouseData* mouseData);

    [VirtualFunction(11)]
    public partial AtkDragDropPayloadContainer* GetPayloadContainer();

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct FlyBackAnimationData {
        [FieldOffset(0x00)] public float X;
        [FieldOffset(0x04)] public float Y;
        [FieldOffset(0x08)] public float Time;
    }

    [Flags]
    public enum SoundEffectSuppression : byte {
        None = 0,
        PickUp = 1 << 0,
        Insert = 1 << 1,
        Reset = 1 << 2,
    }
}
