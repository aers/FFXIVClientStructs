namespace FFXIVClientStructs.FFXIV.Client.System.Memory;

// Client::System::Memory::MemoryPool
/// <remarks>
/// Pool 0: 0x10 * 0x28000 (BlockSize * BlockCount)<br/>
/// Pool 1: 0x20 * 0x10000<br/>
/// Pool 2: 0x40 * 0x20000<br/>
/// Pool 3: 0x80 * 0x2000<br/>
/// Pool 4: 0x100 * 0x4000<br/>
/// Pool 5: 0x200 * 0x1000<br/>
/// Pool 6: 0x400 * 0x100<br/>
/// Pool 7: 0x800 * 0x100<br/>
/// Pool 8: 0x1000 * 0x100<br/>
/// Pool 9 used for MemoryPool management<br/>
/// <br/>
/// Has a fallback to DefaultSpace if not enough memory is available.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1)]
public unsafe partial struct MemoryPool {
    [MemberFunction("E8 ?? ?? ?? ?? 4C 6B F3")]
    public static partial void* Alloc(ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B 77")]
    public static partial void Free(void* pointer);
}
