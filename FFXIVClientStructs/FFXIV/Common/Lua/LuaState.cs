using System;
using System.Runtime.InteropServices;
using System.Text;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Common.Lua 
{
    //ctor 48 8D 05 ?? ?? ?? ?? C6 41 10 01 48 89 01 33 C0
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct LuaState
    {
        [FieldOffset(0x08)] public lua_State* State;

        public string[] DoString(string code, string name = "?")
        {
            //workaround to convert all return values to string
            code = "local t = \n(function(...)\n\tlocal t = {...}\n\tt.n = select('#', ...)\n\treturn t\nend)((function() " + code + " end)())\nfor i=1, t.n do\n\tt[i] = tostring(t[i])\nend\nreturn unpack(t)";
            var oldStack = State->lua_gettop();
            string[] results;
            try 
            {
                var strLen = stackalloc int[1];

                if (State->luaL_loadbuffer(code, code.Length, name) != 0)
                {
                    var error = State->lua_tolstring(-1, strLen);
                    throw new Exception(Encoding.UTF8.GetString(error, *strLen));
                }

                if (State->lua_pcall(0, -1, 0) != 0)
                {
                    var error = State->lua_tolstring(-1, strLen);
                    throw new Exception(Encoding.UTF8.GetString(error, *strLen));
                }

                var returnVals = State->lua_gettop() - oldStack;
                results = new string[returnVals];

                for (var i = returnVals - 1; i >= 0; i--)
                {
                    var str = State->lua_tolstring(-1, strLen);
                    if (str != null) results[i] = Encoding.UTF8.GetString(str, *strLen);
                    else results[i] = "null";
                    State->lua_settop(-2);
                }
            }
            finally
            {
                State->lua_settop(oldStack);
            }

            return results;
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

        [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 74 6F")]
        public partial int lua_pcall(int nargs, int nresults, int errfunc);

        [MemberFunction("48 83 EC 38 48 89 54 24 ?? 48 8D 15")]
        public partial int luaL_loadbuffer(string buff, int size, string name = "?");

        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7E 10")]
        public partial LuaType lua_type(int idx);

        [MemberFunction("E8 ?? ?? ?? ?? 41 8B D3")]
        public partial void* index2addr(int index);
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
        Thread
    }
}