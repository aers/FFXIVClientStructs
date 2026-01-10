namespace FFXIVClientStructs.FFXIV.Client.Sound;

// Client::Sound::ISoundData
//   Common::Component::BGCollision::LinkList<Client::Sound::ISoundData,Client::Sound::ISoundData>
//   Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ISoundData {
    [FieldOffset(0x18)] public ISoundData* Next;

    [FieldOffset(0x24)] public bool IsActive;
}
