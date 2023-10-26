using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// ctor "48 83 EC 28 48 83 3D ?? ?? ?? ?? ?? 75 2E 33 D2"
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct GcArmyManager {
    [MemberFunction("E8 ?? ?? ?? ?? 8B 57 7C")]
    public static partial GcArmyManager* Instance();

    /// <remarks> Data is loaded on-demand inside GC Barracks </remarks>
    [FieldOffset(0)] public GcArmyData* Data;
    [FieldOffset(0x08)] public uint LastMissionCompleteNotificationTimestamp;
    [FieldOffset(0x0C)] public uint LastTrainingCompleteNotificationTimestamp;

    [MemberFunction("E8 ?? ?? ?? ?? 8B F0 41 8B DF")]
    public partial uint GetMemberCount();

    [MemberFunction("E8 ?? ?? ?? ?? 48 63 3B")]
    public partial GcArmyMember* GetMember(uint index);
}

[StructLayout(LayoutKind.Explicit, Size = 0xB18)]
public unsafe partial struct GcArmyData {
    [FixedSizeArray<GcArmyMember>(8)]
    [FieldOffset(0)] public fixed byte Members[8 * 0x50];
    /// <remarks> RowId of GcArmyProgress </remarks>
    [FieldOffset(0x280)] public byte Progress;

    /// <remarks> RowId of GcArmyExpedition </remarks>
    [FieldOffset(0x282)] public ushort CurrentExpedition;

    [FieldOffset(0x288)] public ushort BonusPhysical;
    [FieldOffset(0x28A)] public ushort BonusMental;
    [FieldOffset(0x28C)] public ushort BonusTactical;

    [FieldOffset(0x2FC)] public uint MissionRewardExperience;

    [FieldOffset(0x370)] public uint RecruitENpcResidentId;

    [FieldOffset(0x378)] public CustomizeData RecruitCustomizeData;

    [FieldOffset(0x3C0)] public GcArmyMember RecruitMember;

    [FieldOffset(0x470)] public byte MemberCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
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
    [FieldOffset(0x4B)] public byte MasteryIndependent;
    [FieldOffset(0x4C)] public byte MasteryOffensive;
    [FieldOffset(0x4D)] public byte MasteryDefensive;
    [FieldOffset(0x4E)] public byte MasteryBalanced;
}

[Flags]
public enum GcArmyMemberFlag : byte {
    None = 0,
    OnSquadronMission = 1,
    InTraining = 2,
    ReturnedFromMission = 4, // maybe
}
