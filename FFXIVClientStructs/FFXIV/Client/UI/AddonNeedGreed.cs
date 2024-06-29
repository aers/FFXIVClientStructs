using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonNeedGreed
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("NeedGreed")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe partial struct AddonNeedGreed {
    [FieldOffset(0x230), FixedSizeArray] internal FixedSizeArray16<LootItemInfo> _items;

    [FieldOffset(0x50C)] public int NumItems;
    [FieldOffset(0x518)] public int SelectedItemIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct LootItemInfo {
    [FieldOffset(0x00)] public byte* ItemName; // Pointer to a SeString
    [FieldOffset(0x08)] public uint ItemId;
    [FieldOffset(0x0C)] public uint IconId;
    // [FieldOffset(0x10)] public uint RollState; // Indicates something about the roll state for this item
    [FieldOffset(0x18)] public uint Roll; // uint.MaxValue when item is 'Passed'
    [FieldOffset(0x24)] public uint ItemCount;
}
