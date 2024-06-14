// ReSharper disable InconsistentNaming
namespace FFXIVClientStructs.FFXIV.Common.Lua;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct lua_longjmp {
    /* chain list of long jump buffers */
    [FieldOffset(0x00)] public lua_longjmp* previous;
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray16<jmp_buf> _b;
    [FieldOffset(0x110)] public volatile int status; /* error code */

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct jmp_buf {
        [FieldOffset(0x00)] public fixed ulong Part[2];
    }
}
