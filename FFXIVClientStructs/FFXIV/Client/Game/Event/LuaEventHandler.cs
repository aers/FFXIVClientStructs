using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaEventHandler
//   Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 44 8B CB"
[GenerateInterop(isInherited: true)]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe partial struct LuaEventHandler {
    [FieldOffset(0x210)] public LuaState* LuaState;
    [FieldOffset(0x240)] public Utf8String LuaClass;
    [FieldOffset(0x2A8)] public Utf8String LuaKey;
}
