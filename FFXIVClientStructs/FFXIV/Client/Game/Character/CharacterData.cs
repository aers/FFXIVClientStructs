using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CharacterData
// ctor "0F 57 C0 33 C0 0F 11 01 48 89 41 ?? 66 89 41"
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct CharacterData {
    [FieldOffset(0x8)] public float ModelScale;
    [FieldOffset(0xC)] public uint Health;
    [FieldOffset(0x10)] public uint MaxHealth;
    [FieldOffset(0x14)] public uint Mana;
    [FieldOffset(0x18)] public uint MaxMana;
    [FieldOffset(0x1C)] public ushort GatheringPoints;
    [FieldOffset(0x1E)] public ushort MaxGatheringPoints;
    [FieldOffset(0x20)] public ushort CraftingPoints;
    [FieldOffset(0x22)] public ushort MaxCraftingPoints;
    [FieldOffset(0x24)] public short TransformationId;
    [FieldOffset(0x26)] public ushort TitleId;
    [FieldOffset(0x28)] public ushort StatusLoopVfxId;
    [FieldOffset(0x2A)] public byte ClassJob;
    [FieldOffset(0x2B)] public byte Level;
    [FieldOffset(0x2C)] public byte Icon; // for nameplates
    [FieldOffset(0x2D)] public byte SEPack;
    [FieldOffset(0x2E)] public byte ShieldValue;
    [FieldOffset(0x2F)] public byte Map; // ENpcResident.Map
    [FieldOffset(0x30)] public byte OnlineStatus;
    [FieldOffset(0x31)] public byte Battalion; // used for determining friend/enemy state

    // 0x01 = IsHostile
    // 0x02 = InCombat
    [FieldOffset(0x34)] public byte Flags;

    /// <summary>
    /// The type of tagger, as represented in <see cref="CombatTaggerId"/>. Known values:
    /// <list type="bullet">
    /// <item>0 - Entity Not Tagged</item>
    /// <item>1 - Character Tag (players, battle NPCs, etc.)</item>
    /// <item>2 - Party Tag (PVP?)</item>
    /// <item>4 - Observed, but unknown.</item>
    /// </list>
    /// </summary>
    [FieldOffset(0x35)] public byte CombatTagType;

    /// <summary>
    /// The GameObjectID of the entity that currently has the combat tag on this character. May be set to a party ID if
    /// certain conditions are met (PVP?). See <see cref="CombatTagType"/> for information about the type of tagger.
    /// </summary>
    /// <remarks>
    /// A tagger is generally the first entity to deal damage to this character, and will persist until that entity
    /// has died, at which point it will reset.
    /// </remarks>
    [FieldOffset(0x38)] public GameObjectId CombatTaggerId;

    [VirtualFunction(0)]
    public partial CharacterData* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void ClassJobChanged(byte from, byte to);
}
