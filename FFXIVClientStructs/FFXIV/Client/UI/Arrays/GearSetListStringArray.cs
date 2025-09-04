using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExporterIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 111 * 8)]
public unsafe partial struct GearSetListStringArray {
    public static GearSetListStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.GearSetList);
        return stringArray == null ? null : (GearSetListStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray111<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer CountText;
    [FieldOffset(1 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _warningTexts;
    [FieldOffset(11 * 8), FixedSizeArray] internal FixedSizeArray100<CStringPointer> _gearSetNames;
}
