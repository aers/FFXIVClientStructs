namespace FFXIVClientStructs.FFXIV.Common.Lua;

//ctor 48 8D 05 ?? ?? ?? ?? C6 41 10 01 48 89 01 33 C0
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct LuaState
{
    [FieldOffset(0x08)] public lua_State* State;
    [FieldOffset(0x10)] public bool GCEnabled;
    [FieldOffset(0x18)] public long LastGCRestart;
    [FieldOffset(0x20)] public delegate*<lua_State*, int> db_errorfb;

    public string?[] DoString(string code, string? name = null)
    {
        var top = State->lua_gettop();
        try
        {
            if (State->luaL_loadbuffer(code, code.Length, name) != 0)
                throw new Exception($"{State->lua_tostring(-1)}");

            if (State->lua_pcall(0, -1, 0) != 0)
                throw new Exception($"{State->lua_tostring(-1)}");

            var cnt = State->lua_gettop() - top;
            var results = new string?[cnt];
            for (var i = 0; i < cnt; i++)
            {
                State->luaB_tostring();
                results[i] = State->lua_tostring(-1);
                State->lua_remove(1);
            }

            return results;
        }
        finally
        {
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

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 D0 48 8D 15")]
    public partial double lua_tonumber(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? FF CD BA")]
    public partial void lua_pushvalue(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B 06 41 8B D7")]
    public partial void lua_pushcclosure(delegate*<lua_State*, int> fn, int n);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 56 ?? 85 D2 0F 88")]
    [GenerateCStrOverloads]
    public partial void lua_setfield(int idx, byte* k);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 48 85 ED")]
    [GenerateCStrOverloads]
    public partial void lua_getfield(int idx, byte* k);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 40 F6 C6")]
    public partial void lua_remove(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 74 6F")]
    public partial int lua_pcall(int nargs, int nresults, int errfunc);

    [MemberFunction("48 83 EC 38 48 89 54 24 ?? 48 8D 15")]
    [GenerateCStrOverloads]
    public partial int luaL_loadbuffer(byte* buff, long size, byte* name);

    public int luaL_loadbuffer(string buff, long size)
    {
        return luaL_loadbuffer(buff, size, "?");
    }

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 75 ?? 40 84 ED")]
    [GenerateCStrOverloads]
    public partial int luaL_loadfile(byte* filename);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7E 10")]
    public partial LuaType lua_type(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B D3")]
    public partial void* index2adr(int idx);

    [MemberFunction("40 57 48 83 EC ?? BA ?? ?? ?? ?? 48 8B F9 E8 ?? ?? ?? ?? 4C 8D 05")]
    public partial int luaB_tostring();

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 ?? 0F 28 CE")]
    public partial int lua_next(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 41 2B ED")]
    public partial void lua_pushnil();

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 74 ?? 4C 8B C5")]
    public partial int lua_getmetatable(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? FF C7 3B FE 7E")]
    public partial void lua_call(int nargs, int nresults);

    public void lua_setglobal(string s)
    {
        lua_setfield(-10002, s);
    }

    public void lua_getglobal(string s)
    {
        lua_getfield(-10002, s);
    }
    

    public void lua_pushcfunction(delegate*<lua_State*, int> f)
    {
        lua_pushcclosure(f, 0);
    }

    public string? lua_tostring(int idx)
    {
        return Marshal.PtrToStringUTF8((nint) lua_tolstring(idx, null));
    }

    public void lua_pop(int n)
    {
        lua_settop(-n - 1);
    }
    
    public void lua_register(string n, delegate*<lua_State*, int> f)
    {
        lua_pushcfunction(f);
        lua_setglobal(n);
    }
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