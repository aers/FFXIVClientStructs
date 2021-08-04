using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Common.Lua {
    //ctor 48 8D 05 ?? ?? ?? ?? C6 41 10 01 48 89 01 33 C0
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct LuaState {
        [FieldOffset(0x08)] public void* lua_state;
    }
}