using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle
{
    // Client::System::Resource::Handle::ResourceHandle
    //   Client::System::Common::NonCopyable

    // size = 0xB0
    // ctor E8 ? ? ? ? 81 A3 ? ? ? ? ? ? ? ? 48 8D 05 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct ResourceHandle
    {
        [FieldOffset(0x08)] public uint Category;
        [FieldOffset(0x0C)] public uint FileType; // "txt" "uld" etc from the header
        [FieldOffset(0x10)] public uint Id;
        [FieldOffset(0x48)] public FFXIVClientStructs.STD.String FileName; // std::string
    }
}