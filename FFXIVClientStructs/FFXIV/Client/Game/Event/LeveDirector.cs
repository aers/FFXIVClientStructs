namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LeveDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0x510)]
public partial struct LeveDirector {
    [FieldOffset(0x4C0)] public ushort LeveId;

    [FieldOffset(0x4C4)] public int IconVfx;
    [FieldOffset(0x4C8)] public int IconVfxFrame;
    [FieldOffset(0x4CC)] public int IconCityState;
    [FieldOffset(0x4D0)] public int ClassJobLevel;

    [FieldOffset(0x4D8)] public int MaxDifficulty;

    [FieldOffset(0x4DC)] public int LeveVfxId;
    [FieldOffset(0x4E0)] public int LeveVfxFrameId;
}
