using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSManager
//   Client::Game::Character::CharacterManagerInterface
// Manager for Cosmic Exploration
[GenerateInterop]
[Inherits<CharacterManagerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xF60)]
public unsafe partial struct WKSManager {
    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B F8", 3, isPointer: true)]
    public static partial WKSManager* Instance();

    [FieldOffset(0x18)] public ushort TerritoryId;

    /// <remarks> RowId of WKSDevGrade sheet. </remarks>
    [FieldOffset(0x52)] public ushort DevGrade;

    /// <remarks> For Hub upgrades. RowId of WKSFateControl sheet. </remarks>
    [FieldOffset(0x54)] public ushort CurrentFateControlRowId;
    /// <remarks> For Hub upgrades. Id of Fate in FateManager. </remarks>
    [FieldOffset(0x58)] public ushort CurrentFateId;

    /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
    [FieldOffset(0xC10)] public ushort CurrentMissionUnitRowId;

    [FieldOffset(0xC4C)] public uint FishingBait;

    [FieldOffset(0xD68), FixedSizeArray] internal FixedSizeArray11<int> _scores; // cosmic class scores

    [FieldOffset(0xE10)] private void* UnkStructDB0;
    [FieldOffset(0xE18)] private void* UnkStructDB8;
    [FieldOffset(0xE20)] public WKSMechaEventModule* MechaEventModule;
    [FieldOffset(0xE28)] private void* UnkStructDC8;
    [FieldOffset(0xE30)] private void* UnkStructDD0;
    [FieldOffset(0xE38)] private void* EmergencyInfoModule; // Red Alert
    [FieldOffset(0xE40)] private void* UnkStructDE0;
    [FieldOffset(0xE48)] private void* UnkStructDE8;
    [FieldOffset(0xE50)] public WKSMissionModule* MissionModule; // Stellar Missions
    [FieldOffset(0xE58)] public WKSResearchModule* ResearchModule;
    [FieldOffset(0xE60)] private void* UnkStructE00;
    [FieldOffset(0xE68)] public StdVector<Pointer<WKSModuleBase>> Modules;
}
