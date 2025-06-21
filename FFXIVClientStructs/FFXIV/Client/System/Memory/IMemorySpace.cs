namespace FFXIVClientStructs.FFXIV.Client.System.Memory;

public interface ICreatable {
    public void Ctor();
}

// Client::System::Memory::IMemorySpace
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct IMemorySpace {
    public T* Create<T>() where T : unmanaged, ICreatable {
        var memory = Calloc<T>(1);
        if (memory is null) return null;
        memory->Ctor();
        return memory;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 4C 24 ?? 4C 8B C0")]
    public static partial IMemorySpace* GetDefaultSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 50")]
    public static partial IMemorySpace* GetApricotSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D B3 ?? ?? ?? ??")]
    public static partial IMemorySpace* GetAnimationSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 08")]
    public static partial IMemorySpace* GetUISpace();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 8B CB")]
    public static partial IMemorySpace* GetSoundSpace();

    [MemberFunction("E8 ?? ?? ?? ?? FF 4B 78")]
    public static partial void Free(void* ptr, ulong size);

    [MemberFunction("4C 8B D9 0F B6 D2")]
    public static partial void Memset(void* ptr, int value, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 74 16 48 3B FB")]
    public static partial void* Realloc(void* ptr, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 4C 8B E8")]
    public static partial void* Calloc(ulong count, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 48 8B D8 E8 ?? ?? ?? ?? 48 85 DB 74 20")]
    public static partial void* Recalloc(void* ptr, ulong count, ulong size);

    [VirtualFunction(3)]
    public partial void* Malloc(ulong size, ulong alignment);

    public void* Malloc<T>(ulong alignment = 8) where T : unmanaged // TODO: return T*
        => Malloc((ulong)sizeof(T), alignment);

    public static T* Calloc<T>(ulong count) where T : unmanaged
        => (T*)Calloc(count, (ulong)sizeof(T));

    public static T* Recalloc<T>(T* ptr, ulong count) where T : unmanaged
        => (T*)Recalloc(ptr, count, (ulong)sizeof(T));

    public static void Free<T>(T* ptr) where T : unmanaged
        => Free(ptr, (ulong)sizeof(T));
}
