using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

// inlined ctor, see FileManager ctor

/// <summary>
/// Describes a filesystem operation to be performed.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe partial struct FileDescriptor {
    [FieldOffset(0x0)] public FileMode FileMode;
    /// <summary>
    /// If <see cref="FileMode"/> is not a one of the <see cref="Resource.Handle.ResourceHandle"/>-reading modes,
    /// this holds the buffer to read into or write from, or <c>null</c> to allocate a new buffer in the FileHandle
    /// specified by <see cref="FileHandleIndex"/>.
    /// </summary>
    [FieldOffset(0x8)] public byte* FileBuffer;
    [Obsolete("Replaced by Length.")]
    [FieldOffset(0x10)] public ulong FileLength; // Misleading name--not necessarily the length of the file
    /// <summary>
    /// The amount of data to be read from or written to the <see cref="FileBuffer"/> or <see cref="ResourceHandle"/>
    /// (depending on <see cref="FileMode"/>).
    /// </summary>
    /// <remarks>
    /// Set to zero to read the rest of the file, starting at <see cref="StartOffset"/>.
    /// </remarks>
    [FieldOffset(0x10)] public ulong Length;
    [Obsolete("Replaced by StartOffset")]
    [FieldOffset(0x18)] public ulong CurrentFileOffset; // Misleading name--not related to any 'current' state
    /// <summary>
    /// The offset in the file to start reading from/writing to.
    /// </summary>
    [FieldOffset(0x18)] public ulong StartOffset;
    [FieldOffset(0x28)] public FileHandleIndex FileHandleIndex;
    [FieldOffset(0x30)] public FileInterface* FileInterface;
    /// <summary>
    /// If <see cref="FileMode"/> is <see cref="FileMode.LoadFileResource"/> and <see cref="FileBuffer"/> is <c>null</c>,
    /// this value specifies the alignment of the buffer that is allocated to hold the data that is read.
    /// </summary>
    [FieldOffset(0x38)] public ulong AllocationAlignment;
    /// <summary>
    /// If <see cref="FileMode"/> is <see cref="FileMode.LoadFileResource"/> and <see cref="FileBuffer"/> is <c>null</c>,
    /// this value specifies the memory space to use to allocate a buffer to hold the data that is read.
    /// </summary>
    [FieldOffset(0x48)] public IMemorySpace* AllocationMemorySpace;
    /// <summary>
    /// If <see cref="FileMode"/> is <see cref="FileMode.LoadUnpackedResource"/> or <see cref="FileMode.LoadSqPackResource"/>,
    /// this value specifies the <see cref="ResourceHandle"/> to load the data into.
    /// </summary>
    [FieldOffset(0x50)] public ResourceHandle* ResourceHandle;
    [FieldOffset(0x60)] public FileDescriptor* Previous; // believe its a queue
    [FieldOffset(0x68)] public FileDescriptor* Next;

    // This is unioned with other fields for sqpack-related file modes
    [FieldOffset(0x70), FixedSizeArray(isString: true)] internal FixedSizeArray260<char> _filePath;

    /// <summary>
    /// The wide-character path of the file to read from or write to, if the <see cref="FileMode"/> is
    /// one of the modes that operates on plain files on disk.
    /// </summary>
    public Span<char> FilePathSpan => _filePath;
}
