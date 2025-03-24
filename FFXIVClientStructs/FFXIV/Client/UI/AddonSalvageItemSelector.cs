using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSalvageItemSelector
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SalvageItemSelector")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1D10)]
public unsafe partial struct AddonSalvageItemSelector {
    [FieldOffset(0x240)] public AgentSalvage.SalvageItemCategory SelectedCategory;

    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray140<SalvageItem> _items;

    [FieldOffset(0x1D08)] public uint ItemCount;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct SalvageItem {
        [FieldOffset(0x00)] public InventoryType Inventory;
        [FieldOffset(0x04)] public int Slot;
        [FieldOffset(0x08)] public uint IconId;
        [FieldOffset(0x10)] public CStringPointer NamePtr;
        [FieldOffset(0x18)] public uint Quantity;
        [FieldOffset(0x1C)] public uint JobIconId;
        [FieldOffset(0x20)] public CStringPointer JobNamePtr;
        [FieldOffset(0x28)] public byte Unknown28;
    }
}
