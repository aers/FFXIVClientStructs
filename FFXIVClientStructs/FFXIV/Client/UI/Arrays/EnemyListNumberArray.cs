using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 53 * 4)]
public unsafe partial struct EnemyListNumberArray {
    public static EnemyListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.EnemyList);
        return numberArray == null ? null : (EnemyListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray53<int> _data;

    [FieldOffset(0 * 4)] private int Unk0;
    [FieldOffset(1 * 4)] public int EnemyCount;
    [FieldOffset(2 * 4)] public int TargetEntityId;
    [FieldOffset(3 * 4)] private int UnkEntityId;
    [FieldOffset(4 * 4)] private int Unk4;

    [FieldOffset(5 * 4), FixedSizeArray, CExporterIgnore] internal FixedSizeArray8<EnemyListEnemyNumberArray> _enemies;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
    public partial struct EnemyListEnemyNumberArray {
        [FieldOffset(0 * 4), FixedSizeArray, CExporterIgnore] internal FixedSizeArray6<int> _data;

        /// <summary>
        /// Range from 0 to 100
        /// </summary>
        [FieldOffset(0 * 4)] public int RemainingHPPercent;
        /// <summary>
        /// Range from 0 to 100
        /// </summary>
        [FieldOffset(1 * 4)] public int MaxHPPercent;
        /// <summary>
        /// Range from 0 to 100
        /// </summary>
        [FieldOffset(2 * 4)] public int CastPercent;
        [FieldOffset(3 * 4)] public int EntityId;
        [FieldOffset(4 * 4)] public bool ActiveInList;
        [FieldOffset(5 * 4)] private int Unk5;
    }
}
