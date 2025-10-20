using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 10 * 4)]
public unsafe partial struct BuddyNumberArray {
    public static BuddyNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Buddy);
        return numberArray == null ? null : (BuddyNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<int> _data;

    [FieldOffset(0 * 4)] public int CurrentExp;
    [FieldOffset(1 * 4)] public int MaxExp;
    [FieldOffset(2 * 4)] public int CurrentHP;
    [FieldOffset(3 * 4)] public int MaxHP;
    [FieldOffset(4 * 4)] public int RemaningSummonTime;
    [FieldOffset(5 * 4)] public int MaxSummonTime;
    [FieldOffset(6 * 4)] public int AvailableCombatPoints;

    [FieldOffset(8 * 4)] public int BuddyRank;
}
