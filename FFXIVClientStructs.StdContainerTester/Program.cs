using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.StdContainerTester;

public static class Program {
    private static readonly nint[] TestMemorySpace = GC.AllocateArray<nint>(5, true);
    private static readonly Dictionary<nuint, nuint> KnownAllocations = new();

    public static void Main() {
        SetupMemorySpaceFunctions();
        do {
            StringTester.Test();
            Console.WriteLine();
            
            VectorTester.Test();
            Console.WriteLine();

            if (KnownAllocations.Any(x => x.Value != default))
                throw new InvalidOperationException("Malloc/Free mismatch (end)");
        } while (false);
    }

    private static unsafe void SetupMemorySpaceFunctions() {
        TestMemorySpace[0] = (nint)Unsafe.AsPointer(ref TestMemorySpace[1]);
        TestMemorySpace[4] = (nint)(delegate* unmanaged[Stdcall]<void*, ulong, ulong, void*>)&MallocImpl;
        IMemorySpace.Addresses.GetDefaultSpace.Value = (nuint)(delegate* unmanaged[Stdcall] <IMemorySpace*>)&GetDefaultSpaceImpl;
        IMemorySpace.Addresses.Free.Value = (nuint)(delegate* unmanaged[Stdcall] <void*, ulong, void>)&FreeImpl;
        return;

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        static IMemorySpace* GetDefaultSpaceImpl() => (IMemorySpace*)Unsafe.AsPointer(ref TestMemorySpace[0]);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        static void* MallocImpl(void* unused, ulong size, ulong alignment) {
            var ptr = NativeMemory.AlignedAlloc((nuint)size, (nuint)alignment);
            KnownAllocations[(nuint)ptr] = (nuint)size;
            return ptr;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        static void FreeImpl(void* ptr, ulong size) {
            if (!KnownAllocations.TryGetValue((nuint)ptr, out var expectedSize))
                throw new InvalidOperationException("Malloc/Free mismatch (free)");
            if (expectedSize != size)
                throw new InvalidOperationException("Free size mismatch");
            KnownAllocations[(nuint)ptr] = 0;
            NativeMemory.AlignedFree(ptr);
        }
    }
}
