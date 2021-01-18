using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle
{
    // Client::System::Resource::Handle::ResourceHandle
    //   Client::System::Common::NonCopyable

    // size = 0xA8
    // ctor E8 ? ? ? ? 81 A3 ? ? ? ? ? ? ? ? 48 8D 05 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public unsafe struct ResourceHandle
    {
        [FieldOffset(0x12)] public uint FileType; // "txt" "uld" etc from the header
        [FieldOffset(0x48)] public char* FileName;
    }
}
