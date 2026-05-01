namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::LinkList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct LinkList {
    [VirtualFunction(0)]
    public partial LinkList* Dtor(byte freeFlags);
}

// Common::Component::Excel::LinkList<T>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public unsafe struct LinkList<T> where T : unmanaged {
    [CExporterBaseType] public LinkList Base;
    public T* Previous;
    public T* Next;
}
