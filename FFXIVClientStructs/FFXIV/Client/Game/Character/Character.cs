using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Graphics::Vfx::VfxDataListenner
//   Client::Game::Character::CharacterData
// ctor "E8 ?? ?? ?? ?? 48 8B C8 48 8B 43 08 45 33 C9"
[StructLayout(LayoutKind.Explicit, Size = 0x1BD0)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 8D 05 ?? ?? ?? ?? 48 89 81 ?? ?? ?? ?? 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 35", 3)]
public unsafe partial struct Character {
    [FieldOffset(0x0)] public GameObject GameObject;
    [FieldOffset(0x1A0)] public CharacterData CharacterData;

    [Obsolete("Use MovementBytes so that the name can be used for a struct in the future.")]
    [FieldOffset(0x210)] public fixed byte Movement[0x420];
    [FieldOffset(0x210)] public fixed byte MovementBytes[0x420];
    [FieldOffset(0x630)] public EmoteController EmoteController;
    [FieldOffset(0x670)] public MountContainer Mount;
    [FieldOffset(0x6D8)] public CompanionContainer Companion;
    [FieldOffset(0x6F8)] public DrawDataContainer DrawData;
    [FieldOffset(0x8A0)] public OrnamentContainer Ornament;
    [FieldOffset(0x918)] public ReaperShroudContainer ReaperShroud;

    [FieldOffset(0x970)] public ActionTimelineManager ActionTimelineManager;
    [FieldOffset(0xCB0)] public GazeContainer Gaze;

    /// <inheritdoc cref="GazeController.Gaze.TargetInformation.TargetId"/>
    [Obsolete("Use Character.Gaze.Controller.GazesSpan[0].TargetInfo.TargetId")]
    [FieldOffset(0xCB0 + 0x50)] public GameObjectID LookTargetId;

    [FieldOffset(0x12F0)] public VfxContainer Vfx;

    [FieldOffset(0x13E0 + 0x30)] public byte StatusFlags4;

    [FieldOffset(0x1418)] public CharacterSetup CharacterSetup;

    [FieldOffset(0x1920)] public Balloon Balloon;

    [FieldOffset(0x1B28)] public float Alpha;

    [FieldOffset(0x1B30)] public Companion* CompanionObject; // minion

    [FieldOffset(0x1B40)] public fixed byte FreeCompanyTag[6];

    /// <summary>
    /// The current (hard) target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the target for the local player.
    /// </remarks>
    [FieldOffset(0x1B58)] public GameObjectID TargetId;

    /// <summary>
    /// The current soft target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetSoftTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the soft target for the local player.
    /// </remarks>
    [FieldOffset(0x1B60)] public GameObjectID SoftTargetId;

    [FieldOffset(0x1B98)] public uint NameID;

    [FieldOffset(0x1BA8)] public uint CompanionOwnerID;

    [FieldOffset(0x1BB0)] public ushort CurrentWorld;
    [FieldOffset(0x1BB2)] public ushort HomeWorld;

    [FieldOffset(0x1BB6), Obsolete("Use Mode")] public byte EventState; // Leave for backwards compat. See Mode.
    [FieldOffset(0x1BB6)] public CharacterModes Mode;
    [FieldOffset(0x1BB7)] public byte ModeParam; // Different purpose depending on mode. See CharacterModes for more info.

    [FieldOffset(0x1BBB)] public byte FreeCompanyCrestBitfield; // & 0x01 for offhand weapon, & 0x02 for head, & 0x04 for top, ..., & 0x20 for feet

    // Note: These 2 status flags might be just an ushort instead of 2 separate bytes.

    // 0x1 = WeaponDrawn
    // 0x2 = Unknown (Appears to always be set)
    [FieldOffset(0x1BC1)] public byte StatusFlags3;
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
    // TODO: Update this return type to GameObjectID with next API bump.
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
    public partial ulong GetTargetId();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B FD 74 36")]
    public partial void SetTargetId(GameObjectID id);

    /// <summary>
    /// Gets the soft target ID for this character. If this character is the LocalPlayer, this will instead read the
    /// soft target ID from the <see cref="TargetSystem"/>.
    /// </summary>
    /// <returns>Returns the object ID of this character's target.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C5")]
    public partial GameObjectID GetSoftTargetId();

    [MemberFunction("E8 ?? ?? ?? ?? B8 ?? ?? ?? ?? 4C 3B F0")]
    public partial void SetSoftTargetId(GameObjectID id);

    public bool IsMounted() => Mount.MountId != 0;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? E8 ?? ?? ?? ?? 48 8B 4C 24 ??")]
    public partial void SetMode(CharacterModes mode, byte modeParam);

    /// <summary> Can only be used for Mounts, Minions, and Ornaments. Literally just checks if the game object at index - 1 is a character and returns that. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 48 0F 45 F8")]
    public partial Character* GetParentCharacter();

    /// <summary> Uses TransformationId, Tribe, BodyType, Sex and Height as well as RSP scaling values to calculate current height.  </summary>
    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 59 C7 48 8B CE")]
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

    [VirtualFunction(85)]
    public partial ForayInfo* GetForayInfo();

    [VirtualFunction(87)]
    public partial bool IsMount();

    [StructLayout(LayoutKind.Explicit, Size = 0x170)]
    public struct CastInfo {
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

        [FieldOffset(0x58)] public fixed ulong ActionRecipientsObjectIdArray[32];
        [FieldOffset(0x158)] public int ActionRecipientsCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct ForayInfo {
        [FieldOffset(0x00)] public byte ForayRank;

        //bozja
        public byte ResistanceRank {
            get => ForayRank;
            set => ForayRank = value;
        }

        //eureka
        public byte ElementalLevel {
            get => ForayRank;
            set => ForayRank = value;
        }
        [FieldOffset(0x01)] public EurekaElement Element; //only on enemies
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xF0)]
    public partial struct VfxContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public void** VfxListenerVTable;

        [FieldOffset(0x18)] public VfxData* VfxData;
        [FieldOffset(0x20)] public VfxData* VfxData2;
        [FieldOffset(0x48)] public VfxData* Omen;

        [FieldOffset(0xD0)] public ushort VoiceId;

        [MemberFunction("E8 ?? ?? ?? ?? 0F B6 06 3C")]
        public partial nint LoadCharacterSound(int unk1, int unk2, nint unk3, ulong unk4, int unk5, int unk6, ulong unk7);
    }

    //0x10 bytes are from the base class which is just vtable + gameobject ptr (same as Companion-/DrawDataContainer)
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct MountContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public Character* MountObject;
        [FieldOffset(0x18)] public ushort MountId;
        [FieldOffset(0x1C)] public float DismountTimer;
        //1 in dismount animation, 4 = instant delete mount when dismounting (used for npcs and such)
        [FieldOffset(0x20)] public byte Flags;
        [FieldOffset(0x24)] public fixed uint MountedObjectIds[7];

        [MemberFunction("E8 ?? ?? ?? ?? 8B 43 ?? 41 89 46")]
        public partial void CreateAndSetupMount(short mountId, uint buddyModelTop, uint buddyModelBody, uint buddyModelLegs, byte buddyStain, byte unk6, byte unk7);

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? 80 B8 ?? ?? ?? ?? ?? 74 ?? 0F B6 90")]
        public partial void SetupMount(short mountId, uint buddyModelTop, uint buddyModelBody, uint buddyModelLegs, byte buddyStain);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct CompanionContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public Companion* CompanionObject;
        //used if minion is summoned but the object slot is taken by a mount
        [FieldOffset(0x18)] public ushort CompanionId;

        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 66 44 89 7F")]
        public partial void SetupCompanion(short companionId, uint param);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public partial struct OrnamentContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public Ornament* OrnamentObject;
        [FieldOffset(0x18)] public ushort OrnamentId;

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B ?? 0F B7 97")]
        public partial void SetupOrnament(short ornamentId, uint param);
    }

    // Reaper Shroud seems to be mostly hardcoded.
    // It applies a transformation to NpcEquip row 2161 (which only sets the body slot to 8100,1).
    // It also enables the Vfx in this container, and toggles the 'atr_eye_a' attribute in the model (for the red pupils).
    // We do not actually know where all the other values come in, nothing except Flags and Vfx is actually used by Reaper Shroud (not even NpcEquipId, strangely).
    // This probably is used by other transformations too, but we have not found any yet.
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public struct ReaperShroudContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public void** VfxListenerVTable;
        [FieldOffset(0x18)] public ushort StanceChangeId;
        [FieldOffset(0x1C)] public uint StanceChangeState;
        [FieldOffset(0x20)] public float Timer;
        [FieldOffset(0x28)] public void* CopyObject;
        [FieldOffset(0x30)] public ShroudFlags Flags;
        [FieldOffset(0x40)] public VfxData* Vfx;
        [FieldOffset(0x3C)] public ushort NpcEquipId;

        [Flags]
        public enum ShroudFlags : uint {
            ShroudAttacking = 0x01, // On when the character is using a skill from reaper shroud, can be on for a short time without shroud itself being on.
            ShroudActive = 0x02, // On as long as the transformation is enabled.
            ShroudLoading = 0x0100, // On at the start before the VFX is loaded.
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x620)]
    public struct GazeContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public GazeController Controller;
        /// <summary>
        /// When using /facecamera, this is the rotation of the camera.<br/>
        /// When editing banner and the character is following the camera (either with head or eyes), this field holds the position of the camera.
        /// </summary>
        [FieldOffset(0x5F0)] public Vector3 CameraVector; // maybe Vector4 with unused W field?

        [FieldOffset(0x600)] public byte FaceCameraFlag; // looks like a bitfield but only with one bit used

        [FieldOffset(0x604)] public Vector2 BannerHeadDirection;
        [FieldOffset(0x60C)] public Vector2 BannerEyeDirection;
        [FieldOffset(0x614)] public BannerCameraFollowFlags BannerCameraFollowFlag;

        public bool IsFacingCamera {
            get => (FaceCameraFlag & 0x1) == 0x1;
            set => FaceCameraFlag |= 0x1;
        }

        [Flags]
        public enum BannerCameraFollowFlags : byte {
            None = 0,
            Head = 1,
            Eyes = 2,
        }
    }

    public enum EurekaElement : byte {
        None = 0,
        Fire = 1,
        Ice = 2,
        Wind = 3,
        Earth = 4,
        Lightning = 5,
        Water = 6,
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
