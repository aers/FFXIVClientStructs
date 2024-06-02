using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoMinionBattle
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoMinionBattle")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonGSInfoMinionBattle {
    [FieldOffset(0x220)] public AtkComponentBase* TournamentMatches;
    [FieldOffset(0x228)] public AtkComponentBase* TournamentWins;
    [FieldOffset(0x230)] public AtkComponentBase* TournamentPoints;
    [FieldOffset(0x238)] public AtkComponentBase* TournamentInfo;
    [FieldOffset(0x240)] public AtkResNode* TournamentResults;
}
