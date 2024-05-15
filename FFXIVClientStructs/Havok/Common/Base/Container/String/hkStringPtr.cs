namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct hkStringPtr {
    [FieldOffset(0x00)] public byte* StringAndFlag;

    public string? String => Marshal.PtrToStringUTF8((IntPtr)((ulong)StringAndFlag & ~1LU));
}
