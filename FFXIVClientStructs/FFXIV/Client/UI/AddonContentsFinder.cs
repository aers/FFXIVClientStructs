using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonContentsFinder
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe struct AddonContentsFinder
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2B8)] public AtkComponentButton* ClearSelectionButton; // Both ClearSelection and DutyStatus
    [FieldOffset(0x2C0)] public AtkComponentButton* JoinButton; // Both Join and Withdraw
    
    [FieldOffset(0x2C8)] public AtkComponentRadioButton* DutyRouletteRadioButton;
    [FieldOffset(0x2D0)] public AtkComponentRadioButton* Dungeons1RadioButton;
    [FieldOffset(0x2D8)] public AtkComponentRadioButton* Dungeons2RadioButton;
    [FieldOffset(0x2E0)] public AtkComponentRadioButton* GuildHeistsRadioButton;
    [FieldOffset(0x2E8)] public AtkComponentRadioButton* Trials1RadioButton;
    [FieldOffset(0x2F0)] public AtkComponentRadioButton* Trials2RadioButton;
    [FieldOffset(0x2F8)] public AtkComponentRadioButton* Raids1RadioButton;
    [FieldOffset(0x300)] public AtkComponentRadioButton* Raids2RadioButton;
    [FieldOffset(0x308)] public AtkComponentRadioButton* PvpRadioButton;
    [FieldOffset(0x310)] public AtkComponentRadioButton* GoldSaucerRadioButton;
}