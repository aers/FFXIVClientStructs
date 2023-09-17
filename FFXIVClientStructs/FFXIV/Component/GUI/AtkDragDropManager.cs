namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct AtkDragDropManager {
    [FieldOffset(0x00)] public AtkEventListener AtkEventListener;

    //[FieldOffset(0x08)] public uint UnkNum_1; //some sort of identifier?
    //[FieldOffset(0x0C)] public int UnkNum_2; //ActionId, ItemId, InventorySlotIndex, ListIndex  etc.

    [FieldOffset(0x90)] public AtkStage* AtkStage;

    //the first 2 seem to point to some subclass of DragDrop, maybe some temp thing
    [FieldOffset(0x98)] public AtkDragDropInterface* DragDrop1;

    // vvv Not set in some cases where DragDropS isn't used (like with hotbars)
    [FieldOffset(0xA0)] public AtkDragDropInterface* DragDrop2;
    [FieldOffset(0xA8)] public AtkComponentDragDrop* DragDropS;
    // ^^^

    //returns some sort of (event?)mask from some static array
    //public const int MaskSize = 0x57;
    //[FieldOffset(0xB0)] public delegate*unmanaged<int, ulong> GetMask;

    [FieldOffset(0xB8)] public short DragStartX;
    [FieldOffset(0xBA)] public short DragStartY;

    [FieldOffset(0xBC)] public bool IsDragging;
    // True if the item was clicked on (user must click again to drop it somewhere)
    [FieldOffset(0xBD)] public bool ReclickToDrop;
    // Set to true once the mouse moves during a drag
    [FieldOffset(0xBE)] public bool MouseMoved;
    // False if dropping on anything not ui (like the world)
    // Can't be false if ReclickToDrop is false
    [FieldOffset(0xBF)] public bool IsNotDiscarding;
}
