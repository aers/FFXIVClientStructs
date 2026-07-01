using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 336 * 4)]
public unsafe partial struct PvPProfileNumberArray {
    public static PvPProfileNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.PvPProfile);
        return numberArray == null ? null : (PvPProfileNumberArray*)numberArray->IntArray;
    }
    
    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray336<int> _data;
    
    [FieldOffset(0 * 4)] public uint GrandCompanyType;
    [FieldOffset(1 * 4)] public uint CurrentGrandCompanyPvPExperienceAmount;
    [FieldOffset(2 * 4)] public uint MaxGrandCompanyPvPExperienceAmount;
    [FieldOffset(3 * 4)] public uint CurrentGrandCompanyPvPLevel;
    [FieldOffset(4 * 4)] public uint MaxGrandCompanyPvPLevel;
    
    [FieldOffset(5 * 4)] public uint CurrentMalmstoneExperienceAmount;
    [FieldOffset(6 * 4)] public uint MaxMalmstoneExperienceAmount;
    [FieldOffset(7 * 4)] public uint CurrentMalmstoneLevel;
    [FieldOffset(8 * 4)] public uint MaxMalmstoneLevel;
    [FieldOffset(22 * 4)] public uint CasualCrystallineConflictWins;
    [FieldOffset(23 * 4)] public uint CasualCrystallineConflictLosses;
    [FieldOffset(24 * 4)] public uint RankedCrystallineConflictWinsThisSeason;
    [FieldOffset(25 * 4)] public uint RisersInRank; // This works differently in crystal naturally, but the value gets used.
    [FieldOffset(26 * 4)] public uint StarsInRank; // 0 in crystal
    [FieldOffset(27 * 4)] public uint HighestStarsInRank; // 0 in crystal
    [FieldOffset(28 * 4)] public PvPRank HighestRank;
    
    // I actually think gold and platinum internally might be flipped.
    public enum PvPRank {
        Unranked = 0,
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Platinum = 4,
        Diamond = 5,
        Crystal = 6,
        Omega = 7,
        Ultima = 8,
    }
}
