using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Sound;

// Client::Sound::SoundData
//   Client::Sound::ISoundData
//     Common::Component::BGCollision::LinkList<Client::Sound::ISoundData,Client::Sound::ISoundData>
//     Client::System::Common::NonCopyable
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct SoundData {
    [FieldOffset(0x28)] public SoundResourceHandle* SoundResourceHandle;
}
