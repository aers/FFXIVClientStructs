namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LeveDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0x4B0)]
public partial struct LeveDirector {
    [FieldOffset(0x460)] public ushort LeveId;

    [FieldOffset(0x464)] public int IconVfx;
    [FieldOffset(0x468)] public int IconVfxFrame;
    [FieldOffset(0x46C)] public int IconCityState;
    [FieldOffset(0x470)] public int ClassJobLevel;

    [FieldOffset(0x478)] public int MaxDifficulty;

    [FieldOffset(0x47C)] public int LeveVfxId;
    [FieldOffset(0x480)] public int LeveVfxFrameId;
}
