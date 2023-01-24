using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonContentsFinder
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 48 8d b3 38 02 00 00 48 8d 05 ?? ?? ?? ?? 48 89 ab 28 02 00 00 48 89 83 ?? ?? ?? ?? 8d 7d 02 48 89 ab 30 02 00 00 66 90 48 8b ce e8 ?? ?? ?? ?? 48 83 c6 09 48 83 ef 01 75 ?? 48", 3)]
public unsafe partial struct AddonContentsFinder
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