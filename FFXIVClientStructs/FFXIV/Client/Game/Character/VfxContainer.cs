using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::VfxContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct VfxContainer {
    [FieldOffset(0x18)] public VfxData* VfxData;
    [FieldOffset(0x20)] public VfxData* VfxData2;
    [FieldOffset(0x48)] public VfxData* Omen;

    [FieldOffset(0xD0)] public ushort VoiceId;

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 06 3C")]
    public partial nint LoadCharacterSound(int unk1, int unk2, nint unk3, ulong unk4, int unk5, int unk6, ulong unk7);
}
