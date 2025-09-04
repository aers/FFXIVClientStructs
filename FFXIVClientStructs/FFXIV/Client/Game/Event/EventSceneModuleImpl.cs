namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneModuleUsualImpl
//   Client::Game::Event::EventSceneModuleImplBase
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct EventSceneModuleUsualImpl {
    [FieldOffset(0x00), CExporterBaseType] public EventSceneModuleImplBase ImplBase; // TODO: actual add as inheritance
}

// Client::Game::Event::EventSceneModuleImplBase
// [GenerateInterop(true)] TODO: fix inheritance chain in 7.4
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct EventSceneModuleImplBase {
    [FieldOffset(0x08)] public EventSceneModule* EventSceneModule;
}
