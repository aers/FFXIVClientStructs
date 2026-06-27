using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ApricotTextureResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct ApricotTextureResourceHandle {
    [FieldOffset(0xC0)] public Texture* Texture;
}
