using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSManager
//   Client::Game::Character::CharacterManagerInterface
// Manager for Cosmic Exploration
[GenerateInterop]
[Inherits<CharacterManagerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xE20)]
public unsafe partial struct WKSManager {
    [StaticAddress("48 8B 7C 24 ?? 48 89 35 ?? ?? ?? ??", 8, isPointer: true)]
    public static partial WKSManager* Instance();

    [FieldOffset(0x18)] public ushort TerritoryId;

    /// <remarks> RowId of WKSDevGrade sheet. </remarks>
    [FieldOffset(0x4A)] public ushort DevGrade;

    /// <remarks> For Hub upgrades. RowId of WKSFateControl sheet. </remarks>
    [FieldOffset(0x50)] public ushort CurrentFateControlRowId;
    /// <remarks> For Hub upgrades. Id of Fate in FateManager. </remarks>
    [FieldOffset(0x52)] public ushort CurrentFateId;

    /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
    [FieldOffset(0xC60)] public ushort CurrentMissionUnitRowId;

    [FieldOffset(0xC9C)] public uint FishingBait;

    [FieldOffset(0xD34), FixedSizeArray] internal FixedSizeArray11<int> _scores; // cosmic class scores

    [FieldOffset(0xDB0)] private void* UnkStructDB0;
    [FieldOffset(0xDB8)] private void* UnkStructDB8;
    [FieldOffset(0xDC0)] public WKSMechaEventModule* MechaEventModule;
    [FieldOffset(0xDC8)] private void* UnkStructDC8;
    [FieldOffset(0xDD0)] private void* UnkStructDD0;
    [FieldOffset(0xDD8)] private void* EmergencyInfoModule; // Red Alert
    [FieldOffset(0xDE0)] private void* UnkStructDE0;
    [FieldOffset(0xDE8)] private void* UnkStructDE8;
    [FieldOffset(0xDF0)] public WKSMissionModule* MissionModule; // Stellar Missions
    [FieldOffset(0xDF8)] public WKSResearch* Research; // TODO: add suffix "Module" at some point
    [FieldOffset(0xE00)] private void* UnkStructE00;

    [FieldOffset(0xE08)] public StdVector<Pointer<WKSModuleBase>> Modules;
}
