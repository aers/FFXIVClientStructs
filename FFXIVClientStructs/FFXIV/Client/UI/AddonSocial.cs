using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSocial
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Social")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct AddonSocial {
    [FieldOffset(0x230)] public AtkAddonControl AddonControl;
    [FieldOffset(0x290)] public AtkComponentRadioButton* PartyMembersRadioButton;
    [FieldOffset(0x298)] public AtkComponentRadioButton* FriendListRadioButton;
    [FieldOffset(0x2A0)] public AtkComponentRadioButton* BlacklistRadioButton;
    [FieldOffset(0x2A8)] public AtkComponentRadioButton* PlayerSearchRadioButton;
    [FieldOffset(0x2B0)] public Utf8String PlayerSearchString; // idk, it's literally just the words "Player Search"
}
