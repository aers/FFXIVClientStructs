using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x1CB0)]
public unsafe struct AddonSalvageItemSelector {
    [FieldOffset(0x0000)] public AtkUnitBase AtkUnitBase;
    
    [FieldOffset(0x0268)] public fixed byte ItemData[0x30 * 140];
    
    [FieldOffset(0x1CA8)] public AgentSalvage.SalvageItemCategory SelectedCategory;
    [FieldOffset(0x1CAC)] public uint ItemCount; 
    
    public Span<SalvageItem> Items {
        get {
            fixed (byte* ptr = ItemData) {
                return new Span<SalvageItem>(ptr, 140);
            }
        }
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct SalvageItem {
        [FieldOffset(0x00)] public InventoryType Inventory;
        [FieldOffset(0x04)] public int Slot;
        [FieldOffset(0x08)] public uint IconId;
        [FieldOffset(0x10)] public byte* NamePtr;
        [FieldOffset(0x18)] public uint Quantity;
        [FieldOffset(0x1C)] public uint JobIconID;
        [FieldOffset(0x20)] public byte* JobNamePtr;
        [FieldOffset(0x28)] public byte Unknown28;
    }
    
}
