using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[GenerateInterop]
[Agent(AgentId.Purify)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe partial struct AgentPurify {

    [FieldOffset(0x38)] public StdVector<PurifyItem> ReducibleItems;
    //[FieldOffset(0x50)] public PurifyItem NextItem; ???
    [FieldOffset(0xD0)] public int ReducibleItemsCount;
    [FieldOffset(0xD4)] public uint ResultAddonId;
    [FieldOffset(0xD8)] public uint ResultItemId;
    [FieldOffset(0xDC)] public byte ResultBonus;

    [FieldOffset(0xE0), FixedSizeArray] internal FixedSizeArray3<ItemResult> _results;
    [FieldOffset(0xF8)] public uint AutoAddonId;
    [FieldOffset(0xFC)] public uint AutoItemId;
    [FieldOffset(0x100)] public ushort AutoItemsLeft;
    [FieldOffset(0x102)] public ushort AutoItemCount;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 83 ?? ?? ?? ?? 48 8B CB")]
    public partial void ReduceItem(InventoryItem* item);

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct ItemResult {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public int Count;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public struct PurifyItem {
        [FieldOffset(0x00)] public InventoryType Inventory;
        [FieldOffset(0x04)] public int Slot;
        [FieldOffset(0x08)] public uint ItemId;
        [FieldOffset(0x0C)] public uint IconId;
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public ushort Collectability;
    }
}
