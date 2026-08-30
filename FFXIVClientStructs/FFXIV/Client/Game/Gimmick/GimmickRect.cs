namespace FFXIVClientStructs.FFXIV.Client.Game.Gimmick;

// Client::Game::Gimmick::GimmickRect
//   Client::Game::Gimmick::GimmickEventHandler
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<GimmickEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x318)]
public unsafe partial struct GimmickRect {
    [FieldOffset(0x310)] private byte Unk310;
    /// <summary> Whether this GimmickRect is active or not. For example, an inactive dungeon entrance GimmickRect doesn't do anything when walked into. </summary>
    [FieldOffset(0x311)] public bool Active;
}
