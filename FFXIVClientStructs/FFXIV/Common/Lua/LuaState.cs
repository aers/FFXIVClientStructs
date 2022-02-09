using System;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Common.Lua 
{
    //ctor 48 8D 05 ?? ?? ?? ?? C6 41 10 01 48 89 01 33 C0
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct LuaState
    {
        [FieldOffset(0x08)] public lua_State* State;
        [FieldOffset(0x20)] public delegate*<lua_State*, int> db_errorfb;

        public string[] DoString(string code, string name = null) {
            var top = State->lua_gettop();
            try {
                if (State->luaL_loadbuffer(code, code.Length, name) != 0)
                    throw new Exception($"{Marshal.PtrToStringUTF8((nint)State->lua_tolstring(-1, null))}");

                if (State->lua_pcall(0, -1, 0) != 0)
                    throw new Exception($"{Marshal.PtrToStringUTF8((nint)State->lua_tolstring(-1, null))}");

                var cnt = State->lua_gettop() - top;
                var results = new string[cnt];
                for (var i = 0; i < cnt; i++) {
                    State->luaB_tostring();
                    results[i] = Marshal.PtrToStringUTF8((nint)State->lua_tolstring(-1, null));
                    State->lua_remove(1);
                }
                return results;
            } finally {
                State->lua_settop(top);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe partial struct lua_State
    {
        [MemberFunction("E8 ?? ?? ?? ?? FF C7 03 F8")]
        public partial int lua_gettop();

        [MemberFunction("E8 ?? ?? ?? ?? 48 83 EB 04")]
        public partial void lua_settop(int idx);

        [MemberFunction("E8 ?? ?? ?? ?? 80 38 23")]
        public partial byte* lua_tolstring(int idx, int* len);

        [MemberFunction("E8 ?? ?? ?? ?? FF CD BA")]
        public partial void lua_pushvalue(int idx);

        [MemberFunction("E8 ?? ?? ?? ?? 33 C9 40 F6 C6")]
        public partial void lua_remove(int idx);

        [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 74 6F")]
        public partial int lua_pcall(int nargs, int nresults, int errfunc);

        [MemberFunction("48 83 EC 38 48 89 54 24 ?? 48 8D 15")]
        public partial int luaL_loadbuffer(string buff, long size, string name = "?");

        [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 75 ?? 40 84 ED")]
        public partial int luaL_loadfile(string filename);

        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7E 10")]
        public partial LuaType lua_type(int idx);

        [MemberFunction("E8 ?? ?? ?? ?? 41 8B D3")]
        public partial void* index2adr(int idx);

        [MemberFunction("40 57 48 83 EC ?? BA ?? ?? ?? ?? 48 8B F9 E8 ?? ?? ?? ?? 4C 8D 05")]
        public partial int luaB_tostring();
    }

    public enum LuaType
    {
        None = -1,
        Nil,
        Boolean,
        LightUserData,
        Number,
        String,
        Table,
        Function,
        UserData,
        Thread,
        Proto,
        Upval
    }
}