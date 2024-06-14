// ReSharper disable InconsistentNaming
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Common.Lua;

[StructLayout(LayoutKind.Explicit, Size = 0x0A)]
public unsafe struct GCheader {
    // struct version of the CommonHeader macro
    [FieldOffset(0x00)] public GCObject* next;
    [FieldOffset(0x08)] public byte tt;
    [FieldOffset(0x09)] public byte marked;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct TString {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x0A)] public byte reserved;
    [FieldOffset(0x0C)] public uint hash;
    [FieldOffset(0x10)] public ulong len;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct Udata {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x10)] public Table* metatable;
    [FieldOffset(0x18)] public Table* env;
    [FieldOffset(0x20)] public ulong len;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct Table {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x0A)] public byte flags; /* 1<<p means tagmethod(p) is not present */ 
    [FieldOffset(0x0B)] public byte lsizenode; /* log2 of size of 'node' array */
    [FieldOffset(0x10)] public Table* metatable;
    [FieldOffset(0x18)] public TValue* array; /* array part */
    [FieldOffset(0x20)] public Node* node;
    [FieldOffset(0x28)] public Node* lastfree; /* any free position is before this position */
    [FieldOffset(0x30)] public GCObject* gclist;
    [FieldOffset(0x38)] public int sizearray; /* size of 'array' array */
}

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct Value {
    // Union of all Lua values
    [FieldOffset(0x00)] public GCObject* gc;
    [FieldOffset(0x00)] public void* p;
    [FieldOffset(0x00)] public double n;
    [FieldOffset(0x00)] public int b;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct TValue {
    [FieldOffset(0x00)] public Value value;
    [FieldOffset(0x08)] public int tt;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct TKey {
    [FieldOffset(0x00)] public TValue tvk;
    [FieldOffset(0x10)] public Node* next; /* for chaining */
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct Node {
    [FieldOffset(0x00)] public TValue i_val;
    [FieldOffset(0x10)] public TKey i_key;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct UpVal {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x10)] public TValue* v; /* points to stack or to its own value */
    [FieldOffset(0x18), CExporterUnion("u")] public TValue value; /* the value (when closed) */
    [FieldOffset(0x18), CExporterUnion("u", "l", true)] public UpVal* prev; /* double linked list (when open) */
    [FieldOffset(0x20), CExporterUnion("u", "l", true)] public UpVal* next;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct CClosure {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x0A)] public byte isC;
    [FieldOffset(0x0B)] public byte nupvalues;
    [FieldOffset(0x10)] public GCObject* gclist;
    [FieldOffset(0x18)] public Table* env;
    // end of ClosureHeader
    [FieldOffset(0x20)] public delegate*unmanaged<lua_State*, int> f; // lua_CFunction
    [FieldOffset(0x28)] internal TValue _upvalue;  // TValue upvalue[1];
    public Span<TValue> upvalue => new(Unsafe.AsPointer(ref _upvalue), nupvalues);
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct LClosure {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x0A)] public byte isC;
    [FieldOffset(0x0B)] public byte nupvalues;
    [FieldOffset(0x10)] public GCObject* gclist;
    [FieldOffset(0x18)] public Table* env;
    // end of ClosureHeader
    [FieldOffset(0x20)] public Proto* p;
    [FieldOffset(0x28)] internal UpVal* _upvals; // UpVal* upvals[1];
    public Span<Pointer<UpVal>> upvals {
        get {
            fixed (UpVal** ptr = &_upvals)
                return new Span<Pointer<UpVal>>(ptr, nupvalues);
        }
    }
}

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public struct Closure {
    [FieldOffset(0x00)] public CClosure c;
    [FieldOffset(0x00)] public LClosure l;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct LocVar {
    [FieldOffset(0x00)] public TString* varname;
    [FieldOffset(0x08)] public int startpc; /* first point where variable is active */
    [FieldOffset(0x0C)] public int endpc; /* first point where variable is dead */
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct Proto {
    [FieldOffset(0x00)] public GCheader gch; // CommonHeader
    [FieldOffset(0x10)] public TValue *k; /* constants used by the function */
    [FieldOffset(0x18)] public uint* code;
    [FieldOffset(0x20)] public Proto** p; /* functions defined inside the function */
    [FieldOffset(0x28)] public int* lineinfo; /* map from opcodes to source lines */
    [FieldOffset(0x30)] public LocVar* locvars; /* information about local variables */
    [FieldOffset(0x38)] public TString** upvalues; /* upvalue names */
    [FieldOffset(0x40)] public TString* source;
    [FieldOffset(0x48)] public int sizeupvalues;
    [FieldOffset(0x4C)] public int sizek; /* size of 'k' */
    [FieldOffset(0x50)] public int sizecode;
    [FieldOffset(0x54)] public int sizelineinfo;
    [FieldOffset(0x58)] public int sizep; /* size of 'p' */
    [FieldOffset(0x5C)] public int sizelocvars;
    [FieldOffset(0x60)] public int linedefined;
    [FieldOffset(0x64)] public int lastlinedefined;
    [FieldOffset(0x68)] public GCObject* gclist;
    [FieldOffset(0x70)] public byte nups; /* number of upvalues */
    [FieldOffset(0x71)] public byte numparams;
    [FieldOffset(0x72)] public byte is_vararg;
    [FieldOffset(0x73)] public byte maxstacksize;
}
