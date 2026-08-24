using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemInspectionResult
//   Client::UI::AddonItemDetailBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("ItemInspectionResult")]
[GenerateInterop]
[Inherits<AddonItemDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonItemInspectionResult {
    [FieldOffset(0x238)] public Utf8String ItemName;
    [FieldOffset(0x2A0)] public Utf8String ItemNameAlt;
    [FieldOffset(0x308)] public byte ShowingAltName;

    public ItemInspectionResultAtkValues* TypedAtkValues => (ItemInspectionResultAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 81)]
    public struct ItemInspectionResultAtkValues {
        /// <remarks><see cref="AtkValueType.Int"/>. Non-zero enables the Next button.</remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue HasNext;
        /// <remarks><see cref="AtkValueType.Int"/>. 104 - val</remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue Rarity;
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 80)] public AtkValue Description;
    }
}
