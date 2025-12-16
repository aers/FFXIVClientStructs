using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.MassivePcContent;

// Client::Game::MassivePcContent::MassivePcContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0x918)]
public unsafe partial struct MassivePcContentDirector {
    [FieldOffset(0x600), FixedSizeArray] internal FixedSizeArray2<StdVector<MassivePcContentTodo>> _massivePcContentTodos;
}
