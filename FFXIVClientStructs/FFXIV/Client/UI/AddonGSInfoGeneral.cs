using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoGeneral
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoGeneral")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonGSInfoGeneral {
    [FieldOffset(0x230)] public AtkComponentBase* MGPAmountDisplay;
    [FieldOffset(0x238)] public AtkComponentBase* TournamentMatches;
    [FieldOffset(0x240)] public AtkComponentBase* TournamentWins;
    [FieldOffset(0x248)] public AtkComponentBase* TournamentPoints;
    [FieldOffset(0x250)] public AtkComponentBase* TournamentInfo;
    [FieldOffset(0x258)] public AtkResNode* TournamentResults;
}
