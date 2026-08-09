namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::LifeSkillContainer
//   Client::Game::Character::ContainerInterface
// plays various vfx for crafters and gatherers, and prints log messages
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct LifeSkillContainer {
    [FieldOffset(0x10)] private int UnkActionTimelineId1;
    [FieldOffset(0x14)] private int UnkActionTimelineId2;
    [FieldOffset(0x18)] private int UnkActionTimelineId3;
    [FieldOffset(0x1C)] private byte VfxType1;
    [FieldOffset(0x1D)] private byte VfxType2;
    [FieldOffset(0x1E)] private byte VfxType3;
    [FieldOffset(0x1F)] private byte Unk1F;
    [BitField<bool>("IsOffhandDrawn", 0)]
    [FieldOffset(0x20)] public byte WeaponFlags; // there is really only one bit used here
}
