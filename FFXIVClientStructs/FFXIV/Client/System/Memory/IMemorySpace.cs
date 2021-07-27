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

        [VirtualFunction(3)]
        public partial void* Malloc(ulong size, ulong alignment);
    }
}
