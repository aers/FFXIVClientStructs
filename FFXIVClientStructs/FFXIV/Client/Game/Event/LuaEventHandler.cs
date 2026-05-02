using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<EventHandler>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8D BE ?? ?? ?? ?? 48 89 AE", 3, 278)]
[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public unsafe partial struct LuaEventHandler {
    [FieldOffset(0x1B8)] public LuaState* LuaState;
    [FieldOffset(0x1C0)] public LuaScriptLoader<LuaEventHandler> LuaScriptLoader;
    [FieldOffset(0x1E8)] public Utf8String LuaClass;
    [FieldOffset(0x250)] public Utf8String LuaKey;

    [FieldOffset(0x2B8)] public StdMap<uint, LuaEventHandlerLuaText> LuaTexts;
    [FieldOffset(0x2C8)] public LuaThread* LuaThread;
    [FieldOffset(0x2D0)] public uint LuaScriptVersion;
}

[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public struct LuaEventHandlerLuaText {
    [FieldOffset(0x00)] public Utf8String Key;
    [FieldOffset(0x68)] public Utf8String Value;
}
