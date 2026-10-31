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

    [FieldOffset(290 * 8), FixedSizeArray] internal FixedSizeArray18<CStringPointer> _crystalNames;

    /// <remarks>Formatted as used/total.</remarks>
    [FieldOffset(308 * 8)] public CStringPointer UsedSlotsText;
}
