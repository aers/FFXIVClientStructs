using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe struct LuaEventHandler
{
    [FieldOffset(0x00)] public EventHandler EventHandler;
    [FieldOffset(0x210)] public LuaState* LuaState;
    [FieldOffset(0x240)] public Utf8String LuaClass;
    [FieldOffset(0x2A8)] public Utf8String LuaKey;
}