using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gimmick;

// Client::Game::Gimmick::GimmickEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct GimmickEventHandler {
    [FieldOffset(0x2E0)] private void* ExcelSheetWaiter;
}
