namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::LifeSkillContainer
//   Client::Game::Character::ContainerInterface
// plays various vfx for crafters and gatherers, and prints log messages
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct LifeSkillContainer {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray3<uint> _queuedActionTimelineIds;

    /// <remarks>
    /// Set by UpdateVfx, cleared when you stop crafting/gathering
    /// The attach point comes from GetVfxWeaponIndex, except <see cref="LifeSkillVfx.MateriaMeld"/> which attaches to the body.
    /// </remarks>
    [FieldOffset(0x1C)] public LifeSkillVfx ToolVfx;
    [FieldOffset(0x1D)] private byte VfxType2; // I don't think anything uses this
    [FieldOffset(0x1E)] private byte VfxType3; // various DoH/DoL vfxs
    [FieldOffset(0x1F)] private byte Unk1F; // set by gathering collectable actions
    [BitField<bool>("IsOffhandDrawn", 0)]
    [FieldOffset(0x20)] public byte WeaponFlags; // there is really only one bit used here

    public enum LifeSkillVfx : byte {
        None = 0,
        UnkCraft00 = 2,
        UnkCraft01 = 3,
        UnkCraft02 = 4,
        UnkCraft03 = 5,
        UnkCraft06 = 6,
        UnkCraft05 = 7,
        UnkCraft04 = 8,
        UnkCraft07 = 9,
        UnkCraft08 = 10,
        UnkCraft09 = 11,
        UnkCraft10 = 12,
        CraftEndFail = 13,
        CraftEndNq = 14,
        CraftEndHq = 15,
        FishingRodLight = 16,
        UnkFish17 = 17,
        MateriaMeld = 18,
    }
}
