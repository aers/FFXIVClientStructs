using FFXIVClientStructs.FFXIV.Client.System.File;
using FFXIVClientStructs.FFXIV.Common;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ResourceHandle
//   Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ResourceHandle {
    [FieldOffset(0x08)] public ResourceHandleType Type;

    [FieldOffset(0x0C)] public uint FileType; // "txt" "uld" etc from the header
    [FieldOffset(0x10)] public uint Id;

    [FieldOffset(0x28)] public uint FileSize; // Length of the portion of the file that this resource was loaded from
    [FieldOffset(0x2C)] public uint FileSize2; // Length of the entire file
    [FieldOffset(0x34)] public uint FileSize3;
    [FieldOffset(0x38)] public FileHandleIndex FileHandleIndex;

    // Some resource handle types allocate a blob of memory here while they load.
    // There is a hierarchy of three types involved here, all with vtables and none of which we have names for:
    // A singleton blob manager created at the end of IMemorySpace::CreateMemorySpaces, which has a pointer to an
    // implementation it delegates everything to, and then the actual blob type.
    [FieldOffset(0x40)] public byte* Blob;

    [FieldOffset(0x6C)] public byte UserData;

    [FieldOffset(0x48)] public StdString FileName; // std::string
    [FieldOffset(0x68)] public byte LastIOResult;
    [FieldOffset(0x98)] public Spinlock Lock;
    [CExporterTypeForce("LPCRITICAL_SECTION", true)]
    [FieldOffset(0xA0)] public void* LoadStateCriticalSection;
    [FieldOffset(0xA8)] public byte ReadState;
    [FieldOffset(0xA9)] public byte LoadState; // Access is (sometimes?) protected with the LoadStateCriticalSection
    [FieldOffset(0xAA)] public byte OtherState;
    [FieldOffset(0xAC)] public uint RefCount;

    public ReadOnlySpan<byte> GetDataSpan() {
        var data = GetData();
        if (data == null)
            return default;

        var length = GetLength();
        if (length > 0x7FEFFFFF)
            throw new OverflowException($"Resource too large (length {length})");

        return new(data, (int)length);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 C7 03 ?? ?? ?? ?? C6 83")]
    public partial bool DecRef();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 43 1B")]
    public partial ResourceHandle* IncRef();

    /// <summary>
    /// Loads any dependent resources (<see cref="LoadDependentResources(byte)"/>),
    /// frees any allocated temporary buffers (<see cref="Blob"/>),
    /// returns file handles (<see cref="FileHandleIndex"/>),
    /// and loads this resource (<see cref="Load(void*, byte)"/>).
    /// </summary>
    /// <param name="fileDescriptor">The file descriptor that has been read into this resource (<see cref="Read(FileDescriptor*, bool)"/>).</param>
    /// <param name="openFileResult">The result of opening the file for the file descriptor (<see cref="FileInterface.OpenFile(char*, OpenFileMode)"/>).</param>
    /// <param name="a4">Unknown. Seen: 0, 1, and 2.</param>
    /// <returns>Whether this resource handle was loaded successfully.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 80 3F 0B 75 28")]
    public partial bool FinishLoad(FileDescriptor* fileDescriptor, byte openFileResult, byte a4);

    [VirtualFunction(6u)]
    public partial byte GetUserData();

    /// <summary>
    /// Returns the size of this resource handle structure.
    /// </summary>
    [VirtualFunction(15u)]
    public partial ulong GetHandleSize();

    [VirtualFunction(17u)]
    public partial ulong GetLength();

    [VirtualFunction(19u)]
    public partial ulong GetBlobAlignment(); // Seems nothing overrides the base ResourceHandle which returns 128 bytes

    [VirtualFunction(23u)]
    public partial byte* GetData();

    // Frees any memory loaded by Read()
    [VirtualFunction(25u)]
    public partial void Close();

    [VirtualFunction(31u)]
    public partial bool LoadIntoKernel();

    [VirtualFunction(32)]
    public partial byte Read(FileDescriptor* fileDescriptor, bool failedToOpen);

    [VirtualFunction(33u)]
    public partial byte Load(void* contents, byte lastIOResult);

    // Calls Close(...) and then calls Read(...)
    [VirtualFunction(34u)]
    public partial byte Reread(FileDescriptor* fileDescriptor, bool failedToOpen);

    // Most resource types don't handle this and return -10, except for models (which load materials unless they are character models) and materials (which load textures).
    [VirtualFunction(40u)]
    public partial byte LoadDependentResources(byte loadResult);
}

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct ResourceHandleType {
    [FieldOffset(0x0), CExporterIgnore] public uint Value;
    [FieldOffset(0x0)] public HandleCategory Category;
    [FieldOffset(0x2)] private byte Unknown0A;
    [FieldOffset(0x3)] public byte Expansion;

    public static explicit operator ResourceHandleType(ResourceCategory value) {
        return new() {
            Value = (uint)value
        };
    }

    public static explicit operator ResourceCategory(ResourceHandleType value) {
        return (ResourceCategory)value.Value;
    }

    public enum HandleCategory : ushort {
        Common = 0,
        BgCommon = 1,
        Bg = 2,
        Cut = 3,
        Chara = 4,
        Shader = 5,
        Ui = 6,
        Sound = 7,
        Vfx = 8,
        UiScript = 9,
        Exd = 10,
        GameScript = 11,
        Music = 12,
        SqpackTest = 18,
        Debug = 19,
        MaxCount = 20
    }
}
