using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::GcArmyManager
// Squadron
// ctor "48 83 EC ?? 48 83 3D ?? ?? ?? ?? ?? 75 ?? 33 D2 45 33 C0 8D 4A ?? E8 ?? ?? ?? ?? 33 C9 48 85 C0 74 ?? 48 89 08 48 89 48 ?? 48 89 05"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct GcArmyManager {
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D AC")]
    public static partial GcArmyManager* Instance();

    /// <remarks> Data is loaded on-demand inside GC Barracks </remarks>
    [FieldOffset(0)] public GcArmyData* Data;
    [FieldOffset(0x08)] public uint LastMissionCompleteNotificationTimestamp;
    [FieldOffset(0x0C)] public uint LastTrainingCompleteNotificationTimestamp;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4E 28 8B FB")]
    public partial uint GetMemberCount();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 48 13")]
    public partial GcArmyMember* GetMember(uint index);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF28)] // TODO: size changed, fix offsets
public unsafe partial struct GcArmyData {
    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray8<GcArmyMember> _members;
    // Receive network packet: "0F 10 02 48 8B C2"
    /// <remarks> RowId of GcArmyProgress </remarks>
    [FieldOffset(0x2C0)] public byte Progress;

    /// <remarks> RowId of GcArmyExpedition </remarks>
    [FieldOffset(0x2C2)] public ushort CurrentExpedition;

    [FieldOffset(0x2C8)] public ushort BonusPhysical;
    [FieldOffset(0x2CA)] public ushort BonusMental; 
    [FieldOffset(0x2CC)] public ushort BonusTactical;

    [FieldOffset(0x2FC)] public uint MissionRewardExperience;

    // Recruit member network packet: "40 57 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 84 24 ? ? ? ? 48 8B FA"
    [FieldOffset(0x33C)] public uint RecruitENpcResidentId;

    [FieldOffset(0x3B8)] public CustomizeData RecruitCustomizeData; // maybe +0x40?

    [FieldOffset(0x408)] public GcArmyMember RecruitMember;

    [FieldOffset(0x4C0)] public byte MemberCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)] // TODO: size changed, fix offsets
public unsafe partial struct GcArmyMember {
    [FieldOffset(0x00)] public uint Face;
    [FieldOffset(0x04)] public uint ENpcResidentId;
    [FieldOffset(0x08)] public byte Race;
    [FieldOffset(0x09)] public byte Sex;
    [FieldOffset(0x0A)] public byte ClassJob;
    /// <remarks> RowId of GcArmyMemberGrowExp </remarks>
    [FieldOffset(0x0B)] public byte Level;
    [FieldOffset(0x0C)] public uint Experience;
    [FieldOffset(0x12)] public GcArmyMemberFlag Flags;
    /// <remarks> RowId of GcArmyCandidateCategory </remarks>
    [FieldOffset(0x13)] public byte CandidateCategory;
    [FieldOffset(0x14)] public uint EnlistmentTimestamp;
    /// <remarks> RowId of GcArmyCaptureTactics </remarks>
    [FieldOffset(0x1C)] public byte CaptureTactics;

    /// <summary> Active Squadron Chemistry </summary>
    /// <remarks> RowId of GcArmyExpeditionTrait </remarks>
    [FieldOffset(0x1F)] public byte ActiveTrait;
    /// <summary> Active Squadron Chemistry Condition </summary>
    /// <remarks> RowId of GcArmyExpeditionTraitCond </remarks>
    [FieldOffset(0x20)] public byte ActiveTraitCond;

    /// <summary> Inactive Squadron Chemistry </summary>
    /// <remarks> RowId of GcArmyExpeditionTrait </remarks>
    [FieldOffset(0x22)] public byte InactiveTrait;
    /// <summary> Inactive Squadron Chemistry Condition </summary>
    /// <remarks> RowId of GcArmyExpeditionTraitCond </remarks>
    [FieldOffset(0x23)] public byte InactiveTraitCond;

    [FieldOffset(0x28)] public uint GlamourMainHand;
    [FieldOffset(0x2C)] public uint GlamourOffHand;
    [FieldOffset(0x30)] public uint GlamourHead;
    [FieldOffset(0x34)] public uint GlamourBody;
    [FieldOffset(0x38)] public uint GlamourHands;
    [FieldOffset(0x3C)] public uint GlamourLegs;
    [FieldOffset(0x40)] public uint GlamourFeet;
    [FieldOffset(0x44)] public byte StainMainHand;
    [FieldOffset(0x45)] public byte StainOffHand;
    [FieldOffset(0x46)] public byte StainHead;
    [FieldOffset(0x47)] public byte StainBody;
    [FieldOffset(0x48)] public byte StainHands;
    [FieldOffset(0x49)] public byte StainLegs;
    [FieldOffset(0x4A)] public byte StainFeet;
    [FieldOffset(0x4B)] public byte Stain2MainHand;
    [FieldOffset(0x4C)] public byte Stain2OffHand;
    [FieldOffset(0x4D)] public byte Stain2Head;
    [FieldOffset(0x4E)] public byte Stain2Body;
    [FieldOffset(0x4F)] public byte Stain2Hands;
    [FieldOffset(0x50)] public byte Stain2Legs;
    [FieldOffset(0x51)] public byte Stain2Feet;
    [FieldOffset(0x52)] public byte MasteryIndependent;
    [FieldOffset(0x53)] public byte MasteryOffensive;
    [FieldOffset(0x54)] public byte MasteryDefensive;
    [FieldOffset(0x55)] public byte MasteryBalanced;
}

[Flags]
public enum GcArmyMemberFlag : byte {
    None = 0,
    OnSquadronMission = 1,
    InTraining = 2,
    ReturnedFromMission = 4, // maybe
}
