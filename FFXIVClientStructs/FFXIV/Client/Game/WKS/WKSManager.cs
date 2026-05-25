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
    /// <summary>Set to 1 when WKS territory loads; cleared on unload. Checked by <see cref="IsFunctionUnlocked"/>.</summary>
    [FieldOffset(0x1A)] public bool IsLoaded;

    [FieldOffset(0x50)] public WKSState State;

    /// <remarks> RowId of WKSDevGrade sheet. </remarks>
    [FieldOffset(0x5A), Obsolete("Use State.DevGrade")] public ushort DevGrade;

    /// <remarks> For Hub upgrades. RowId of WKSFateControl sheet. </remarks>
    [FieldOffset(0x60), Obsolete("Use State.CurrentFateControlRowId")] public ushort CurrentFateControlRowId;
    /// <remarks> For Hub upgrades. Id of Fate in FateManager. </remarks>
    [FieldOffset(0x62), Obsolete("Use State.CurrentFateId")] public ushort CurrentFateId;

    /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
    [FieldOffset(0xE80), Obsolete("Use State.CurrentMissionUnitRowId")] public ushort CurrentMissionUnitRowId;

    [FieldOffset(0xE8C), Obsolete("Use State.CurrentScore")] public uint CurrentScore;
    [FieldOffset(0xE90), Obsolete("Use State.CurrentRank")] public MissionRank CurrentRank;

    [FieldOffset(0xE96), Obsolete("Use State.CollectedTotal")] public ushort CollectedTotal;
    [FieldOffset(0xE98), Obsolete("Use State.CollectedIndividual")] public byte CollectedIndividual;

    [FieldOffset(0xEC4), Obsolete("Use State.FishingBait")] public uint FishingBait;

    [FieldOffset(0xED1), FixedSizeArray, Obsolete("Use State.MissionCompletionFlags")] internal FixedSizeArray213<byte> _missionCompletionFlags;
    [FieldOffset(0xFA6), FixedSizeArray, Obsolete("Use State.MissionGoldFlags")] internal FixedSizeArray213<byte> _missionGoldFlags;

    [FieldOffset(0x107C), FixedSizeArray, Obsolete("Use State.Scores")] internal FixedSizeArray11<int> _scores; // cosmic class scores

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

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 0F B7 DA 48 8B F9 E8 ?? ?? ?? ?? 8B CB")]
    public partial void Load(ushort territoryId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F8 49 8B 4E")]
    public partial bool IsFunctionUnlocked(byte functionRowId);

    public bool IsMissionCompleted(uint missionUnitId) => State.MissionCompletionFlags.CheckBitInSpan(missionUnitId);

    public bool IsMissionGolded(uint missionUnitId) => State.MissionGoldFlags.CheckBitInSpan(missionUnitId);

    public enum MissionRank {
        None,
        Bronze,
        Silver,
        Gold,
        Failed = 5,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct WKSMissionState {
        [FieldOffset(0x00)] public ushort MissionUnitId;
        /// <remarks>Used by AgentWKSMission to set silver/gold mission flags when this is 1 or 2.</remarks>
        [FieldOffset(0x04)] public uint MissionFlag;
        [FieldOffset(0x08)] private ushort Unk8;
        [FieldOffset(0x0A)] public byte Condition; // Needs more testing, but was set to 1 when Critical Mission was abandoned. Could be a bool for showing locked out status?
    }

    /// <summary>Per-job state block. WKSState contains 11 of these (one per cosmic class job).</summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x148)]
    public struct WKSJobState {
        [FieldOffset(0xB0)] public WKSMissionState ExtraBasicMission; // This held a single extra A-rank mission entry. Emitted by AgentWKSMission.GetBasicMissions. Purpose yet unclear.
        [FieldOffset(0xC0)] public StdVector<WKSMissionState> SequentialMissions;
        [FieldOffset(0xD8)] public StdVector<WKSMissionState> ProvisionalMissions;
        [FieldOffset(0xF0)] public StdVector<WKSMissionState> CriticalMissions;
        [FieldOffset(0x108)] public uint CriticalMissionData; // All jobs with currently open critical missions hold the same value. (e.g. 1779307018). Purpose yet unclear.
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1088)]
    public partial struct WKSState {
        [FieldOffset(0x00)] private byte Unk00; // written as word, read as byte. used for arrays after Scores depending
        [FieldOffset(0x01)] private byte Unk01;
        [FieldOffset(0x04)] public int ProjectState;
        [FieldOffset(0x08)] private ushort Unk08; // also project related
        /// <remarks>RowId of WKSDevGrade sheet.</remarks>
        [FieldOffset(0x0A)] public ushort DevGrade;
        [FieldOffset(0x0C)] public int ProjectTimestamp; // for Addon#16889 and Addon#16890
        /// <remarks>For Hub upgrades. RowId of WKSFateControl sheet.</remarks>
        [FieldOffset(0x10)] public ushort CurrentFateControlRowId;
        /// <remarks>For Hub upgrades. Id of Fate in FateManager.</remarks>
        [FieldOffset(0x12)] public ushort CurrentFateId;
        [FieldOffset(0x14)] private byte Unk14; // Seems like some state flags which are checked in IsFunctionUnlocked. Bit 0 seems like "hub is built/active" 
        /// <remarks>0-based WKSPioneeringTrail row index for the currently visited planet (sheet row = this + 1).</remarks>
        [FieldOffset(0x15)] public byte CurrentPlanetIndex; // Full row is highest subrow where WKSPioneeringTrail[row][sub].ActivationStage <= WKSState.DevGrade
        /// <remarks>0-based WKSPioneeringTrail row index for the latest unlocked planet. (sheet row = this + 1)</remarks>
        [FieldOffset(0x16)] public byte LatestPlanetIndex;

        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray11<WKSJobState> _jobStates;
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
