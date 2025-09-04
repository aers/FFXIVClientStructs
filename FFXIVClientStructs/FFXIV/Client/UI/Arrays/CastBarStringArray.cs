using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExporterIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1 * 8)]
public unsafe partial struct CastBarStringArray {
    public static CastBarStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.CastBar);
        return stringArray == null ? null : (CastBarStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer CastName;
}
