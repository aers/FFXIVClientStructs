using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 167 * 8)]
public unsafe partial struct InventoryRetainerStringArray {
    public static InventoryRetainerStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.InventoryRetainer);
        return stringArray == null ? null : (InventoryRetainerStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray167<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray140<CStringPointer> _itemNames;
    [FieldOffset(140 * 8), FixedSizeArray] internal FixedSizeArray18<CStringPointer> _crystalNames;

    /// <remarks>Formatted as used/total.</remarks>
    [FieldOffset(158 * 8)] public CStringPointer UsedSlotsText;
    [FieldOffset(160 * 8)] public CStringPointer GilText;
    [FieldOffset(161 * 8), FixedSizeArray] internal FixedSizeArray6<CStringPointer> _tabLabels;
}
