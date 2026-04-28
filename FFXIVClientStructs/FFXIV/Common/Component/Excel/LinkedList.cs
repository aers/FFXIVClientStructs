namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct LinkedList {
    [VirtualFunction(0)]
    public partial LinkedList* Dtor(byte freeFlags);
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public unsafe struct LinkedList<T> where T : unmanaged {
    [CExporterBaseType] public LinkedList* Base;
    public T* Previous;
    public T* Next;
}