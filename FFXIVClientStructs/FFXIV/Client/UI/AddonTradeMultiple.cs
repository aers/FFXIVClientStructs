using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTradeMultiple
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("TradeMultiple")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonTradeMultiple {
    [FieldOffset(0x238)] public AtkTextNode* StatusText;
    [FieldOffset(0x240)] public AtkComponentList* ItemList;
    [FieldOffset(0x248)] public AtkComponentButton* ConfirmButton;

    public const int MaxSlots = 5;

    public TradeMultipleAtkValues* TypedAtkValues => (TradeMultipleAtkValues*)AtkValues;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 18)]
    public partial struct TradeMultipleAtkValues {
        /// <remarks><see cref="AtkValueType.String"/>. "n/5"</remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue StatusText;

        /// <remarks><see cref="AtkValueType.UInt"/>. Non-zero enables the confirm button</remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue ConfirmEnabled;

        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue SlotCount;

        [FieldOffset(AtkValue.StructSize * 3), FixedSizeArray] internal FixedSizeArray5<TradeMultipleSlotAtkValues> _slots;
    }

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 3)]
    public struct TradeMultipleSlotAtkValues {
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue ItemName;

        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue Quantity;

        /// <remarks><see cref="AtkValueType.UInt"/>. Packed <c>(InventoryType &lt;&lt; 16) | Slot</c></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue InventorySlot;
    }
}
