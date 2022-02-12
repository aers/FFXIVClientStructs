using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe struct LuaActor
{
    [FieldOffset(0x08)] public GameObject* Object;
    [FieldOffset(0x10)] public Utf8String LuaString;
    [FieldOffset(0x78)] public LuaState* LuaState;
}