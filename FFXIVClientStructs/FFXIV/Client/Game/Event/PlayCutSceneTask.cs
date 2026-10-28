namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::PlayCutSceneTask
//   Client::Game::Event::EventSceneTaskInterface
[GenerateInterop]
[Inherits<EventSceneTaskInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public partial struct PlayCutSceneTask {
    [FieldOffset(0x10)] public Utf8String CutscenePath;
    [FieldOffset(0x78)] public uint CutsceneId;
    [FieldOffset(0x7C)][FixedSizeArray] internal FixedSizeArray4<int> _cutsceneArgs;
    [FieldOffset(0x8C)] public bool IsCutSceneControllerCreated;
    [FieldOffset(0x8D)] public bool HasPlaybackBegun;
    [FieldOffset(0x8F)] private bool Unk8F;
}
