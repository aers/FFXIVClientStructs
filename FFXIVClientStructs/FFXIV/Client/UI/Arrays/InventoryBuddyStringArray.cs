using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 142 * 8)]
public unsafe partial struct InventoryBuddyStringArray {
    public static InventoryBuddyStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.InventoryBuddy);
        return stringArray == null ? null : (InventoryBuddyStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray142<CStringPointer> _data;

    /// <remarks>Formatted as used/total.</remarks>
    [FieldOffset(0 * 8)] public CStringPointer UsedSlotsText;
    [FieldOffset(1 * 8), FixedSizeArray] internal FixedSizeArray140<CStringPointer> _itemNames;
}
