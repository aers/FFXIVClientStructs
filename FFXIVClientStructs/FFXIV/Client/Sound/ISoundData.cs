using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Sound;

// Client::Sound::ISoundData
//   Common::Component::BGCollision::LinkList<Client::Sound::ISoundData,Client::Sound::ISoundData>
//   Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ISoundData {
    [FieldOffset(0x18)] public ISoundData* Next;

    [FieldOffset(0x24)] public bool IsActive;

    [VirtualFunction(3)]
    public partial SoundDataSoundController* GetSoundController();

    [VirtualFunction(5)]
    public partial void SetIsLoadingSoundResource(bool isLoading);

    [VirtualFunction(6)]
    public partial bool GetIsLoadingSoundResource();

    [VirtualFunction(7)]
    public partial uint GetFadeInDuration();

    [VirtualFunction(8)]
    public partial void SetFadeInDuration(uint fadeInDuration);

    [VirtualFunction(9)]
    public partial float GetVolume();

    [VirtualFunction(10)]
    public partial void SetVolume(float volume, uint fadeDuration = 0);

    [VirtualFunction(11)]
    public partial bool GetIsPositional();

    [VirtualFunction(12)]
    public partial void SetPosition(bool isPositional, float x, float y, float z);

    [VirtualFunction(13)]
    public partial float GetPositionX();

    [VirtualFunction(14)]
    public partial float GetPositionY();

    [VirtualFunction(15)]
    public partial float GetPositionZ();

    [VirtualFunction(16)]
    public partial float GetSpeed();

    [VirtualFunction(17)]
    public partial void SetSpeed(float speed, uint a3);

    [VirtualFunction(36)]
    public partial void Stop(uint fadeOutDuration = 1500);

    [VirtualFunction(38)]
    public partial bool IsPlaying();

    [VirtualFunction(40)]
    public partial bool GetIsFadingOut();

    [VirtualFunction(41)]
    public partial bool GetFadeInEnabled();

    [VirtualFunction(42)]
    public partial bool GetIsAutoReleaseEnabled();

    [VirtualFunction(43)]
    public partial void SetFadeInEnabled(bool enable);

    [VirtualFunction(49)]
    public partial CStringPointer GetFileName();

    [VirtualFunction(50)]
    public partial uint GetSoundNumber();

    [VirtualFunction(54)]
    public partial SoundResourceHandle* GetSoundResourceHandle();

    [VirtualFunction(55)]
    public partial void SetSoundResourceHandle(SoundResourceHandle* handle);

    [VirtualFunction(56)]
    public partial void LoadSoundResourceHandle(SoundResourceHandle* handle);

    [VirtualFunction(57)]
    public partial float GetElapsedTime(); // keeps going even through loops

    [VirtualFunction(61)]
    public partial int GetMidiNote();
}
