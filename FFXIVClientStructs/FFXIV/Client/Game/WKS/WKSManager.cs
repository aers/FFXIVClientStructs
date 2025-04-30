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

    [FieldOffset(0xDB0)] private void* UnkStructDB0; // size: 0x3A8
    [FieldOffset(0xDB8)] private void* UnkStructDB8; // size: 0x1D0
    [FieldOffset(0xDC0)] public WKSMechaEventModule* MechaEventModule;
    [FieldOffset(0xDC8)] private void* UnkStructDC8; // size: 0x10
    [FieldOffset(0xDD0)] private void* UnkStructDD0; // size: 0x90
    [FieldOffset(0xDD8)] private void* UnkStructDD8; // size: 0x2D8 - EmergencyInfo (Red Alert)
    [FieldOffset(0xDE0)] private void* UnkStructDE0; // size: 0x198
    [FieldOffset(0xDE8)] private void* UnkStructDE8; // size: 0x328
    [FieldOffset(0xDF0)] private void* UnkStructDF0; // size: 0x18
    [FieldOffset(0xDF8)] public WKSResearch* Research; // TODO: add suffix "Module" at some point
    [FieldOffset(0xE00)] private void* UnkStructE00; // size: 0x40

    [FieldOffset(0xE08)] public StdVector<Pointer<WKSModuleBase>> Modules;
}
