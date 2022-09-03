using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.MJIPouch)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct AgentMJIPouch {
	[FieldOffset(0x00)] public AgentInterface AgentInterface;

	[FieldOffset(0x28)] public PouchIndexInfo* InventoryIndex;
	[FieldOffset(0x30)] public PouchInventoryData* InventoryData;

	public StdVector<Pointer<PouchInventoryItem>>* GetInventoryByIndex(int index) {
		if (InventoryData == null || InventoryIndex == null) return null;
		var maxIndex = InventoryIndex->MaxIndex;
		if (index < 0 || index > maxIndex) return null;
		return (StdVector<Pointer<PouchInventoryItem>>*)InventoryData + (index + 6);
	}

	public StdVector<Pointer<PouchInventoryItem>>* GetSelectedInventory() {
		if (InventoryData == null || InventoryIndex == null) return null;
		return (StdVector<Pointer<PouchInventoryItem>>*)InventoryData + (InventoryIndex->CurrentIndex + 6);
	}

	public StdVector<PouchInventoryItem>* GetInventory() {
		if (InventoryData == null) return null;
		return (StdVector<PouchInventoryItem>*)InventoryData + 5;
	}


	[StructLayout(LayoutKind.Explicit, Size = 0x8)]
	public struct PouchIndexInfo {
		[FieldOffset(0x00)] public int CurrentIndex;
		[FieldOffset(0x04)] public int MaxIndex;
	}

	[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
	public struct PouchInventoryData {
		[FieldOffset(0x78)] public StdVector<PouchInventoryItem> Inventory;
		[FieldOffset(0x90)] public StdVector<Pointer<PouchInventoryItem>> Materials;
		[FieldOffset(0xA8)] public StdVector<Pointer<PouchInventoryItem>> Produce;
		[FieldOffset(0xC0)] public StdVector<Pointer<PouchInventoryItem>> StockStores;
		[FieldOffset(0xD8)] public StdVector<Pointer<PouchInventoryItem>> Tools;
		[FieldOffset(0xF0)] public StdVector<Utf8String> InventoryNames;
		[FieldOffset(0x108)] public uint MJIItemPouchItemCount;
	}
}

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public struct PouchInventoryItem {
	[FieldOffset(0x00)] public uint ItemId;
	[FieldOffset(0x04)] public uint IconId;
	[FieldOffset(0x08)] public int SlotIndex;
	[FieldOffset(0x0C)] public int StackSize;
	[FieldOffset(0x10)] public int MaxStackSize;
	[FieldOffset(0x14)] public byte InventoryIndex;
	[FieldOffset(0x15)] public byte ItemCategory;
	[FieldOffset(0x16)] public byte Undiscovered;
	
	[FieldOffset(0x18)] public Utf8String Name;
}