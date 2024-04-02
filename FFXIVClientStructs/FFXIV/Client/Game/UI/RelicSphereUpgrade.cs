using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RelicSphereUpgrade
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct RelicSphereUpgrade {
    [FieldOffset(0)] public AtkEventInterface AtkEventInterface;
}
