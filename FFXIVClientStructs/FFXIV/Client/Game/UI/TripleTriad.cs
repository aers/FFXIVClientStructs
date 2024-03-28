using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::TripleTriad
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct TripleTriad {
    [FieldOffset(0)] public AtkEventInterface AtkEventInterface;
}
