using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1 * 8)]
public unsafe partial struct CastBarStringArray {
    public static CastBarStringArray* Instance() => (CastBarStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.CastBar)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer CastName;
}
