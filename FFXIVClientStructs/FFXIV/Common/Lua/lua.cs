// ReSharper disable InconsistentNaming
namespace FFXIVClientStructs.FFXIV.Common.Lua;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct lua_Debug {
    [FieldOffset(0x00)] public int _event;
    [FieldOffset(0x08)] public byte* name; /* (n) */
    [FieldOffset(0x10)] public byte* namewhat; /* (n) 'global', 'local', 'field', 'method' */
    [FieldOffset(0x18)] public byte* what; /* (S) 'Lua', 'C', 'main', 'tail' */
    [FieldOffset(0x20)] public byte* source; /* (S) */
    [FieldOffset(0x28)] public int currentline; /* (l) */
    [FieldOffset(0x2C)] public int nups; /* (u) number of upvalues */
    [FieldOffset(0x30)] public int linedefined; /* (S) */
    [FieldOffset(0x34)] public int lastlinedefined; /* (S) */
    [FieldOffset(0x38), FixedSizeArray(true)] internal FixedSizeArray60<byte> _short_src; /* (S) */
    /* private part */
    [FieldOffset(0x74)] public int i_ci; /* active function */
}
