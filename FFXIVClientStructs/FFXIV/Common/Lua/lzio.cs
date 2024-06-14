namespace FFXIVClientStructs.FFXIV.Common.Lua;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct Mbuffer {
    [FieldOffset(0x00)] public byte* buffer; // char*
    [FieldOffset(0x08)] public ulong n;
    [FieldOffset(0x10)] public ulong buffsize;
}
