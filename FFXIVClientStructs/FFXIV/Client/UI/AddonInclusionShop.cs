using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInclusionShop
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InclusionShop")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3470)]
public unsafe partial struct AddonInclusionShop {
    public InclusionShopAtkValues* TypedAtkValues => (InclusionShopAtkValues*)AtkValues;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 2939)]
    public partial struct InclusionShopAtkValues {
        [FieldOffset(AtkValue.StructSize * 296)] public AtkValue PinnedCurrencyIconId;
        [FieldOffset(AtkValue.StructSize * 297)] public AtkValue PinnedCurrencyCount;
        [FieldOffset(AtkValue.StructSize * 298)] public AtkValue ItemCount;
        [FieldOffset(AtkValue.StructSize * 299), FixedSizeArray] internal FixedSizeArray60<InclusionShopItem> _items;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 18)]
        public partial struct InclusionShopItem {
            [FieldOffset(AtkValue.StructSize * 0)] public AtkValue AtkValue0;
            [FieldOffset(AtkValue.StructSize * 1)] public AtkValue ItemId;
            [FieldOffset(AtkValue.StructSize * 2)] public AtkValue IconId;
            [FieldOffset(AtkValue.StructSize * 3)] public AtkValue Stacksize;
            [FieldOffset(AtkValue.StructSize * 4)] public AtkValue AmountOwned;
            [FieldOffset(AtkValue.StructSize * 5)] public AtkValue GiveCount;
            [FieldOffset(AtkValue.StructSize * 6), FixedSizeArray] internal FixedSizeArray3<AtkValue> _giveItemId;
            [FieldOffset(AtkValue.StructSize * 9), FixedSizeArray] internal FixedSizeArray3<AtkValue> _giveIconId;
            [FieldOffset(AtkValue.StructSize * 12), FixedSizeArray] internal FixedSizeArray3<AtkValue> _giveAmount;
            [FieldOffset(AtkValue.StructSize * 14)] public AtkValue AtkValue14;
            [FieldOffset(AtkValue.StructSize * 15)] public AtkValue MaxAmount;
            [FieldOffset(AtkValue.StructSize * 16)] public AtkValue Flags; // 0b10 = CanSelectAmount
            [FieldOffset(AtkValue.StructSize * 17)] public AtkValue Index;
        }
    }
}
