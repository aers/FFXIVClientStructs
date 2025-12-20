using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSManager
//   Client::Game::Character::CharacterManagerInterface
// Manager for Cosmic Exploration
[GenerateInterop]
[Inherits<CharacterManagerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xF90)]
public unsafe partial struct WKSManager {
    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B F8", 3, isPointer: true)]
    public static partial WKSManager* Instance();

    [FieldOffset(0x18)] public ushort TerritoryId;

    /// <remarks> RowId of WKSDevGrade sheet. </remarks>
    [FieldOffset(0x5A)] public ushort DevGrade;

    /// <remarks> For Hub upgrades. RowId of WKSFateControl sheet. </remarks>
    [FieldOffset(0x60)] public ushort CurrentFateControlRowId;
    /// <remarks> For Hub upgrades. Id of Fate in FateManager. </remarks>
    [FieldOffset(0x62)] public ushort CurrentFateId;

    /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
    [FieldOffset(0xC18)] public ushort CurrentMissionUnitRowId;

    [FieldOffset(0xC54)] public uint FishingBait;

    [FieldOffset(0xC61), FixedSizeArray] internal FixedSizeArray172<byte> _missionCompletionFlags;
    [FieldOffset(0xD0D), FixedSizeArray] internal FixedSizeArray172<byte> _missionGoldFlags;

    [FieldOffset(0xDBC), FixedSizeArray] internal FixedSizeArray11<int> _scores; // cosmic class scores

    [FieldOffset(0xE38)] private void* UnkStructE38;
    [FieldOffset(0xE40)] private void* UnkStructE40;
    [FieldOffset(0xE48)] public WKSMechaEventModule* MechaEventModule;
    [FieldOffset(0xE50)] private void* UnkStructE50;
    [FieldOffset(0xE58)] private void* UnkStructE58;
    [FieldOffset(0xE60)] private void* EmergencyInfoModule; // Red Alert
    [FieldOffset(0xE68)] private void* UnkStructE68;
    [FieldOffset(0xE70)] private void* UnkStructE70;
    [FieldOffset(0xE78)] public WKSMissionModule* MissionModule; // Stellar Missions
    [FieldOffset(0xE80)] public WKSResearchModule* ResearchModule;
    [FieldOffset(0xE88)] private void* UnkStructE88;
    [FieldOffset(0xE90)] private void* UnkStructE90;
    [FieldOffset(0xE98)] public StdVector<Pointer<WKSModuleBase>> Modules;

    public bool IsMissionCompleted(uint missionUnitId) => MissionCompletionFlags.CheckBitInSpan(missionUnitId);

    public bool IsMissionGolded(uint missionUnitId) => MissionGoldFlags.CheckBitInSpan(missionUnitId);
}
