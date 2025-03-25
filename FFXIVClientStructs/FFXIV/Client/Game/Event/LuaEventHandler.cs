using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct LuaEventHandler {
    [FieldOffset(0x218)] public LuaState* LuaState;
    [FieldOffset(0x220)] public LuaScriptLoader<LuaEventHandler> LuaScriptLoader;
    [FieldOffset(0x248)] public Utf8String LuaClass;
    [FieldOffset(0x2B0)] public Utf8String LuaKey;

    [FieldOffset(0x318)] public StdMap<uint, LuaEventHandlerLuaText> LuaTexts;
    [FieldOffset(0x328)] public LuaThread* LuaThread;
    [FieldOffset(0x330)] public uint LuaScriptVersion;
}

[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public struct LuaEventHandlerLuaText {
    [FieldOffset(0x00)] public Utf8String Key;
    [FieldOffset(0x68)] public Utf8String Value;
}
