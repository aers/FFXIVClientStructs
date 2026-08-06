namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::PlayCutSceneTask
//   Client::Game::Event::EventSceneTaskInterface
[GenerateInterop]
[Inherits<EventSceneTaskInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public partial struct PlayCutSceneTask {
    [FieldOffset(0x10)] public Utf8String CutscenePath;
    [FieldOffset(0x78)] public uint CutsceneId;
    [FieldOffset(0x7C)] private uint Unk7C;
    [FieldOffset(0x80)] private uint Unk80;
    [FieldOffset(0x84)] private uint Unk84;
    [FieldOffset(0x88)] private uint Unk88;
    [FieldOffset(0x8C)] public bool IsCutSceneControllerCreated;
    [FieldOffset(0x8D)] private bool Unk8D;

    [FieldOffset(0x8F)] private bool Unk8F;
}
