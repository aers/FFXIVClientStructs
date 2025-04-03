using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ChocoboTaxiManager
// Chocobo Porter
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct ChocoboTaxiManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 44 89 77 04", 3)]
    public static partial ChocoboTaxiManager* Instance();

    [FieldOffset(0x00)] public uint Id; // RowId of ChocoboTaxi sheet
    [FieldOffset(0x04)] public uint ClientPathId; // Layout Instance Id

    [FieldOffset(0x20)] public Vector3 DismountPosition; // for when the player dismounts mid-flight
    [FieldOffset(0x30)] public ChocoboTaxiState State;
    [FieldOffset(0x34)] public bool RegisteredForDutyErrorShown; // LogMessage#7920 ("Unable to change areas. You are registered to join a duty.")
}

public enum ChocoboTaxiState {
    None = 0,
    Mounting = 1,
    Traveling = 2,
    Landing = 3,
}
