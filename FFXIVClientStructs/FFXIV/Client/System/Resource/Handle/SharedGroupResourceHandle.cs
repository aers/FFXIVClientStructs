namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::SharedGroupResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct SharedGroupResourceHandle {
    [FieldOffset(0xB0), Obsolete("Use Data instead")] public byte* SceneChunk;
}
