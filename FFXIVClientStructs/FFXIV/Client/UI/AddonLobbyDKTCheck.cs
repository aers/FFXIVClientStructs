using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLobbyDKTCheck
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("LobbyDKTCheck")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x250)]
public unsafe partial struct AddonLobbyDKTCheck {
    [FieldOffset(0x238)] private AtkComponentButton* Unk238;
    [FieldOffset(0x240)] public AtkComponentButton* ConfirmButton;
    [FieldOffset(0x248)] public AtkComponentButton* CancelButton;
}
