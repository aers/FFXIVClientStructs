
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileInterface
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 33 C0 48 89 41 ?? 48 89 41 ?? 66 89 41 ?? 48 8B C1", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct FileInterface : ICreatable<FileInterface> {
    /// <summary>
    /// Initialized to zero when <see cref="OpenFile(char*, OpenFileMode)"/> is called, and then
    /// lazily filled out as needed in various functions.
    /// </summary>
    [FieldOffset(0x08)] public ulong CachedFileSize;
    [FieldOffset(0x10), CExporterTypeForce("HANDLE", true)] public nint PlatformHandle;
    [FieldOffset(0x18), CExporterTypeForce("LPWIN32_FIND_DATAW", true)] public void* FindData;
    [FieldOffset(0x20)] public bool IsFileOpen; // PlatformHandle is a Win32 File Handle. Close with CloseHandle()
    [FieldOffset(0x21)] public bool IsFindOpen; // PlatformHande is a Win32 Find Handle. Close with FindClose()

    [VirtualFunction(0)]
    public partial FileInterface* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 33 F6 45 32 F6")]
    public partial FileInterface* Ctor();

    /// <summary>
    /// Opens the file at the given UTF16 path using the given file mode.
    /// </summary>
    /// <param name="widePath">The path to the file to open.</param>
    /// <param name="mode">How to open the file.</param>
    /// <returns>A status code, with 1 being success.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C8 3C 01")]
    public partial byte OpenFile(char* widePath, OpenFileMode mode);

    /// <summary>
    /// Closes the open file handle.
    /// </summary>
    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 48 8B 49 ?? FF 15 ?? ?? ?? ?? 85 C0")]
    public partial void Close();

    [MemberFunction("E8 ?? ?? ?? ?? 89 1F 33 C0")]
    public partial sbyte Read(void* buffer, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 44 24 ?? 48 03 E8")]
    public partial sbyte ReadAt(void* buffer, ulong size, ulong offset);

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C7 75 0E")]
    public partial sbyte Write(void* buffer, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 49 2B C6")]
    public partial ulong GetFileSize();
}

public enum OpenFileMode {
    Read = 0,
    Write = 1,
    Append = 2,
}
