using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSatisfactionSupply
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SatisfactionSupply")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x690)]
public unsafe partial struct AddonSatisfactionSupply {
    [FieldOffset(0x23C)] public int HoveredElementIndex; // Index 0-2 of the last hovered turn in element

    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray3<AddonDeliveryItemInfo> _deliveryInfo;

    public SatisfactionSupplyAtkValues* TypedAtkValues => (SatisfactionSupplyAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 142)]
    public struct SatisfactionSupplyAtkValues {
        /// <remarks><see cref="AtkValueType.Int"/></remarks>
        [FieldOffset(AtkValue.StructSize * 22)] public AtkValue DoHOwnedQuantity;
        /// <remarks><see cref="AtkValueType.Int"/></remarks>
        [FieldOffset(AtkValue.StructSize * 31)] public AtkValue MinBotOwnedQuantity;
        /// <remarks><see cref="AtkValueType.Int"/></remarks>
        [FieldOffset(AtkValue.StructSize * 40)] public AtkValue FshOwnedQuantity;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public struct AddonDeliveryItemInfo {
    [FieldOffset(0x60)] public uint ItemId;
}
