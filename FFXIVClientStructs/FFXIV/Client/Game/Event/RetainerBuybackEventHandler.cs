using FFXIVClientStructs.FFXIV.Component.GUI;
using AgentContextUpdateChecker = FFXIVClientStructs.FFXIV.Client.UI.Agent.AgentContext.AgentContextUpdateChecker;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::RetainerBuybackEventHandler
//   Client::Game::Event::EventHandler
//   Client::UI::Agent::AgentContext::AgentContextUpdateChecker
//   Client::Game::Event::RetainerBuybackEventHandler::UIListener
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<EventHandler>]
[Inherits<AgentContextUpdateChecker>]
[Inherits<RetainerBuybackEventHandlerUIListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x1D8)]
public partial struct RetainerBuybackEventHandler;

[GenerateInterop(isInherited: true)]
[Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct RetainerBuybackEventHandlerUIListener;
