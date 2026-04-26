using FFXIVClientStructs.FFXIV.Common;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct FileHandleManager {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 8B C6", 3, isPointer: true)]
    public static partial FileHandleManager* Instance();

    [FieldOffset(0x08)] public Spinlock Lock; // Hold this lock while reading or writing members of the file handles or the handle pointers below

    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray7<Pointer<FileHandlePage>> _pages;
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray7<Pointer<FileHandle>> _firstFreeHandles;
    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray7<Pointer<FileHandle>> _lastHandles;

    public ref FileHandle GetFileHandle(in FileHandleIndex fileHandleIndex) {
        return ref _pages[(int)fileHandleIndex.PageIndex].Value->_handles[(int)fileHandleIndex.HandleIndex];
    }
}

// Holy smokes, what an array!
[global::System.Runtime.InteropServices.StructLayoutAttribute(global::System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
[global::System.Runtime.CompilerServices.InlineArrayAttribute(8704)] // 0x2200
public struct FixedSizeArray8704<T> where T : unmanaged {
    private T _element0;
}

[StructLayout(LayoutKind.Explicit, Size = 0x44000)]
public struct FileHandlePage {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8704<FileHandle> _handles;
}
