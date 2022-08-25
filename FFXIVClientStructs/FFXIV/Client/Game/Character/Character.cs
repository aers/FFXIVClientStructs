using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;
// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Graphics::Vfx::VfxDataListenner

// size = 0x19F0
// ctor E8 ?? ?? ?? ?? 4C 8B D0 4C 63 F7
[StructLayout(LayoutKind.Explicit, Size = 0x1B00)]
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

    [FieldOffset(0x1E0)] public byte ClassJob;
    [FieldOffset(0x1E1)] public byte Level;

    #endregion

    [FieldOffset(0x6D0)] public DrawDataContainer DrawData;

    [FieldOffset(0x818)] public fixed byte EquipSlotData[4 * 10];
    [FieldOffset(0x840)] public fixed byte CustomizeData[0x1A];

    [FieldOffset(0xC60)] public uint PlayerTargetObjectID;

    [FieldOffset(0x1770)] public Balloon Balloon;

    [FieldOffset(0x1978)] public VfxData* VfxData;
    [FieldOffset(0x1980)] public VfxData* VfxData2;
    [FieldOffset(0x19A8)] public VfxData* Omen;

    [FieldOffset(0x1A30)] public Companion* CompanionObject; // minion
    [FieldOffset(0x1A48)] public fixed byte FreeCompanyTag[6];
    [FieldOffset(0x1A68)] public uint TargetObjectID;

    [FieldOffset(0x1AAC)] public uint NameID;

    [FieldOffset(0x1AC8)] public ushort CurrentWorld;
    [FieldOffset(0x1ACA)] public ushort HomeWorld;
    [FieldOffset(0x1AD4)] public byte EventState; // or something
    [FieldOffset(0x1AD6)] public byte OnlineStatus;
    [FieldOffset(0x1AEB)] public byte ShieldValue;
    [FieldOffset(0x1AEF)] public byte StatusFlags;
    [FieldOffset(0x1ABC)] public uint CompanionOwnerID;

    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
    public partial uint GetTargetId();

    // Seemingly used for cutscenes and GPose.
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 9F ?? ?? ?? ?? 48 8D 8F")]
    public partial ulong CopyFromCharacter(Character* source, uint unk);


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
}