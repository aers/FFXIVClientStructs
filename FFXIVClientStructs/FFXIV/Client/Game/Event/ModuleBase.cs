using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct ModuleBase
{
    [FieldOffset(0x08)] public LuaState* LuaState;
}