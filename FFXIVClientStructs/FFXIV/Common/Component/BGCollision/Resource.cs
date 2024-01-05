using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct Resource {
    //[FieldOffset(0x08)] public void* VTable8; // unknown base class
    [FieldOffset(0x10)] public Resource* PrevResource;
    [FieldOffset(0x18)] public Resource* NextResource;
    [FieldOffset(0x20)] public ResourceHandle* Handle;
    [FieldOffset(0x28)] public fixed byte Path[80];
    [FieldOffset(0x78)] public void* Listener; // Common::Component::Excel::ExcelResourceListener
    //[FieldOffset(0x80)] public long u80; - some argument passed to StartLoad and returned by vf6

    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial byte* GetPath();

    [VirtualFunction(2)]
    public partial bool LoadSucceeded();

    [VirtualFunction(3)]
    public partial bool LoadFailed();

    [VirtualFunction(4)]
    public partial byte* GetData();

    [VirtualFunction(5)]
    public partial uint GetSize();
}
