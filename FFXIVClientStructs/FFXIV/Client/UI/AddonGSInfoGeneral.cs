using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GSInfoEmj")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonGSInfoEmj {
    [FieldOffset(0x220)] public AtkTextNode* MatchesPlayed;
    [FieldOffset(0x228)] public AtkTextNode* CurrentRating;
    [FieldOffset(0x230)] public AtkTextNode* HighestRating;
    [FieldOffset(0x238)] public AtkTextNode* Rank;
    [FieldOffset(0x240)] public AtkTextNode* NextRankPoints;
    [FieldOffset(0x248)] public AtkTextNode* Points;
    [FieldOffset(0x250)] public AtkComponentButton* ResetRankButton;
}
