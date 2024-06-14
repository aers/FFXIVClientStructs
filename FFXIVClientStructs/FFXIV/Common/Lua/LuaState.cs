namespace FFXIVClientStructs.FFXIV.Common.Lua;

// Common::Lua::LuaState
//ctor "48 8D 05 ?? ?? ?? ?? C6 41 10 01 48 89 01 33 C0"
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct LuaState {
    [FieldOffset(0x08)] public lua_State* State;
    [FieldOffset(0x10)] public bool GCEnabled;
    [FieldOffset(0x18)] public long LastGCRestart;
    [FieldOffset(0x20)] public delegate*unmanaged<lua_State*, int> db_errorfb;

    public string?[] DoString(string code, string? name = null) {
        var top = State->lua_gettop();
        try {
            if (State->luaL_loadbuffer(code, code.Length, name) != 0)
                throw new Exception($"{State->lua_tostring(-1)}");

            if (State->lua_pcall(0, -1, 0) != 0)
                throw new Exception($"{State->lua_tostring(-1)}");

            var cnt = State->lua_gettop() - top;
            var results = new string?[cnt];
            for (var i = 0; i < cnt; i++) {
                State->luaB_tostring();
                results[i] = State->lua_tostring(-1);
                State->lua_remove(1);
            }

            return results;
        } finally {
            State->lua_settop(top);
        }
    }
}

public enum LuaType {
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
