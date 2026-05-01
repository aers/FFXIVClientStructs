using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSManager
//   Client::Game::Character::CharacterManagerInterface
// Manager for Cosmic Exploration
[GenerateInterop]
[Inherits<CharacterManagerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1250)]
public unsafe partial struct WKSManager {
    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B F8", 3, isPointer: true)]
    public static partial WKSManager* Instance();

    [FieldOffset(0x18)] public ushort TerritoryId;

    [FieldOffset(0x50)] private WKSState State; // TODO: use this instead of the fields

    /// <remarks> RowId of WKSDevGrade sheet. </remarks>
    [FieldOffset(0x5A), CExporterIgnore] public ushort DevGrade;

    /// <remarks> For Hub upgrades. RowId of WKSFateControl sheet. </remarks>
    [FieldOffset(0x60), CExporterIgnore] public ushort CurrentFateControlRowId;
    /// <remarks> For Hub upgrades. Id of Fate in FateManager. </remarks>
    [FieldOffset(0x62), CExporterIgnore] public ushort CurrentFateId;

    /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
    [FieldOffset(0xE80), CExporterIgnore] public ushort CurrentMissionUnitRowId;

    [FieldOffset(0xE8C), CExporterIgnore] public uint CurrentScore;
    [FieldOffset(0xE90), CExporterIgnore] public MissionRank CurrentRank;

    [FieldOffset(0xE96), CExporterIgnore] public ushort CollectedTotal;
    [FieldOffset(0xE98), CExporterIgnore] public byte CollectedIndividual;

    [FieldOffset(0xEC4), CExporterIgnore] public uint FishingBait;

    [FieldOffset(0xED1), FixedSizeArray, CExporterIgnore] internal FixedSizeArray213<byte> _missionCompletionFlags;
    [FieldOffset(0xFA6), FixedSizeArray, CExporterIgnore] internal FixedSizeArray213<byte> _missionGoldFlags;

    [FieldOffset(0x107C), FixedSizeArray, CExporterIgnore] internal FixedSizeArray11<int> _scores; // cosmic class scores

    [FieldOffset(0x10F8)] private void* UnkStruct10F8;
    [FieldOffset(0x1100)] private void* UnkStruct1100;
    [FieldOffset(0x1108)] public WKSMechaEventModule* MechaEventModule;
    [FieldOffset(0x1110)] private void* UnkStruct1110;
    [FieldOffset(0x1118)] private void* UnkStruct1118;
    [FieldOffset(0x1120)] private void* EmergencyInfoModule; // Red Alert
    [FieldOffset(0x1128)] private void* UnkStruct1128;
    [FieldOffset(0x1130)] private void* UnkStruct1130;
    [FieldOffset(0x1138)] public WKSMissionModule* MissionModule; // Stellar Missions
    [FieldOffset(0x1140)] public WKSResearchModule* ResearchModule;
    [FieldOffset(0x1148)] private void* UnkStruct1148;
    [FieldOffset(0x1150)] private void* UnkStruct1150;
    [FieldOffset(0x1158)] public StdVector<Pointer<WKSModuleBase>> Modules;

    public bool IsMissionCompleted(uint missionUnitId) => MissionCompletionFlags.CheckBitInSpan(missionUnitId);

    public bool IsMissionGolded(uint missionUnitId) => MissionGoldFlags.CheckBitInSpan(missionUnitId);

    public enum MissionRank {
        None,
        Bronze,
        Silver,
        Gold,
        Failed = 5,
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1088)]
    internal partial struct WKSState {
        /// <remarks> RowId of WKSDevGrade sheet. </remarks>
        [FieldOffset(0x0A)] public ushort DevGrade;

        /// <remarks> For Hub upgrades. RowId of WKSFateControl sheet. </remarks>
        [FieldOffset(0x10)] public ushort CurrentFateControlRowId;
        /// <remarks> For Hub upgrades. Id of Fate in FateManager. </remarks>
        [FieldOffset(0x12)] public ushort CurrentFateId;

        /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
        [FieldOffset(0xE30)] public ushort CurrentMissionUnitRowId;

        [FieldOffset(0xE3C)] public uint CurrentScore;
        [FieldOffset(0xE40)] public MissionRank CurrentRank;

        [FieldOffset(0xE46)] public ushort CollectedTotal;
        [FieldOffset(0xE48)] public byte CollectedIndividual;

        [FieldOffset(0xE74)] public uint FishingBait;

        [FieldOffset(0xE81), FixedSizeArray(isBitArray: true, bitCount: 1704)] internal FixedSizeArray213<byte> _missionCompletionFlags;
        [FieldOffset(0xF56), FixedSizeArray(isBitArray: true, bitCount: 1704)] internal FixedSizeArray213<byte> _missionGoldFlags;
        [FieldOffset(0x102C), FixedSizeArray] internal FixedSizeArray11<int> _scores; // cosmic class scores
    }
}
