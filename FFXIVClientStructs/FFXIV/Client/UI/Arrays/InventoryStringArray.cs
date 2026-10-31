using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 324 * 8)]
public unsafe partial struct InventoryStringArray {
    public static InventoryStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.Inventory);
        return stringArray == null ? null : (InventoryStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray324<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray140<CStringPointer> _itemNames;
    [FieldOffset(140 * 8), FixedSizeArray] internal FixedSizeArray124<CStringPointer> _keyItemNames;
    [FieldOffset(290 * 8), FixedSizeArray] internal FixedSizeArray18<CStringPointer> _crystalNames;

    /// <remarks>Formatted as used/total.</remarks>
    [FieldOffset(308 * 8)] public CStringPointer UsedSlotsText;
    [FieldOffset(309 * 8), FixedSizeArray] internal FixedSizeArray5<CStringPointer> _tabLabels;
    [FieldOffset(314 * 8), FixedSizeArray] internal FixedSizeArray5<CStringPointer> _keyItemTabLabels;
    [FieldOffset(319 * 8)] public CStringPointer GilText;
    [FieldOffset(320 * 8), FixedSizeArray] internal FixedSizeArray4<CStringPointer> _pageUsedSlotsText;
}
