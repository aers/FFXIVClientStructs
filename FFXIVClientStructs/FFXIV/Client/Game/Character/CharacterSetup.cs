namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CharacterSetup
// ctor "80 61 10 FC 48 8D 05"
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct CharacterSetup {
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 9F ?? ?? ?? ?? 48 8D 8F")]
    public partial ulong CopyFromCharacter(Character* source, CopyFlags flags);

    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B6 86 ?? ?? ?? ?? 48 8D 8F")]
    public partial void SetupBNpc(uint bNpcBaseId, uint bNpcNameId = 0);

    [Flags]
    public enum CopyFlags : uint {
        None = 0x00,
        Mode = 0x1, // emote loop etc
        Mount = 0x2,
        ClassJob = 0x4,
        Companion = 0x20,
        WeaponHiding = 0x80,
        Target = 0x400,
        Name = 0x1000,
        LastAnimation = 0x8000,
        Position = 0x10000, // includes rotation
        UseSecondaryCharaId = 0x200000,
        Ornament = 0x400000,

        // Unknowns included to improve readability of ToString, not to be used.
        [Obsolete("Use Mode", true)] Unk000001 = 0x1,
        [Obsolete("do not use", true)] Unk000008 = 0x8, // Copies Character+0x1B24
        [Obsolete("do not use", true)] Unk000010 = 0x10,
        [Obsolete("do not use", true)] Unk000040 = 0x40,
        [Obsolete("do not use", true)] Unk000100 = 0x100,
        [Obsolete("do not use", true)] Unk000200 = 0x200,
        [Obsolete("do not use", true)] Unk000800 = 0x800,
        [Obsolete("do not use", true)] Unk002000 = 0x2000,
        [Obsolete("do not use", true)] Unk004000 = 0x4000,
        [Obsolete("Use LastAnimation", true)] Unk008000 = 0x8000, // Copies Character+0xBFC
        [Obsolete("do not use", true)] Unk020000 = 0x20000,
        [Obsolete("do not use", true)] Unk040000 = 0x40000,
        [Obsolete("do not use", true)] Unk080000 = 0x80000,
        [Obsolete("do not use", true)] Unk100000 = 0x100000,
    }
}
