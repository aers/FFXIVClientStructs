using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 42 * 4)]
public unsafe partial struct CastBarEnemyNumberArray {
    public static CastBarEnemyNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.CastBarEnemy);
        return numberArray == null ? null : (CastBarEnemyNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray48<int> _data;

    [FieldOffset(0 * 4)] public bool Active;

    [FieldOffset(1 * 4)] public int CastBarCount;

    [FieldOffset(2 * 4), FixedSizeArray] internal FixedSizeArray10<CastBarArrayData> _castBarData;

    [StructLayout(LayoutKind.Explicit, Size = 4 * 4)]
    public struct CastBarArrayData {
        [FieldOffset(0 * 4)] public uint EntityId;
        /// <remarks>0-100 on progress bars, -1 on non-progress bars</remarks>
        [FieldOffset(1 * 4)] public int Percentage;
        [FieldOffset(2 * 4)] public bool Interruptible;
        [FieldOffset(3 * 4)] public bool IsInterrupted;
    }
}
