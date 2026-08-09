using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::QTE
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct QTE {
    [FieldOffset(0x18)] public AgentId AgentId;
    [FieldOffset(0x26)] private byte Flags1;
    [FieldOffset(0x27)] private byte Flags2;
}
