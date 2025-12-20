namespace FFXIVClientStructs.FFXIV.Client.System.Memory;

public interface ICreatable {
    public void Ctor();
}

// Client::System::Memory::IMemorySpace
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct IMemorySpace {
    public T* Create<T>() where T : unmanaged, ICreatable {
        var memory = (T*)Malloc<T>();
        if (memory is null) return null;
        Memset(memory, 0, (ulong)sizeof(T));
        memory->Ctor();
        return memory;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D B3")]
    public static partial IMemorySpace* GetDefaultSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B C8 41 8D 55")]
    public static partial IMemorySpace* GetApricotSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D B3 ?? ?? ?? ??")]
    public static partial IMemorySpace* GetAnimationSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D7 41 B8")]
    public static partial IMemorySpace* GetUISpace();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 8B CB")]
    public static partial IMemorySpace* GetSoundSpace();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 49 3B C6")]
    public static partial void CreateMemorySpaces();

    [MemberFunction("E8 ?? ?? ?? ?? FF 4B 78")]
    public static partial void Free(void* ptr, ulong size);

    [MemberFunction("4C 8B D9 0F B6 D2")]
    public static partial void Memset(void* ptr, int value, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 74 1B 48 89 28")]
    public static partial void* StaticMalloc(ulong size, ulong alignment);

    [VirtualFunction(0)]
    public partial IMemorySpace* Dtor(byte freeFlags);

    // [VirtualFunction(1)]
    // public partial ? vf1(); // calls IMemoryModule::vf1

    // vf2 has some weird params that result in calling Malloc(this, size, alignment)

    [VirtualFunction(3)]
    public partial void* Malloc(ulong size, ulong alignment);

    // vf4 has some weird params that result in calling Malloc(this, size, alignment) or AlignedMalloc(this, size, alignment) based on what memory space it is

    [VirtualFunction(5)]
    public partial void* AlignedMalloc(ulong size, ulong alignment);

    [VirtualFunction(6)]
    public partial void* AlignedRealloc(void* ptr, ulong size, ulong alignment);

    [VirtualFunction(7)]
    public partial void AlignedFree(void* ptr);

    // [VirtualFunction(8)]
    // public partial ? vf8(); // calls IMemoryModule::vf8

    [VirtualFunction(9)]
    public partial IMemoryModule* GetMemoryModule();

    // [VirtualFunction(10)]
    // public partial ? vf10(); // calls IMemoryModule::vf10

    // [VirtualFunction(11)]
    // public partial ? vf11(); // calls IMemoryModule::vf11

    // [VirtualFunction(12)]
    // public partial ? vf12(); // calls IMemoryModule::vf12

    // [VirtualFunction(13)]
    // public partial void vf13(byte unk); // setter for some flag

    // [VirtualFunction(14)]
    // public partial byte vf14(); // getter for some flag set with vf13

    // [VirtualFunction(15)]
    // public partial ? vf15(); // nullsub from what can find

    public T* Malloc<T>(ulong alignment = 8) where T : unmanaged {
        return (T*)Malloc((ulong)sizeof(T), alignment);
    }

    public static void Free<T>(T* ptr) where T : unmanaged {
        Free(ptr, (ulong)sizeof(T));
    }
}
