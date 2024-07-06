namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

// collider framework uses simple pools to allocate some types of objects
// each pool allocates pages that can store N objects of the same size
// each page consists of a page header followed by N entries
// each entry consists of an entry header followed by buffer of size equal to object's size, rounded up to multiple of 16
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct MemoryPool {
    [FieldOffset(0x0)] public MemoryPoolPageHeader* FirstAllocatedPage; // linked list of all pages allocated for the pool
    [FieldOffset(0x8)] public MemoryPoolPageHeader* FirstActivePage; // linked list containing a subset of pages with free entries available
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct MemoryPoolPageHeader {
    [FieldOffset(0x00)] public MemoryPoolPageHeader* NextAllocatedPage;
    [FieldOffset(0x08)] public MemoryPoolPageHeader* PrevAllocatedPage;
    [FieldOffset(0x10)] public MemoryPoolPageHeader* NextActivePage;
    [FieldOffset(0x18)] public MemoryPoolPageHeader* PrevActivePage;
    [FieldOffset(0x20)] public uint FreeEntriesMask; // bit i is set if i'th entry is free
    [FieldOffset(0x24)] public ushort EntrySize; // includes entry header
    [FieldOffset(0x26)] public byte NumEntriesUsed; // given out to the pool's user
    [FieldOffset(0x27)] public byte NumEntriesTotal; // allocated as part of the page
    [FieldOffset(0x28)] public bool IsActive; // true if in 'active' page linked list
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct MemoryPoolEntryHeader {
    [FieldOffset(0x0)] public MemoryPoolPageHeader* Page;
    [FieldOffset(0x8)] public uint Index; // index of the entry inside page
}
