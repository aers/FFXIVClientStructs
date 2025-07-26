using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::DefaultResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct DefaultResourceHandle {
    [FieldOffset(0xB0)] public byte* Data;
    [FieldOffset(0xB8)] public ulong Length;
}
