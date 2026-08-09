using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismSetConvert
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismSetConvert")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x598)]
public unsafe partial struct AddonMiragePrismPrismSetConvert {
    [FieldOffset(0x238)] private AtkResNode* Unk238; // tab container
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentButton>> _tabButtons;
    [FieldOffset(0x268)] private AtkTextNode* Unk268;
    [FieldOffset(0x270)] private AtkResNode* Unk270;

    [FieldOffset(0x278), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _itemSlots;
    [FieldOffset(0x2C0), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkResNode>> _itemSlotNodes2;
    [FieldOffset(0x308), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkResNode>> _itemSlotNodes6;
    [FieldOffset(0x350), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkImageNode>> _itemSlotImages5;
    [FieldOffset(0x398), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkImageNode>> _itemSlotImages7;

    [FieldOffset(0x3E0)] public AtkTextNode* ItemCountText; // Node 11
    [FieldOffset(0x3E8)] public AtkTextNode* AlreadyInDresserText;
    [FieldOffset(0x3F0)] public AtkComponentButton* StoreAsGlamourButton; // Node 27

    [FieldOffset(0x3F8)] private Utf8String Unk3F8;
    [FieldOffset(0x460)] private Utf8String Unk460;
    [FieldOffset(0x4C8)] private nint Unk4C8;
    [FieldOffset(0x4D0)] private byte Unk4D0; // AtkValues[0] & 8
    [FieldOffset(0x4D1)] private byte Unk4D1; // AtkValues[0] & 0x20

    public MiragePrismPrismSetConvertAtkValues* TypedAtkValues => (MiragePrismPrismSetConvertAtkValues*)AtkValues;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 84)]
    public partial struct MiragePrismPrismSetConvertAtkValues {
        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue GlamourPrismsHeld;
        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue AlreadyInDresserAddonTextId;
        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 5)] public AtkValue OutfitIconId;
        [FieldOffset(AtkValue.StructSize * 21), FixedSizeArray] internal FixedSizeArray9<ItemSlot> _items; // length is agent.NumItemsInSet

        [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 7)]
        public struct ItemSlot {
            /// <remarks><see cref="AtkValueType.UInt"/></remarks>
            [FieldOffset(AtkValue.StructSize * 0)] public AtkValue ItemId;
            /// <remarks><see cref="AtkValueType.UInt"/></remarks>
            [FieldOffset(AtkValue.StructSize * 1)] public AtkValue ItemIconId;
            [FieldOffset(AtkValue.StructSize * 2)] private AtkValue Unk02;
            [FieldOffset(AtkValue.StructSize * 3)] private AtkValue Unk03;
            /// <remarks><see cref="AtkValueType.UInt"/>. 9999 when the slot has not been filled</remarks>
            [FieldOffset(AtkValue.StructSize * 4)] public AtkValue InventoryType;
            /// <remarks><see cref="AtkValueType.UInt"/></remarks>
            [FieldOffset(AtkValue.StructSize * 5)] public AtkValue InventorySlot;
            /// <remarks><see cref="AtkValueType.UInt"/>. 0 = Missing, 2 = Unfilled, 3 = Filled, 6 = AlreadyInOutfit</remarks>
            [FieldOffset(AtkValue.StructSize * 6)] public AtkValue Flag;
        }
    }
}
