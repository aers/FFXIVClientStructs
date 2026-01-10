using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::NpcRepairCallback
//   Client::Game::Event::UICallbackBase<Client::Game::Event::EventHandler>
//     Client::Game::Event::UICallbackBaseInterface
//       Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct NpcRepairCallback {
    [FieldOffset(0x10)] public CustomTalkEventHandler* EventHandler;
}
