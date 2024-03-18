namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::GoldSaucerDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0x678)]
public unsafe struct GoldSaucerDirector {
    [FieldOffset(0)] public Director Director;
}
