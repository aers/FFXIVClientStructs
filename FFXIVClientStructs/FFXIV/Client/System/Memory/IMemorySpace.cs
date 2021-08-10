using FFXIVClientStructs.Common;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.System.Memory
{
    // Client::System::Memory::IMemorySpace
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct IMemorySpace
    {
        [MemberFunction("E8 ?? ?? ?? ?? 8B 75 08", IsStatic = true)]
        public static partial IMemorySpace* GetUISpace();

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
