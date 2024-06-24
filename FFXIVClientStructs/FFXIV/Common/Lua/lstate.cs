// ReSharper disable InconsistentNaming
namespace FFXIVClientStructs.FFXIV.Common.Lua;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct lua_State {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x0A)] public byte status;
    [FieldOffset(0x10)] public TValue* top; /* first free slot in the stack */
    [FieldOffset(0x18)] public TValue* _base; /* base of current function */
    [FieldOffset(0x20)] public global_State* l_G;
    [FieldOffset(0x28)] public CallInfo* ci; /* call info for current function */
    [FieldOffset(0x30)] public uint* savedpc; /* 'savedpc' of current function */
    [FieldOffset(0x38)] public TValue* stack_last; /* last free slot in the stack */
    [FieldOffset(0x40)] public TValue* stack; /* stack base */
    [FieldOffset(0x48)] public CallInfo* end_ci; /* points after end of ci array*/
    [FieldOffset(0x50)] public CallInfo* base_ci; /* array of CallInfo's */
    [FieldOffset(0x58)] public int stacksize;
    [FieldOffset(0x5C)] public int size_ci; /* size of array 'base_ci' */
    [FieldOffset(0x60)] public ushort nCcalls; /* number of nested C calls */
    [FieldOffset(0x62)] public ushort baseCcalls; /* nested C calls when resuming coroutine */
    [FieldOffset(0x64)] public byte hookmask;
    [FieldOffset(0x65)] public byte allowhook;
    [FieldOffset(0x68)] public int basehookcount;
    [FieldOffset(0x6C)] public int hookcount;
    [FieldOffset(0x70)] public delegate* unmanaged<lua_State*, lua_Debug*, void> hook; // lua_Hook
    [FieldOffset(0x78)] public TValue l_gt; /* table of globals */
    [FieldOffset(0x88)] public TValue env; /* temporary place for environments */
    [FieldOffset(0x98)] public GCObject* openupval; /* list of open upvalues in this stack */
    [FieldOffset(0xA0)] public GCObject* gclist;
    [FieldOffset(0xA8)] public lua_longjmp* errorJmp; /* current error recover point */
    [FieldOffset(0xB0)] public long errfunc; // ptrdiff_t /* current error handling function (stack index) */

    // TODO: move functions out of lua_State and make them static. own luaapi struct maybe?

    [MemberFunction("E8 ?? ?? ?? ?? FF C7 03 F8")]
    public partial int lua_gettop();

    [MemberFunction("E8 ?? ?? ?? ?? FE CB")]
    public partial void lua_settop(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 80 38 23")]
    public partial byte* lua_tolstring(int idx, int* len);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 D0 48 8D 15")]
    public partial double lua_tonumber(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? FF CD BA")]
    public partial void lua_pushvalue(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B 06 41 8B D7")]
    public partial void lua_pushcclosure(delegate* unmanaged<lua_State*, int> fn, int n);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 56 ?? 85 D2 0F 88"), GenerateStringOverloads]
    public partial void lua_setfield(int idx, byte* k);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 48 85 ED"), GenerateStringOverloads]
    public partial void lua_getfield(int idx, byte* k);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 40 F6 C6")]
    public partial void lua_remove(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 74 39")]
    public partial int lua_pcall(int nargs, int nresults, int errfunc);

    [MemberFunction("48 83 EC 38 48 89 54 24 ?? 48 8D 15"), GenerateStringOverloads]
    public partial int luaL_loadbuffer(byte* buff, long size, byte* name);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 85 C0 75 ?? 40 84 ED"), GenerateStringOverloads]
    public partial int luaL_loadfile(byte* filename);

    [MemberFunction("E8 ?? ?? ?? ?? 3B C3 74 0D")]
    public partial LuaType lua_type(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B D3")]
    public partial TValue* index2adr(int idx);

    [MemberFunction("40 57 48 83 EC ?? BA ?? ?? ?? ?? 48 8B F9 E8 ?? ?? ?? ?? 4C 8D 05")]
    public partial int luaB_tostring();

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 ?? 0F 28 CE")]
    public partial int lua_next(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? 41 2B ED")]
    public partial void lua_pushnil();

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 26 33 D2")]
    public partial int lua_getmetatable(int idx);

    [MemberFunction("E8 ?? ?? ?? ?? FF C7 3B FE 7E")]
    public partial void lua_call(int nargs, int nresults);

    public void lua_setglobal(string s) {
        lua_setfield(-10002, s);
    }

    public void lua_getglobal(string s) {
        lua_getfield(-10002, s);
    }

    public int luaL_loadbuffer(string buff, long size) {
        return luaL_loadbuffer(buff, size, "?");
    }

    public void lua_pushcfunction(delegate* unmanaged<lua_State*, int> f) {
        lua_pushcclosure(f, 0);
    }

    public string? lua_tostring(int idx) {
        return Marshal.PtrToStringUTF8((nint)lua_tolstring(idx, null));
    }

    public void lua_pop(int n) {
        lua_settop(-n - 1);
    }

    public void lua_register(string n, delegate* unmanaged<lua_State*, int> f) {
        lua_pushcfunction(f);
        lua_setglobal(n);
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
public unsafe partial struct global_State {
    [FieldOffset(0x00)] public stringtable strt; /* hash table for strings */
    [FieldOffset(0x10)] public delegate* unmanaged<void*, void*, ulong, ulong, void*> frealloc; // lua_Alloc /* function to reallocate memory */
    [FieldOffset(0x18)] public void* ud; /* auxiliary data to 'frealloc' */
    [FieldOffset(0x20)] public byte currentwhite;
    [FieldOffset(0x21)] public byte gcstate; /* state of garbage collector */
    [FieldOffset(0x24)] public int sweepstrgc; /* position of sweep in 'strt' */
    [FieldOffset(0x28)] public GCObject* rootgc; /* list of all collectable objects */
    [FieldOffset(0x30)] public GCObject** sweepgc; /* position of sweep in 'rootgc' */
    [FieldOffset(0x38)] public GCObject* gray; /* list of gray objects */
    [FieldOffset(0x40)] public GCObject* grayagain; /* list of objects to be traversed atomically */
    [FieldOffset(0x48)] public GCObject* weak; /* list of weak tables (to be cleared) */
    [FieldOffset(0x50)] public GCObject* tmudata; /* last element of list of userdata to be GC */
    [FieldOffset(0x58)] public Mbuffer buff; /* temporary buffer for string concatenation */
    [FieldOffset(0x70)] public ulong GCthreshold; // lu_mem
    [FieldOffset(0x78)] public ulong totalbytes; // lu_mem /* number of bytes currently allocated */
    [FieldOffset(0x80)] public ulong estimate; // lu_mem /* an estimate of number of bytes actually in use */
    [FieldOffset(0x88)] public ulong gcdept; // lu_mem /* how much GC is 'behind schedule' */
    [FieldOffset(0x90)] public int gcpause; /* size of pause between successive GCs */
    [FieldOffset(0x94)] public int gcstepmul; /* GC 'granularity' */
    [FieldOffset(0x98)] public delegate* unmanaged<lua_State*, int> panic; // lua_CFunction /* to be called in unprotected errors */
    [FieldOffset(0xA0)] public TValue l_registry;
    [FieldOffset(0xB0)] public lua_State* mainthread;
    [FieldOffset(0xB8)] public UpVal uvhead; /* head of double-linked list of all open upvalues */
    [FieldOffset(0xE0), FixedSizeArray] internal FixedSizeArray9<Pointer<Table>> _mt; /* metatables for basic types */
    [FieldOffset(0x128), FixedSizeArray] internal FixedSizeArray17<Pointer<TString>> _tmname; /* array with tag-method names */
}

[StructLayout(LayoutKind.Explicit, Size = 0x268)]
internal struct LG {
    // internal just for the exporter, no defined functions use it yet
    [FieldOffset(0x00)] public lua_State l;
    [FieldOffset(0xB8)] public global_State g;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct stringtable {
    [FieldOffset(0x00)] public GCObject** hash;
    [FieldOffset(0x08)] public uint nuse; /* number of elements */
    [FieldOffset(0x0C)] public int size;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct CallInfo {
    [FieldOffset(0x00)] public TValue* _base; /* base for this function */
    [FieldOffset(0x08)] public TValue* func; /* function index in the stack */
    [FieldOffset(0x10)] public TValue* top; /* top for this function */
    [FieldOffset(0x18)] public uint* savedpc;
    [FieldOffset(0x20)] public int nresults; /* expected number of results from this function */
    [FieldOffset(0x24)] public int tailcalls; /* number of tail calls lost under this entry */
}

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public struct GCObject {
    [FieldOffset(0x00)] public GCheader gch;
    [FieldOffset(0x00)] public TString ts;
    [FieldOffset(0x00)] public Udata u;
    [FieldOffset(0x00)] public Closure cl;
    [FieldOffset(0x00)] public Table h;
    [FieldOffset(0x00)] public Proto p;
    [FieldOffset(0x00)] public UpVal uv;
    [FieldOffset(0x00)] public lua_State th; /* thread */
}
