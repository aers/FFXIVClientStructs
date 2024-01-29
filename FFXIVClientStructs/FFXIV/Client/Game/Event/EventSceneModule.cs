namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneModule
// ctor "E8 ?? ?? ?? ?? 33 F6 49 8D 8D ?? ?? ?? ?? 41 89 B5"
[StructLayout(LayoutKind.Explicit, Size = 0x31C0)]
public unsafe struct EventSceneModule {
    [FieldOffset(0x00)] public EventSceneModuleUsualImpl EventSceneModuleUsualImpl;
    [FieldOffset(0x10)] public EventSceneModuleImplBase EventSceneModuleImplBase;
    [FieldOffset(0x20)] public EventSceneModuleImplBase* EventSceneModuleImpl;
    [FieldOffset(0x1F0)] public EventGPoseController EventGPoseController;
}
