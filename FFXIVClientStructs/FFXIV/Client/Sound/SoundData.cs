using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Sound;

// Client::Sound::SoundData
//   Client::Sound::ISoundData
//     Common::Component::BGCollision::LinkList<Client::Sound::ISoundData,Client::Sound::ISoundData>
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ISoundData>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct SoundData {
    [FieldOffset(0x28)] public SoundResourceHandle* SoundResourceHandle;
    [FieldOffset(0x30)] public int FadeInDuration;
    [FieldOffset(0x38)] public SoundDataSoundController SoundController;
    [FieldOffset(0x60)] public float Volume;
    [FieldOffset(0x64)] private float Unk64;
    [FieldOffset(0x68)] public float PosX;
    [FieldOffset(0x6C)] public float PosY;
    [FieldOffset(0x70)] public float PosZ;
    [FieldOffset(0x74)] public float Speed;
    [FieldOffset(0x78)] private uint Unk78; // LocalPlayer = 10, Party = 1, else 0?
    [FieldOffset(0x7C)] public uint SoundNumber;
    [FieldOffset(0x80)] private float Unk80;
    [FieldOffset(0x84)] private float Unk84;
    [FieldOffset(0x88)] public float FadeOutDuration;
    [FieldOffset(0x8C)] public int MidiNote; // default: -1
    [FieldOffset(0x90)] private nint Unk90;
    [FieldOffset(0x98)] private int Unk98;
    [FieldOffset(0x9C)] private int DriverResourceIndex; // not sure, but SoundResourceHandle is passed to SoundDriver and it returns this. default: -1
    [FieldOffset(0xA0)] public SoundLayoutOptions* SoundLayoutOptions;

    [FieldOffset(0xB0)] private uint UnkB0;
    [FieldOffset(0xB4)] public SoundVolumeCategory VolumeCategory;
    [FieldOffset(0xB8)] public bool IsLoadingSoundResource;
    [FieldOffset(0xB9)] public bool IsPositional;
    [FieldOffset(0xBA)] public bool IsFadeInEnabled;
    [FieldOffset(0xBB)] public bool IsAutoReleaseEnabled;
    [FieldOffset(0xBC)] private bool UnkBC; // IsFadingOut/IsEnding?
    [FieldOffset(0xBD)] public bool IsFadeOutEnabled;
    [FieldOffset(0xBE)] private bool UnkBE;
    [FieldOffset(0xBF)] private bool UnkBF;
    [FieldOffset(0xC0)] private bool UnkC0;
    [FieldOffset(0xC1)] private bool UnkC1;
    [FieldOffset(0xC2)] private bool UnkC2;
    [FieldOffset(0xC3)] public bool IsLocalPlayer; // the result of VolumeCategory == SoundVolumeCategory.Player
    [FieldOffset(0xC4)] private bool UnkC4;
    [FieldOffset(0xC5)] public bool IsDefaultFadeOut; // sets FadeOutDuration to 10.0

    [FieldOffset(0xC8)] private nint UnkC8;
}
