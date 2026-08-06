using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLobbyDKTCheckExec
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("LobbyDKTCheckExec")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct AddonLobbyDKTCheckExec {
    [FieldOffset(0x238)] public AtkTextNode* PromptText;
    [FieldOffset(0x240)] public short PromptTextHeight;
    [FieldOffset(0x248)] public AtkComponentButton* ConfirmButton;
    [FieldOffset(0x250)] public short ConfirmButtonY;
    [FieldOffset(0x258)] public AtkComponentButton* CancelButton;
    [FieldOffset(0x260)] public short CancelButtonY;
}
