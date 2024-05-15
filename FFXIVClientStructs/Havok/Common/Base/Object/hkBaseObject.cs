namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct hkBaseObject {
    [FieldOffset(0x00)] public hkBaseObjectVtbl* vfptr;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct hkBaseObjectVtbl {
        [FieldOffset(0x00)] public void* dtor;
        [FieldOffset(0x08)] public void* __first_virtual_table_function__;
    }
}
