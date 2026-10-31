using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 51 * 8)]
public unsafe partial struct ArmouryBoardStringArray {
    public static ArmouryBoardStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.ArmouryBoard);
        return stringArray == null ? null : (ArmouryBoardStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray51<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _itemNames;
    [FieldOffset(50 * 8)] public CStringPointer SelectedCategoryName;
}
