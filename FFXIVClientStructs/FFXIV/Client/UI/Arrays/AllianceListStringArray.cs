using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 45 * 8)]
public unsafe partial struct AllianceListStringArray {
    public static AllianceListStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.AllianceList);
        return stringArray == null ? null : (AllianceListStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray45<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray5<AllianceListGroupStringArray> _groups;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 9 * 8)]
    public partial struct AllianceListGroupStringArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray9<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer Header;
        [FieldOffset(1 * 8), FixedSizeArray] internal FixedSizeArray8<CStringPointer> _memberNames;
    }
}
