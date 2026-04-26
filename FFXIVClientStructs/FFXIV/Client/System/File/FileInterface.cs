
namespace FFXIVClientStructs.FFXIV.Client.System.File;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)] // Size is a guess
public unsafe partial struct FileInterface {
    /// <summary>
    /// Initialized to zero when <see cref="OpenFile(char*, OpenFileMode)"/> is called, and then
    /// lazily filled out as needed in various functions.
    /// </summary>
    [FieldOffset(0x08)] public ulong CachedFileSize;
    [CExporterTypeForce("HANDLE", true)]
    [FieldOffset(0x10)] public nint PlatformHandle;
    [CExporterTypeForce("LPWIN32_FIND_DATAW", true)]
    [FieldOffset(0x18)] public void* FindData;
    [FieldOffset(0x20)] public bool IsFileOpen; // PlatformHandle is a Win32 File Handle. Close with CloseHandle()
    [FieldOffset(0x21)] public bool IsFindOpen; // PlatformHande is a Win32 Find Handle. Close with FindClose()

    /// <summary>
    /// Opens the file at the given UTF16 path using the given file mode.
    /// </summary>
    /// <param name="widePath">The path to the file to open.</param>
    /// <param name="mode">How to open the file.</param>
    /// <returns>A status code, with 1 being success.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C8 3C 01")]
    public partial byte OpenFile(char* widePath, OpenFileMode mode);

    /// <summary>
    /// Closes the open file or find operation, if any.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4D 85 FF 74 08")]
    public partial void Close();
}
