using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 16 * 8)]
public unsafe partial struct EnemyListStringArray {
    public static EnemyListStringArray* Instance() => (EnemyListStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.EnemyList)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray16<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray8<EnemyListEnemyStringArray> _members;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 2 * 8)]
    public partial struct EnemyListEnemyStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray2<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer EnemyName;
        [FieldOffset(1 * 8)] public CStringPointer Castname;
    }
}
