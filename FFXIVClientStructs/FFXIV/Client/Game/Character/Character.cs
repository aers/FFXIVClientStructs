using FFXIVClientStructs.FFXIV.Client.Game.Character.Data;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;
// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Graphics::Vfx::VfxDataListenner

// size = 0x1B40
// ctor E8 ?? ?? ?? ?? 48 8B C8 48 8B 43 08 45 33 C9
[StructLayout(LayoutKind.Explicit, Size = 0x1B40)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 8b d9 48 89 01 48 8d 05 ?? ?? ?? ?? 48 89 81 a0 01 00 00 48 8d 05 ?? ?? ?? ??", 3)]
public unsafe partial struct Character
{
    [FieldOffset(0x0)] public GameObject GameObject;

    [FieldOffset(0x1A8)] public CharacterData CharacterData;
    
    #region This is inside a new 0x48 byte class at offset 0x1A8
    
    [FieldOffset(0x1B0), Obsolete("Use CharacterData.ModelScale", false)] public float ModelScale;
    [FieldOffset(0x1B4), Obsolete("Use CharacterData.ModelCharaId", false)] public int ModelCharaId;
    [FieldOffset(0x1B8), Obsolete("Use CharacterData.ModelSkeletonId", false)] public int ModelSkeletonId;
    [FieldOffset(0x1BC), Obsolete("Use CharacterData.ModelCharaId_2", false)] public int ModelCharaId_2; // == -1 -> return ModelCharaId
    [FieldOffset(0x1C0), Obsolete("Use CharacterData.ModelSkeletonId_2", false)] public int ModelSkeletonId_2; // == 0 -> return ModelSkeletonId

    [FieldOffset(0x1C4), Obsolete("Use CharacterData.Health", false)] public uint Health;
    [FieldOffset(0x1C8), Obsolete("Use CharacterData.MaxHealth", false)] public uint MaxHealth;
    [FieldOffset(0x1CC), Obsolete("Use CharacterData.Mana", false)] public uint Mana;
    [FieldOffset(0x1D0), Obsolete("Use CharacterData.MaxMana", false)] public uint MaxMana;
    [FieldOffset(0x1D4), Obsolete("Use CharacterData.GatheringPoints", false)] public ushort GatheringPoints;
    [FieldOffset(0x1D6), Obsolete("Use CharacterData.MaxGatheringPoints", false)] public ushort MaxGatheringPoints;
    [FieldOffset(0x1D8), Obsolete("Use CharacterData.CraftingPoints", false)] public ushort CraftingPoints;
    [FieldOffset(0x1DA), Obsolete("Use CharacterData.MaxCraftingPoints", false)] public ushort MaxCraftingPoints;
    [FieldOffset(0x1DC), Obsolete("Use CharacterData.TransformationId", false)] public short TransformationId;
    [FieldOffset(0x1DE), Obsolete("Use CharacterData.StatusEffectVFXId", false)] public short StatusEffectVFXId; // outdated since TitleID moved here
    [FieldOffset(0x1DE), Obsolete("Use CharacterData.TitleID", false)] public ushort TitleID;

    [FieldOffset(0x1E2), Obsolete("Use CharacterData.ClassJob", false)] public byte ClassJob;
    [FieldOffset(0x1E3), Obsolete("Use CharacterData.Level", false)] public byte Level;

    [FieldOffset(0x1ED), Obsolete("Use CharacterData.ShieldValue", false)] public byte ShieldValue;

    [FieldOffset(0x1EF), Obsolete("Use CharacterData.OnlineStatus", false)] public byte OnlineStatus;

    #endregion

    [FieldOffset(0x641)] public byte CPoseState;
    [FieldOffset(0x660)] public MountContainer Mount;
    [FieldOffset(0x6C8)] public CompanionContainer Companion;
    [FieldOffset(0x6E8)] public DrawDataContainer DrawData;

    [Obsolete($"Use {nameof(DrawData)}"), FieldOffset(0x830)] public fixed byte EquipSlotData[4 * 10];
    [Obsolete($"Use {nameof(DrawData)}.CustomizeData"), FieldOffset(0x858)] public fixed byte CustomizeData[0x1A];

    [FieldOffset(0x878)] public OrnamentContainer Ornament;
    [FieldOffset(0x920)] public ActionTimelineManager ActionTimelineManager;

    [FieldOffset(0xCB0)] public uint PlayerTargetObjectID;

    [FieldOffset(0x17C0)] public Balloon Balloon;

    [FieldOffset(0x19C8)] public VfxData* VfxData; 
    [FieldOffset(0x19D0)] public VfxData* VfxData2;
    [FieldOffset(0x19F8)] public VfxData* Omen;

    [FieldOffset(0x1A4C)] public float Alpha;
    [FieldOffset(0x1A80)] public Companion* CompanionObject; // minion
    [FieldOffset(0x1A98)] public fixed byte FreeCompanyTag[6];
    [FieldOffset(0x1AB8)] public ulong TargetObjectID;

    [FieldOffset(0x1B00)] public uint NameID;

    [FieldOffset(0x1B1C)] public ushort CurrentWorld;
    [FieldOffset(0x1B1E)] public ushort HomeWorld;

    [FieldOffset(0x1B24)] public ushort VoiceId;
    [FieldOffset(0x1B26)] public byte EventState; // Leave for backwards compat. See Mode.
    [FieldOffset(0x1B26)] public CharacterModes Mode;
    [FieldOffset(0x1B27)] public byte ModeParam; // Different purpose depending on mode. See CharacterModes for more info.
    [FieldOffset(0x1B29)] public byte Battalion; // used for determining friend/enemy state
    [FieldOffset(0x1B10)] public uint CompanionOwnerID;

    // Note: These 2 status flags might be just an ushort instead of 2 separate bytes.

    // 0x1, 0x2, 0x4, 0x8 = Unknown
    // 0x10 = IsHostile
    // 0x20 = InCombat 
    // 0x40 = OffHandDrawn
    [FieldOffset(0x1F2)] public byte StatusFlags;

    // 0x1 = Unknown
    // 0x2 = Unknown (always on for some reason?)
    // 0x4 = Unknown
    // 0x8 = PartyMember
    // 0x10 = AllianceMember
    // 0x20 = Friend
    [FieldOffset(0x1F3)] public byte StatusFlags2;
    // 0x1 = WeaponDrawn
    // 0x2 = Unknown (Appears to always be set)
    [FieldOffset(0x1B38)] public byte StatusFlags3;
    // 0x20 = GPose wetness toggled
    [FieldOffset(0x1B3A)] public byte StatusFlags4;

    public bool IsWeaponDrawn => (StatusFlags3 & 0x1) == 0x1;
    public bool IsOffhandDrawn => (StatusFlags & 0x40) == 0x40;
    public bool InCombat => (StatusFlags & 0x20) == 0x20;
    public bool IsHostile => (StatusFlags & 0x10) == 0x10;
    public bool IsCasting => GetCastInfo() != null && (GetCastInfo()->IsCasting & 0x1) == 0x1;
    public bool IsPartyMember => (StatusFlags2 & 0x8) == 0x8;
    public bool IsAllianceMember => (StatusFlags2 & 0x10) == 0x10;
    public bool IsFriend => (StatusFlags2 & 0x20) == 0x20;

    public bool IsGPoseWet
    {
        get => (StatusFlags4 & 0x20) == 0x20;
        set => StatusFlags4 = (byte) (value ? StatusFlags4 | 0x20 : StatusFlags4 & ~0x20);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
    public partial ulong GetTargetId();

    // Seemingly used for cutscenes and GPose.
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 9F ?? ?? ?? ?? 48 8D 8F")]
    public partial ulong CopyFromCharacter(Character* source, CopyFlags flags);
    
    [Obsolete("Use CopyFromCharacter(Character*, CopyFlags)")]
    public ulong CopyFromCharacter(Character* source, uint flags) => CopyFromCharacter(source, (CopyFlags)flags);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 7F 48")]
    public partial bool IsMounted();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? E8 ?? ?? ?? ?? 48 8B 4C 24 ??")]
    public partial void SetMode(CharacterModes mode, byte modeParam);

    [VirtualFunction(79)]
    public partial StatusManager* GetStatusManager();

    /// <summary>
    /// Gets the <see cref="CastInfo"/> struct for this Character.
    /// May be null for certain Character subclasses, e.g. <see cref="Companion"/>.
    /// </summary>
    /// <returns>Returns a pointer to a CastInfo struct, or <c>null</c>.</returns>
    [VirtualFunction(81)]
    public partial CastInfo* GetCastInfo();

    [VirtualFunction(85)]
    public partial ForayInfo* GetForayInfo();

    [VirtualFunction(87)]
    public partial bool IsMount();
    
    [StructLayout(LayoutKind.Explicit, Size = 0x170)]
    public struct CastInfo
    {
        [FieldOffset(0x00)] public byte IsCasting;
        [FieldOffset(0x01)] public byte Interruptible;
        [FieldOffset(0x02)] public ActionType ActionType;
        [FieldOffset(0x04)] public uint ActionID;
        [FieldOffset(0x08)] public uint Unk_08;
        [FieldOffset(0x10)] public uint CastTargetID;
        [FieldOffset(0x20)] public Vector3 CastLocation;
        [FieldOffset(0x30)] public uint Unk_30;
        [FieldOffset(0x34)] public float CurrentCastTime;
        [FieldOffset(0x38)] public float TotalCastTime;
        [FieldOffset(0x3C)] public float AdjustedTotalCastTime;

        [FieldOffset(0x40)] public uint UsedActionId;

        [FieldOffset(0x44)] public ActionType UsedActionType;
        //[FieldOffset(0x4C)] public uint TotalActionCounter?;
        //[FieldOffset(0x50)] public uint OwnActionCounter?;

        [FieldOffset(0x58)] public fixed long ActionRecipientsObjectIdArray[32];
        [FieldOffset(0x158)] public int ActionRecipientsCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct ForayInfo
    {
        [FieldOffset(0x00)] public byte ForayRank;
        
        //bozja
        public byte ResistanceRank {
            get => ForayRank;
            set => ForayRank = value;
        }

        //eureka
        public byte ElementalLevel  {
            get => ForayRank;
            set => ForayRank = value;
        }
        [FieldOffset(0x01)] public EurekaElement Element; //only on enemies
    }
    
    //0x10 bytes are from the base class which is just vtable + gameobject ptr (same as Companion-/DrawDataContainer)
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public struct MountContainer {
	    [FieldOffset(0x08)] public BattleChara* OwnerObject;
	    [FieldOffset(0x10)] public Character* MountObject;
	    [FieldOffset(0x18)] public ushort MountId;
	    [FieldOffset(0x1C)] public float DismountTimer;
	    //1 in dismount animation, 4 = instant delete mount when dismounting (used for npcs and such)
	    [FieldOffset(0x20)] public byte Flags;
	    [FieldOffset(0x24)] public fixed uint MountedObjectIds[7];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CompanionContainer {
	    [FieldOffset(0x08)] public BattleChara* OwnerObject;
	    [FieldOffset(0x10)] public Companion* CompanionObject;
	    //used if minion is summoned but the object slot is taken by a mount
	    [FieldOffset(0x18)] public ushort CompanionId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct OrnamentContainer {
	    [FieldOffset(0x08)] public BattleChara* OwnerObject;
	    [FieldOffset(0x10)] public Ornament* OrnamentObject;
	    [FieldOffset(0x18)] public ushort OrnamentId;
    }

    public enum EurekaElement : byte
    {
        None = 0,
        Fire = 1,
        Ice = 2,
        Wind = 3,
        Earth = 4,
        Lightning = 5,
        Water = 6
    }

    // Seems similar to ConditionFlag in Dalamud but not all flags are valid on the character
    public enum CharacterModes : byte 
    {
        None = 0, // Mode is never used
        Normal = 1, // Param always 0
        EmoteLoop = 3, // Param is an EmoteMode entry
        Mounted = 4, // Param always 0
        AnimLock = 8, // Param always 0
        Carrying = 9, // Param is a Carry entry
        InPositionLoop = 11, // Param is an EmoteMode entry
        Performance = 16, // Unknown
    }
    
    [Flags]
    public enum CopyFlags : uint {
        None = 0x00,
        
        Mount = 0x2,
        ClassJob = 0x4,
        Companion = 0x20,
        WeaponHiding = 0x80,
        Target = 0x400,
        Name = 0x1000,
        Position = 0x10000, // includes rotation
        UseSecondaryCharaId = 0x200000,
        Ornament = 0x400000,
        
        // Unknowns included to improve readability of ToString, not to be used.
        [Obsolete("do not use")] Unk000001 = 0x1,
        [Obsolete("do not use")] Unk000008 = 0x8, // Copies Character+0x1B24
        [Obsolete("do not use")] Unk000010 = 0x10,
        [Obsolete("do not use")] Unk000040 = 0x40,
        [Obsolete("do not use")] Unk000100 = 0x100,
        [Obsolete("do not use")] Unk000200 = 0x200,
        [Obsolete("do not use")] Unk000800 = 0x800,
        [Obsolete("do not use")] Unk002000 = 0x2000,
        [Obsolete("do not use")] Unk004000 = 0x4000,
        [Obsolete("do not use")] Unk008000 = 0x8000, // Copies Character+0xBFC
        [Obsolete("do not use")] Unk020000 = 0x20000,
        [Obsolete("do not use")] Unk040000 = 0x40000,
        [Obsolete("do not use")] Unk080000 = 0x80000,
        [Obsolete("do not use")] Unk100000 = 0x100000,
    }
    
}
