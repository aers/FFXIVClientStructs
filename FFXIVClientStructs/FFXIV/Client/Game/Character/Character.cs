using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Game::Character::CharacterData
// ctor "E8 ?? ?? ?? ?? 48 8B 53 08 45 33 C9"
[GenerateInterop(isInherited: true)]
[Inherits<GameObject>, Inherits<CharacterData>]
[StructLayout(LayoutKind.Explicit, Size = 0x1BD0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 8D 05 ?? ?? ?? ?? 48 89 81 ?? ?? ?? ?? 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ??", 3)]
public unsafe partial struct Character {
    [FieldOffset(0x640)] public EmoteController EmoteController;
    [FieldOffset(0x680)] public MountContainer Mount;
    [FieldOffset(0x6E8)] public CompanionContainer CompanionData;
    [FieldOffset(0x708)] public DrawDataContainer DrawData;
    [FieldOffset(0x8E8)] public OrnamentContainer OrnamentData;
    [FieldOffset(0x960)] public ReaperShroudContainer ReaperShroud;

    [FieldOffset(0x9B0)] public TimelineContainer Timeline;
    [FieldOffset(0xD00)] public LookAtContainer LookAt;

    [FieldOffset(0x1900)] public VfxContainer Vfx;

    // TODO: put this in its own struct
    [FieldOffset(0x1A34)] public byte StatusFlags4;

    [FieldOffset(0x1A58)] public CharacterSetupContainer CharacterSetup;

    [FieldOffset(0x2020)] public Balloon Balloon;

    [FieldOffset(0x2228)] public float Alpha;

    [FieldOffset(0x2238)] public Companion* CompanionObject; // minion

    [FieldOffset(0x2248), FixedSizeArray(isString: true)] internal FixedSizeArray6<byte> _freeCompanyTag;

    /// <summary>
    /// The current (hard) target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the target for the local player.
    /// </remarks>
    [FieldOffset(0x2260)] public GameObjectId TargetId;

    /// <summary>
    /// The current soft target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetSoftTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the soft target for the local player.
    /// </remarks>
    [FieldOffset(0x2268)] public GameObjectId SoftTargetId;

    [FieldOffset(0x2274)] public float CastRotation;

    [FieldOffset(0x22A0)] public uint NameId;

    [FieldOffset(0x22B0)] public uint CompanionOwnerId;

    [FieldOffset(0x22C8)] public ushort CurrentWorld;
    [FieldOffset(0x22CA)] public ushort HomeWorld;

    [FieldOffset(0x22CC)] public CharacterModes Mode;
    [FieldOffset(0x22CD)] public byte ModeParam; // Different purpose depending on mode. See CharacterModes for more info.

    [FieldOffset(0x22D0)] public byte FreeCompanyCrestBitfield; // & 0x01 for offhand weapon, & 0x02 for head, & 0x04 for top, ..., & 0x20 for feet

    // Note: These 2 status flags might be just an ushort instead of 2 separate bytes.

    // 0x1 = WeaponDrawn
    // 0x2 = Unknown (Appears to always be set)
    [FieldOffset(0x22D5)] public byte StatusFlags3;
    // 0x20 = GPose wetness toggled

    public bool IsWeaponDrawn => (StatusFlags3 & 0x1) == 0x1;
    public bool IsOffhandDrawn => (CharacterData.Flags1 & 0x40) == 0x40;
    public bool InCombat => (CharacterData.Flags1 & 0x20) == 0x20;
    public bool IsHostile => (CharacterData.Flags1 & 0x10) == 0x10;
    public bool IsCasting => GetCastInfo() != null && (GetCastInfo()->IsCasting & 0x1) == 0x1;
    public bool IsPartyMember => (CharacterData.Flags2 & 0x8) == 0x8;
    public bool IsAllianceMember => (CharacterData.Flags2 & 0x10) == 0x10;
    public bool IsFriend => (CharacterData.Flags2 & 0x20) == 0x20;

    public bool IsGPoseWet {
        get => (StatusFlags4 & 0x01) == 0x01;
        set => StatusFlags4 = (byte)(value ? StatusFlags4 | 0x01 : StatusFlags4 & ~0x01);
    }

    /// <summary>
    /// Gets the (hard) target ID for this character. If this character is the LocalPlayer, this will instead read the
    /// target ID from the <see cref="TargetSystem"/>. Used for calculating ToT via /assist.
    /// </summary>
    /// <returns>Returns the object ID of this character's target.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
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

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? E8 ?? ?? ?? ?? 48 8B 4C 24 ??")]
    public partial void SetMode(CharacterModes mode, byte modeParam);

    /// <summary> Can only be used for Mounts, Minions, and Ornaments. Literally just checks if the game object at index - 1 is a character and returns that. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 48 0F 45 F8")]
    public partial Character* GetParentCharacter();

    /// <summary> Uses TransformationId, Tribe, BodyType, Sex and Height as well as RSP scaling values to calculate current height.  </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 2F C6 76 1F")]
    public partial float CalculateHeight();

    [VirtualFunction(79)]
    public partial StatusManager* GetStatusManager();

    /// <summary>
    /// Gets the <see cref="CastInfo"/> struct for this Character.
    /// May be null for certain Character subclasses, e.g. <see cref="Companion"/>.
    /// </summary>
    /// <returns>Returns a pointer to a CastInfo struct, or <c>null</c>.</returns>
    [VirtualFunction(81)]
    public partial CastInfo* GetCastInfo();

    [VirtualFunction(83)]
    public partial ActionEffectHandler* GetActionEffectHandler();

    [VirtualFunction(85)]
    public partial ForayInfo* GetForayInfo();

    [VirtualFunction(87)]
    public partial bool IsMount();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x170)]
    public partial struct CastInfo {
        [FieldOffset(0x00)] public byte IsCasting;
        [FieldOffset(0x01)] public byte Interruptible;
        [FieldOffset(0x02)] public ActionType ActionType;
        [FieldOffset(0x04)] public uint ActionId;
        [FieldOffset(0x08)] public uint SourceSequence; // for player-initiated casts - monotonically increasing id of the cast
        [FieldOffset(0x10)] public GameObjectId TargetId;
        [FieldOffset(0x20)] public Vector3 TargetLocation;
        [FieldOffset(0x30)] public float Rotation;
        [FieldOffset(0x34)] public float CurrentCastTime;
        [FieldOffset(0x38)] public float TotalCastTime;
        [FieldOffset(0x3C)] public float AdjustedTotalCastTime;

        // fields below (Response*) are set when ActionEffect is received - at this point cast can't be cancelled - this is the start of the slidecast window
        [FieldOffset(0x40)] public uint ResponseSpellId;
        [FieldOffset(0x44)] public ActionType ResponseActionType;
        [FieldOffset(0x48)] public uint ResponseActionId;
        [FieldOffset(0x4C)] public uint ResponseGlobalSequence;
        [FieldOffset(0x50)] public uint ResponseSourceSequence;
        [FieldOffset(0x58), FixedSizeArray] internal FixedSizeArray32<GameObjectId> _responseTargetIds;
        [FieldOffset(0x158)] public byte ResponseTargetCount;
        [FieldOffset(0x159)] public byte ResponseFlags; // see ActionEffectHandler.Header.Flags
    }

    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct ForayInfo {
        [FieldOffset(0x00)] public byte Level;
        [FieldOffset(0x01)] public byte Element;
    }

    // Seems similar to ConditionFlag in Dalamud but not all flags are valid on the character
    public enum CharacterModes : byte {
        None = 0, // Mode is never used
        Normal = 1, // Param always 0
        EmoteLoop = 3, // Param is an EmoteMode entry
        Mounted = 4, // Param always 0
        Crafting = 5, // Param always 0
        AnimLock = 8, // Param always 0
        Carrying = 9, // Param is a Carry entry
        RidingPillion = 10, // Param is the pillion seat number
        InPositionLoop = 11, // Param is an EmoteMode entry
        Performance = 16, // Unknown
    }
}
