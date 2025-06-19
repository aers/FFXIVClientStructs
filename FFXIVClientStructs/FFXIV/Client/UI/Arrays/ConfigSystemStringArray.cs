using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2 * 8)]
public unsafe partial struct ConfigSystemStringArray {
    public static ConfigSystemStringArray* Instance() => (ConfigSystemStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.ConfigSystem)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray2<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer FPSText;
    [FieldOffset(1 * 8)] public CStringPointer ImmersiveGamepackWarningLabel;
}
