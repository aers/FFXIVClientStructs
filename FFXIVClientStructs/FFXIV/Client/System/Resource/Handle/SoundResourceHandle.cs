namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::SoundResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public partial struct SoundResourceHandle {
    [FieldOffset(0xCC)] public uint SoundDataRefCount; // incremented in SoundData.LoadSoundResourceHandle, decremented in SoundData.vf2
}
