namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
// Client::System::Resource::Handle::ResourceHandle
//   Client::System::Common::NonCopyable

// size = 0xB0
// ctor E8 ?? ?? ?? ?? 81 A3 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ResourceHandle {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x00)] public void** vfunc;
    [FieldOffset(0x08)] public ResourceCategory Category;

    [FieldOffset(0x0C)] public uint FileType; // "txt" "uld" etc from the header
    [FieldOffset(0x10)] public uint Id;

    [FieldOffset(0x28)] public uint FileSize;
    [FieldOffset(0x2C)] public uint FileSize2;
    [FieldOffset(0x34)] public uint FileSize3;

    [FieldOffset(0x6C)] public byte UserData;

    [FieldOffset(0x48)] public StdString FileName; // std::string
    [FieldOffset(0xA9)] public byte LoadState;
    [FieldOffset(0xAC)] public int RefCount;

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
