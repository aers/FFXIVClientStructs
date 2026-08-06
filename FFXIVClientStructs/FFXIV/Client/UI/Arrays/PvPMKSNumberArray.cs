using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 604 * 4)]
public unsafe partial struct PvPMKSNumberArray {
    public static PvPMKSNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.PvPMKS);
        return numberArray == null ? null : (PvPMKSNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray604<int> _data;
    
    /// <summary>
    /// In Seconds.
    /// </summary>
    [FieldOffset(0 * 4)] public int TimeRemaining;
    [FieldOffset(1 * 4)] public bool IsInOvertime;
    /// <summary>
    /// Range 0 - 1000
    /// </summary>
    [FieldOffset(2 * 4)] public int OvertimeBarFillPercentage;
    
    // I think has something to do with, ranked or casual or premade
    [FieldOffset(3 * 4)] private int Unk3;
    // I think has to do with what team you are on.
    [FieldOffset(4 * 4)] private int Unk4;
    
    /// <summary>
    /// Range -1000 - 1000
    /// </summary>
    [FieldOffset(6 * 4)] public int CrystalPushPercentage;
    
    [FieldOffset(7 * 4)] public CrystalGaugeType CrystalGaugeMode;
    /// <summary>
    /// Your own target entityId
    /// </summary>
    [FieldOffset(8 * 4)] public uint TargetEntityId;
    [FieldOffset(9 * 4)] private uint UnkEntityId;
    
    /// <summary>
    /// Holds all the UI data for team Umbra
    /// </summary>
    [FieldOffset(10 * 4)] public PvPMKSTeamNumberArray UmbraTeam;
    /// <summary>
    /// Holds all the UI data for team Astra
    /// </summary>
    [FieldOffset(306 * 4)] public PvPMKSTeamNumberArray AstraTeam;
    
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 297 * 4)]
    public partial struct PvPMKSTeamNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray297<int> _data;
        
        [FieldOffset(0 * 4)] public uint CrystalPushPercentage;
        [FieldOffset(1 * 4)] public uint Unk1;
        [FieldOffset(2 * 4)] public uint MidPointCapPercentage;
        [FieldOffset(5 * 4)] public uint AmountOfPlayersOnPoint;
        
        [FieldOffset(17 * 4), FixedSizeArray] internal FixedSizeArray5<PvpMKSTeamMemberNumberArray> _teamMembers;
        
        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 56 * 4)]
        public partial struct PvpMKSTeamMemberNumberArray {
            [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray56<int> _data;
            
            [FieldOffset(0 * 4)] public uint EntityId;
            [FieldOffset(1 * 4)] public bool IsTargetable;
            [FieldOffset(2 * 4)] private uint Unk2; // I think these are flags or colours.
            [FieldOffset(3 * 4)] private uint Unk3; // I think these are flags or colours.
            [FieldOffset(4 * 4)] public uint JobIconId;
            [FieldOffset(5 * 4)] public uint MarkerIconId;
            [FieldOffset(6 * 4)] public uint CurrentHp;
            [FieldOffset(7 * 4)] public uint MaxHp;
            /// <summary>
            /// Range 0 - 200
            /// </summary>
            [FieldOffset(8 * 4)] public uint ShieldPercentage;
            [FieldOffset(9 * 4)] public uint CurrentMana;
            [FieldOffset(10 * 4)] public uint MaxMana;
            /// <summary>
            /// Range 0 - 100
            /// </summary>
            [FieldOffset(11 * 4)] public uint LimitBreakChargePercentage;
            /// <summary>
            /// Range 0 - 100
            /// </summary>
            [FieldOffset(12 * 4)] public uint CastBarPercentage;
            /// <summary>
            /// In seconds
            /// </summary>
            [FieldOffset(13 * 4)] public uint RespawnTimeRemaining;
            [FieldOffset(14 * 4)] public uint StatusCount;
            [FieldOffset(15 * 4), FixedSizeArray] internal FixedSizeArray10<uint> _statusIds;
            [FieldOffset(25 * 4), FixedSizeArray] internal FixedSizeArray10<uint> _statusStackCounts;
            [FieldOffset(35 * 4), FixedSizeArray] internal FixedSizeArray10<uint> _statusIconIds;
            [FieldOffset(45 * 4), FixedSizeArray] internal FixedSizeArray10<bool> _statusDispellables;
        }
    }
    
    public enum CrystalGaugeType {
        CrystalLocked = 0,
        CrystalUncontested = 1,
        CrystalUmbraExclusiveContest = 2,
        CrystalUmbraCappingMidwayPoint = 3,
        CrystalAstraExclusiveContest = 4,
        CrystalAstraCappingMidwayPoint = 5,
        CrystalEquallyContested = 6,
    }
}
