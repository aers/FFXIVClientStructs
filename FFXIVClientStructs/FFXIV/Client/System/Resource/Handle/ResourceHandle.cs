namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ResourceHandle
//   Client::System::Common::NonCopyable
// ctor "E8 ?? ?? ?? ?? 81 A3 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05"
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ResourceHandle {
    [FieldOffset(0x00), CExportIgnore] public void* vtbl;
    [FieldOffset(0x00), CExportIgnore] public void** vfunc;

    [FieldOffset(0x08)] public ResourceHandleType Type;

    [FieldOffset(0x0C)] public uint FileType; // "txt" "uld" etc from the header
    [FieldOffset(0x10)] public uint Id;

    [FieldOffset(0x28)] public uint FileSize;
    [FieldOffset(0x2C)] public uint FileSize2;
    [FieldOffset(0x34)] public uint FileSize3;

    [FieldOffset(0x6C)] public byte UserData;

    [FieldOffset(0x48)] public StdString FileName; // std::string
    [FieldOffset(0xA9)] public byte LoadState;
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

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 46 30 C1 E0 05")]
    public partial bool IncRef();

    [VirtualFunction(6u)]
    public partial byte GetUserData();

    [VirtualFunction(17u)]
    public partial ulong GetLength();

    [VirtualFunction(23u)]
    public partial byte* GetData();

    [VirtualFunction(31u)]
    public partial bool LoadIntoKernel();

    [VirtualFunction(33u)]
    public partial bool Load(void* contents, bool flag);
}

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct ResourceHandleType {
    [FieldOffset(0x0), CExportIgnore] public uint Value;
    [FieldOffset(0x0)] public HandleCategory Category;
    [FieldOffset(0x2)] public byte Unknown0A;
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
