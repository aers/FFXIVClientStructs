using FFXIVClientStructs.FFXIV.Client.Sound;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Environment;

// Client::Graphics::Environment::EnvSoundState
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct EnvSoundState {
    [FieldOffset(0x20)] public SoundData* SoundData;
}
