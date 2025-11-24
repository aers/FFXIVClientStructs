namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneModuleUsualImpl
//   Client::Game::Event::EventSceneModuleImplBase
[GenerateInterop]
[Inherits<EventSceneModuleImplBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct EventSceneModuleUsualImpl {}

// Client::Game::Event::EventSceneModuleImplBase
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct EventSceneModuleImplBase {
    [FieldOffset(0x08)] public EventSceneModule* EventSceneModule;
}
