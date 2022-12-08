namespace FFXIVClientStructs.FFXIV.Component.GUI; 

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct AtkDragDropManager {
	[FieldOffset(0x00)] public AtkEventListener AtkEventListener;

	//[FieldOffset(0x08)] public uint UnkNum_1; //some sort of identifier?
	//[FieldOffset(0x0C)] public int UnkNum_2; //ActionId, ItemId, InventorySlotIndex, ListIndex  etc.
	
	//[FieldOffset(0x20)] public Utf8String UnkString;
	
	[FieldOffset(0x90)] public AtkStage* AtkStage;

	//the first 2 seem to point to some subclass of DragDrop, maybe some temp thing
	//[FieldOffset(0x98)] public AtkComponentDragDrop* UnkDragDrop_1;
	//[FieldOffset(0xA0)] public AtkComponentDragDrop* UnkDragDrop_2;
	//[FieldOffset(0xA8)] public AtkComponentDragDrop* UnkDragDrop_3;

	//returns some sort of (event?)mask from some static array
	//[FieldOffset(0xB0)] public delegate*unmanaged<int, ulong> UnkFunc;

	[FieldOffset(0xB8)] public short DragStartX;
	[FieldOffset(0xBA)] public short DragStartY;

	//[FieldOffset(0xBB)] public byte UnkBool_1;
	//[FieldOffset(0xBC)] public byte UnkBool_2;
	//[FieldOffset(0xBD)] public byte UnkBool_3;
	//[FieldOffset(0xBE)] public byte UnkBool_4;
	//[FieldOffset(0xBF)] public byte UnkBool_5;
}