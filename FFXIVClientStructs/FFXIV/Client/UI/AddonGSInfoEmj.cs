using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GSInfoGeneral")]
[StructLayout(LayoutKind.Explicit, Size = 0x250)]
public unsafe partial struct AddonGSInfoGeneral {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkComponentBase* MGPAmountDisplay;
    [FieldOffset(0x228)] public AtkComponentBase* TournamentMatches;
    [FieldOffset(0x230)] public AtkComponentBase* TournamentWins;
    [FieldOffset(0x238)] public AtkComponentBase* TournamentPoints;
    [FieldOffset(0x240)] public AtkComponentBase* TournamentInfo;
    [FieldOffset(0x248)] public AtkResNode* TournamentResults;
}
