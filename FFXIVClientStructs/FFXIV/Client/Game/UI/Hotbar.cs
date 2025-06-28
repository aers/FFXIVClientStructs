using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Hotbar
//   Client::UI::Misc::RaptureHotbarModule::ClearCallback
[GenerateInterop]
[Inherits<RaptureHotbarModule.ClearCallback>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B F1 48 89 01 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 D2", 3, 4)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct Hotbar {
    [MemberFunction("48 83 EC 38 33 D2 C7 44 24 ?? ?? ?? ?? ?? 45 33 C9")]
    public partial void CancelCast();

    /// <summary>
    /// Resets the PvE hotbars for the specified class, including all skills available at the specified class level.
    /// <b>Will reset the hotbars written to disk!</b>
    /// </summary>
    /// <param name="classJobId">The ClassJobId to reset.</param>
    /// <param name="classLevel">The class level to reset to.</param>
    [MemberFunction("40 53 55 41 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ??")]
    public partial void ResetPvEHotbarsForClassAtLevel(uint classJobId, uint classLevel = 1);

    /// <summary>
    /// Resets the PvP hotbars for the specified ClassJobId to their default values. <b>Will reset the hotbars written to disk!</b>
    /// Has no effect if the specified class job ID doesn't have PVP actions.
    /// </summary>
    /// <param name="classJobId">The ClassJobId to reset.</param>
    [MemberFunction("41 56 41 57 48 83 EC 68 48 8B 0D")]
    public partial void ResetPvPHotbarsForClassInner(uint classJobId);
}
