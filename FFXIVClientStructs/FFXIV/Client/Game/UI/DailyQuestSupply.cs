using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::DailyQuestSupply
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[StructLayout(LayoutKind.Explicit, Size = 0x3E8)]
public unsafe struct DailyQuestSupply {
    [FieldOffset(0)] public AtkEventInterface AtkEventInterface;
}
