using FFXIVClientStructs.Attributes;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.System.Memory
{
    public interface ICreatable
    {
        public void Ctor();
    }
    
    // Client::System::Memory::IMemorySpace
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct IMemorySpace
    {
        public T* Create<T>() where T : unmanaged, ICreatable
        {
            var memory = (T*) Malloc<T>();
            if (memory is null) return null;
            Memset(memory, 0, (ulong)sizeof(T));
            memory->Ctor();
            return memory;
        }

        [MemberFunction("E8 ? ? ? ? 4C 8B 4C 24 ? 4C 8B C0", IsStatic = true)]
        public static partial IMemorySpace* GetDefaultSpace();

        [MemberFunction("E8 ? ? ? ? 8D 53 47 48 8B C8", IsStatic = true)]
        public static partial IMemorySpace* GetApricotSpace();

        [MemberFunction("E8 ? ? ? ? 48 89 44 24 ? E8 ? ? ? ? 48 89 44 24 ? E8 ? ? ? ? 48 89 44 24 ? E8 ? ? ? ? 33 ED",
            IsStatic = true)]
        public static partial IMemorySpace* GetAnimationSpace();

        [MemberFunction("E8 ?? ?? ?? ?? 8B 75 08", IsStatic = true)]
        public static partial IMemorySpace* GetUISpace();

        [MemberFunction("E8 ? ? ? ? 4C 8B C8 8B CF", IsStatic = true)]
        public static partial IMemorySpace* GetSoundSpace();

        [MemberFunction("E8 ? ? ? ? FF 4E 68", IsStatic = true)]
        public static partial void Free(void* ptr, ulong size);

        [MemberFunction("4C 8B D9 0F B6 D2", IsStatic = true)]
        public static partial void Memset(void* ptr, int value, ulong size);

        [VirtualFunction(3)]
        public partial void* Malloc(ulong size, ulong alignment);
        
        public void* Malloc<T>(ulong alignment = 8) where T : unmanaged => Malloc((ulong)sizeof(T), alignment);

        public static void Free<T>(T* ptr) where T : unmanaged => Free(ptr, (ulong)sizeof(T));
    }
}
