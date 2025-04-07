using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Game::Character::CharacterData
[GenerateInterop(isInherited: true)]
[Inherits<GameObject>, Inherits<CharacterData>]
[StructLayout(LayoutKind.Explicit, Size = 0x22E0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 07 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 87 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 33 ED 48 8D 05 ?? ?? ?? ??", 3)]
public unsafe partial struct Character {
    [FieldOffset(0x610)] public EmoteController EmoteController;
    [FieldOffset(0x650)] public MountContainer Mount;
    [FieldOffset(0x6B8)] public CompanionContainer CompanionData;
    [FieldOffset(0x6D8)] public DrawDataContainer DrawData;
    [FieldOffset(0x8D0)] public OrnamentContainer OrnamentData;
    [FieldOffset(0x948)] public ReaperShroudContainer ReaperShroud;
    [FieldOffset(0x9A0)] public TimelineContainer Timeline;
    [FieldOffset(0xCF0)] public LookAtContainer LookAt;

    // 0x01 = OffhandDrawn
    [FieldOffset(0x18F0)] public byte WeaponFlags;
    [FieldOffset(0x18F8)] public VfxContainer Vfx;

    [FieldOffset(0x1A00)] public EffectContainer Effects;
    [FieldOffset(0x1A80)] public CharacterSetupContainer CharacterSetup;

    // 0x1AA8: start of some substructure
    [FieldOffset(0x1A98)] public ModelContainer ModelContainer;

    // 0x01 = PartyMember
    // 0x02 = AllianceMember
    // 0x04 = Friend
    [FieldOffset(0x1C52)] public byte RelationFlags;

    // 0x40 = All attacks will be cancelled, character is doing the the 'winded' emote, used in e.g. 'Strange Bedfellows' and 'Combat Evolved' when quest expects an item to be used on the character
    [FieldOffset(0x1C58)] public byte ActorControlFlags;

    [FieldOffset(0x2150)] public Balloon Balloon;

    [FieldOffset(0x2258)] public float Alpha;

    [FieldOffset(0x2268)] public Companion* CompanionObject; // minion
    [FieldOffset(0x2270), FixedSizeArray(isString: true)] internal FixedSizeArray7<byte> _freeCompanyTag;

    /// <summary>
    /// The current (hard) target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the target for the local player.
    /// </remarks>
    [FieldOffset(0x2278)] public GameObjectId TargetId;

    /// <summary>
    /// The current soft target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetSoftTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the soft target for the local player.
    /// </remarks>
    [FieldOffset(0x2280)] public GameObjectId SoftTargetId;

    [FieldOffset(0x228C)] public float CastRotation;

    [FieldOffset(0x22A4)] public uint NameId;

    [FieldOffset(0x22B0)] public uint CompanionOwnerId;

    [FieldOffset(0x22B8)] public ulong AccountId;
    [FieldOffset(0x22C0)] public ulong ContentId;
    [FieldOffset(0x22C8)] public ushort CurrentWorld;
    [FieldOffset(0x22CA)] public ushort HomeWorld;
    [FieldOffset(0x22CC)] public CharacterModes Mode;
    [FieldOffset(0x22CD)] public byte ModeParam; // Different purpose depending on mode. See CharacterModes for more info.
    [FieldOffset(0x22CE)] public byte GMRank;

    public bool IsWeaponDrawn => (Timeline.Flags3 & 0x40) != 0;
    public bool IsOffhandDrawn => (WeaponFlags & 0x1) != 0;
    public bool InCombat => (CharacterData.Flags & 0x2) != 0;
    public bool IsHostile => (CharacterData.Flags & 0x1) != 0;
    public bool IsCasting => GetCastInfo() != null && (GetCastInfo()->IsCasting & 0x1) == 0x1;
    public bool IsPartyMember => (RelationFlags & 0x1) != 0;
    public bool IsAllianceMember => (RelationFlags & 0x2) != 0;
    public bool IsFriend => (RelationFlags & 0x4) != 0;

    /// <summary>
    /// Gets the (hard) target ID for this character. If this character is the LocalPlayer, this will instead read the
    /// target ID from the <see cref="TargetSystem"/>. Used for calculating ToT via /assist.
    /// </summary>
    /// <returns>Returns the object ID of this character's target.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C5 74 27")]
    public partial GameObjectId GetTargetId();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B FD 74 36")]
    public partial void SetTargetId(GameObjectId id);

    /// <summary>
    /// Gets the soft target ID for this character. If this character is the LocalPlayer, this will instead read the
    /// soft target ID from the <see cref="TargetSystem"/>.
    /// </summary>
    /// <returns>Returns the object ID of this character's target.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 EB 12")]
    public partial GameObjectId GetSoftTargetId();

    [MemberFunction("E8 ?? ?? ?? ?? EB 05 4C 3B E0")]
    public partial void SetSoftTargetId(GameObjectId id);

    public bool IsMounted() => Mount.MountId != 0;

    [MemberFunction("E8 ?? ?? ?? ?? 45 84 FF 75 40")]
    public partial void SetMode(CharacterModes mode, byte modeParam);

    /// <summary> Can only be used for Mounts, Minions, and Ornaments. Literally just checks if the game object at index - 1 is a character and returns that. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 11 4D 8B 07")]
    public partial Character* GetParentCharacter();

    /// <summary>Check if this character is in a jumping/falling animation.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 46 48 8B 4B 08")]
    public partial bool IsJumping();

    /// <summary> Check if the character is using the World Visit system. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 8B CF")]
    public partial bool IsWanderer();

    /// <summary> Check if the character is using the Data Center Travel system. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 8B FD")]
    public partial bool IsTraveler();

    /// <summary> Check if the character is using the Cross-region Data Center Travel system. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 3A 48 8B 4B 08")]
    public partial bool IsVoyager();

    [VirtualFunction(77)]
    public partial StatusManager* GetStatusManager();

    /// <summary>
    /// Gets the <see cref="CastInfo"/> struct for this Character.
    /// May be null for certain Character subclasses, e.g. <see cref="Companion"/>.
    /// </summary>
    /// <returns>Returns a pointer to a CastInfo struct, or <c>null</c>.</returns>
    [VirtualFunction(79)]
    public partial CastInfo* GetCastInfo();

    [VirtualFunction(81)]
    public partial ActionEffectHandler* GetActionEffectHandler();

    [VirtualFunction(83)]
    public partial ForayInfo* GetForayInfo();
}

// LogMessages for errors starting at 7700
public enum CharacterModes : byte {
    None = 0, // Mode is never used
    Normal = 1, // Param always 0
    Dead = 2,
    EmoteLoop = 3, // Param is an EmoteMode entry
    Mounted = 4, // Param always 0
    Crafting = 5, // Param always 0
    Gathering = 6,
    MateriaAttach = 7,
    AnimLock = 8, // Param always 0
    Carrying = 9, // Param is a Carry entry
    RidingPillion = 10, // Param is the pillion seat number
    InPositionLoop = 11, // Param is an EmoteMode entry
    RaceChocobo = 12,
    TripleTriad = 13,
    Lovm = 14, // Lord of Verminion
    // CustomMatch = 15, // PvP, untested
    Performance = 16, // Param is Perform row id (the instrument)
}

[StructLayout(LayoutKind.Explicit, Size = 2)]
public struct ForayInfo {
    [FieldOffset(0x00)] public byte Level;
    [FieldOffset(0x01)] public byte Element;
}
