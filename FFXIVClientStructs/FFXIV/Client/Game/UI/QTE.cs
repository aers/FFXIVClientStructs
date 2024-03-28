using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::QTE
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct QTE {
    [FieldOffset(0)] public AtkEventInterface AtkEventInterface;
}
