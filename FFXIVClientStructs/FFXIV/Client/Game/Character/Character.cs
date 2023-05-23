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

    #region This is inside a new 0x48 byte class at offset 0x1A8

    [FieldOffset(0x1B0)] public float ModelScale;
    [FieldOffset(0x1B4)] public int ModelCharaId;
    [FieldOffset(0x1B8)] public int ModelSkeletonId;
    [FieldOffset(0x1BC)] public int ModelCharaId_2; // == -1 -> return ModelCharaId
    [FieldOffset(0x1C0)] public int ModelSkeletonId_2; // == 0 -> return ModelSkeletonId

    [FieldOffset(0x1C4)] public uint Health;
    [FieldOffset(0x1C8)] public uint MaxHealth;
    [FieldOffset(0x1CC)] public uint Mana;
    [FieldOffset(0x1D0)] public uint MaxMana;
    [FieldOffset(0x1D4)] public ushort GatheringPoints;
    [FieldOffset(0x1D6)] public ushort MaxGatheringPoints;
    [FieldOffset(0x1D8)] public ushort CraftingPoints;
    [FieldOffset(0x1DA)] public ushort MaxCraftingPoints;

    [FieldOffset(0x1DC)] public short TransformationId;
    [FieldOffset(0x1DE)] public short StatusEffectVFXId;
    [FieldOffset(0x1E2)] public byte ClassJob;
    [FieldOffset(0x1E3)] public byte Level;

    #endregion

    [FieldOffset(0x660)] public MountContainer Mount;
    [FieldOffset(0x6C8)] public CompanionContainer Companion;
    [FieldOffset(0x6E8)] public DrawDataContainer DrawData;

    [Obsolete($"Use {nameof(DrawData)}"), FieldOffset(0x830)] public fixed byte EquipSlotData[4 * 10];
    [Obsolete($"Use {nameof(DrawData)}.CustomizeData"), FieldOffset(0x858)] public fixed byte CustomizeData[0x1A];

    [FieldOffset(0x878)] public OrnamentContainer Ornament;
    [FieldOffset(0x8F0)] public ActionTimelineManager ActionTimelineManager;

    [FieldOffset(0xCB0)] public uint PlayerTargetObjectID;

    [FieldOffset(0x17C0)] public Balloon Balloon;

    [FieldOffset(0x19C8)] public VfxData* VfxData; 
    [FieldOffset(0x19D0)] public VfxData* VfxData2;
    [FieldOffset(0x19F8)] public VfxData* Omen; 

    [FieldOffset(0x1A80)] public Companion* CompanionObject; // minion
    [FieldOffset(0x1A98)] public fixed byte FreeCompanyTag[6];
    [FieldOffset(0x1AB8)] public ulong TargetObjectID;

    [FieldOffset(0x1B00)] public uint NameID;

    [FieldOffset(0x1B1C)] public ushort CurrentWorld;
    [FieldOffset(0x1B1E)] public ushort HomeWorld;
    [FieldOffset(0x1DE)] public ushort TitleID;
    [FieldOffset(0x1B26)] public byte EventState; // Leave for backwards compat. See Mode.
    [FieldOffset(0x1B26)] public CharacterModes Mode;
    [FieldOffset(0x1B27)] public byte ModeParam; // Different purpose depending on mode. See CharacterModes for more info.
    [FieldOffset(0x1B28)] public byte OnlineStatus;
    [FieldOffset(0x1B29)] public byte Battalion; // used for determining friend/enemy state
    [FieldOffset(0x1B17)] public byte ShieldValue;
    [FieldOffset(0x1B1B)] public byte StatusFlags;
    [FieldOffset(0x1B1F)] public byte StatusFlags4; // 0x80 flagged when permanent wetness in GPose is toggled.
    [FieldOffset(0x1AE8)] public uint CompanionOwnerID;

    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
    public partial ulong GetTargetId();

    // Seemingly used for cutscenes and GPose.
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 9F ?? ?? ?? ?? 48 8D 8F")]
    public partial ulong CopyFromCharacter(Character* source, uint unk);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 7F 48")]
    public partial bool IsMounted();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? E8 ?? ?? ?? ?? 48 8B 4C 24 ??")]
    public partial void SetMode(CharacterModes mode, byte modeParam);

    [VirtualFunction(79)]
    public partial StatusManager* GetStatusManager();

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
}
