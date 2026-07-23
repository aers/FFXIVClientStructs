namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::LiveVfxContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct LiveVfxContainer {
    [FieldOffset(0x10)] private int UnkActionTimelineId1;
    [FieldOffset(0x14)] private int UnkActionTimelineId2;
    [FieldOffset(0x18)] private int Unk18;
    [FieldOffset(0x1C)] private byte VfxType1;
    [FieldOffset(0x1D)] private byte VfxType2;
    [FieldOffset(0x1E)] private byte Unk1E;
    [FieldOffset(0x1F)] private byte Unk1F;
    [FieldOffset(0x20)] public LiveWeaponFlag WeaponFlags;

    /// <summary>
    /// Plays a life skill (crafting/gathering) vfx.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? C6 41")]
    public partial void PlayVfx(byte type);
}

[Flags]
public enum LiveWeaponFlag : byte {
    IsOffhandDrawn = 1 << 0, // offhand crafting/gathering tool
}
