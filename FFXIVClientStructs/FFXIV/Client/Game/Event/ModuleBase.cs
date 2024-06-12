using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::ModuleBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct ModuleBase {
    [FieldOffset(0x08)] public LuaState* LuaState;
    [FieldOffset(0x10)] public LuaScriptLoader LuaScriptLoader;
}
