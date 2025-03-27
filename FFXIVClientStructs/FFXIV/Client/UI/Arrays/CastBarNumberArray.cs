using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 7 * 4)]
public unsafe partial struct CastBarNumberArray {
    public static CastBarNumberArray* Instance() => (CastBarNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.CastBar)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray6<int> _data;

    [FieldOffset(0 * 4)] public uint CastIconId;
    [FieldOffset(2 * 4)] public int CastTime;
    [FieldOffset(3 * 4)] public int TotalCastTime;
    /// <summary>
    /// Range is 0 to 100
    /// </summary>
    [FieldOffset(4 * 4)] public int CompletionPercentage;
    [FieldOffset(5 * 4)] public bool Interupted;
}
