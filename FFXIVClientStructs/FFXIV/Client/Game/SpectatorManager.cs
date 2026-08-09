using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::SpectatorManager
/// <remarks>
/// Initializes and manages the spectator system
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4E0)]
public unsafe partial struct SpectatorManager {
    [StaticAddress("4C 89 2D ?? ?? ?? ?? 45 33 C0", 3, isPointer: true)]
    public static partial SpectatorManager* Instance();

    [FieldOffset(0x008)] public ExcelSheet* Sheet;
    [FieldOffset(0x010)] public SpectatorManagerWaiter* Waiter;
    [FieldOffset(0x08C)] public uint SpectatorRowId;
    [FieldOffset(0x094)] private uint Unk94;
    [FieldOffset(0x098)] private uint Unk98;
    [FieldOffset(0x090)] private byte Unk90;
    [FieldOffset(0x0A1)] private byte Unknown40; // Set with Spectator.Unknown40 in ReadSpectatorRow
    [FieldOffset(0x0A2)] public byte SheetStatus; // 0 = Missing, 1 = Sheet loaded, 2 = Row read
    [FieldOffset(0x0DA)] private byte UnkDA; // 1, 2 and 100 (default?) are known flags. 2 shows the spectator management UI

    /// <summary> Initializes the SpectatorManager global. </summary>
    [MemberFunction("48 89 5C 24 ?? 55 41 54 41 55 41 56 41 57 48 83 EC ?? 44 8B E1")]
    public static partial void Initialize(uint spectatorRowId, uint a3, byte a4, uint a5);

    /// <summary> Updates and manages the Excel waiters here. </summary>
    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC ?? F3 0F 10 89")]
    public partial void Update();

    /// <summary> Reads spectator data from Excel, puts most of it into Control.SpectatorSystem. </summary>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? ?? ?? ?? 48 8B F1 48 8D 0D")]
    public partial void ReadSpectatorRow([CExporterExcel("Spectator")] void* spectatorRow);

    /// <summary> Changes an internal flag to tell the spectator UI to show itself. </summary>
    [MemberFunction("40 53 48 83 EC ?? 80 A1 ?? ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ?? 80 8B")]
    public partial void ShowSpectatorUI(float a2);

    /// <summary> Used by AgentPvPSpectator to check if the regular PvP spectator UI should be visible. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 41 B0")]
    public partial bool ShouldShowSpectatorUI();

    [GenerateInterop]
    [Inherits<ExcelSheetWaiter>]
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct SpectatorManagerWaiter {
        [FieldOffset(0x030)] private void* Unk30;
        [FieldOffset(0x038)] public void* Arg;
        [FieldOffset(0x040)] public void* Callback;
        [FieldOffset(0x048)] private void* Unk48;
    }
}
