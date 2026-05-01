using FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

namespace FFXIVClientStructs.FFXIV.Client.Sound;

[GenerateInterop]
[Inherits<SoundController>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct SoundDataSoundController {
    [FieldOffset(0x20)] private byte Unk20;
}
