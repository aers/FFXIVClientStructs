using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ApricotResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
// .avfx
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct ApricotResourceHandle {
    [FieldOffset(0xC0)] public VfxResourceObject* VfxResourceObject;
}
