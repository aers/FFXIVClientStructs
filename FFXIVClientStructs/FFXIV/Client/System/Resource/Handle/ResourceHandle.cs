using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle
{
    // Client::System::Resource::Handle::ResourceHandle
    //   Client::System::Common::NonCopyable

    // size = 0xB0
    // ctor E8 ? ? ? ? 81 A3 ? ? ? ? ? ? ? ? 48 8D 05 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe partial struct ResourceHandle
    {
        [FieldOffset(0x08)] public uint Category;
        [FieldOffset(0x0C)] public uint FileType; // "txt" "uld" etc from the header
        [FieldOffset(0x10)] public uint Id;
        [FieldOffset(0x48)] public FFXIVClientStructs.STD.String FileName; // std::string
        [FieldOffset(0xAC)] public uint RefCount;

        [MemberFunction("48 85 ?? 75 ?? 32 C0 ?? 45 8B")]
        public partial bool DecRef();

        [MemberFunction("?? 89 ?? ?? ?? ?? 89 ?? ?? ?? ?? 89 ?? ?? ?? 57 41 ?? 41 ?? 48 83 ?? ?? 48 8B ?? ?? ?? ?? ?? 41 8B ?? 4C")]
        public partial bool IncRef();
    }
}