using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public partial struct SpawnNpcPacket {
    [FieldOffset(0x00)] public uint GimmickId;
    [FieldOffset(0x04)] private uint Unk4; // Character+0x1BC0
    [FieldOffset(0x08)] public byte CharacterDataFlags; // CharacterData.Flags
    [FieldOffset(0x09)] public byte CharacterDataIcon; // CharacterData.Icon
    [FieldOffset(0x0A)] private byte UnkA; // flag to toggle 2 on Character+0x48
    [FieldOffset(0x0B)] private byte UnkB; // Character+0x41 Pose?
    [FieldOffset(0x0C)] private byte UnkC; // Character+0x42
    [FieldOffset(0x0D)] private byte UnkD; // Character+0x44
    [FieldOffset(0x0E)] private byte UnkE; // Character+0x43
    [FieldOffset(0x0F)] private byte UnkF; // flag to toggle 1 on Character+0x48
    [FieldOffset(0x10)] public CommonSpawnData Common;
    [FieldOffset(0x288)] private byte Unk288; // SubKind == 1 ? ModelContainer+0x39 : ModelContainer+0x3A
    [FieldOffset(0x289)] private byte Unk289; // ModelContainer+0x3B
    [FieldOffset(0x28A)] private uint Unk28A; // ModelContainer+0x3C
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public partial struct SpawnPlayerPacket {
    [FieldOffset(0x00)] public ulong AccountId;
    [FieldOffset(0x08)] public ulong ContentId;
    [FieldOffset(0x10)] public ushort TitleId;
    [FieldOffset(0x12)] public ushort TimelineBaseOverride;
    [FieldOffset(0x14)] public ushort CurrentWorldId;
    [FieldOffset(0x16)] public ushort HomeWorldId;
    [FieldOffset(0x18)] public byte GMRank;
    [FieldOffset(0x19)] private ushort Unk19; // Character+0x1CE0
    [FieldOffset(0x1B)] private byte OnlineStatus;
    [FieldOffset(0x1C)] private byte Pose; // 4 bits PoseType, 4 bits CPoseState
    [FieldOffset(0x1D)] private ushort Unk1D; // GameObject+0x32
    [FieldOffset(0x1F)] private byte Unk1F; // padding!?
    [FieldOffset(0x20)] public CommonSpawnData Common;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public partial struct CommonSpawnData {
    [FieldOffset(0x00)] public GameObjectId TargetId;
    [FieldOffset(0x08)] public CrestData FreeCompanyCrestData;
    [FieldOffset(0x10)] public WeaponModelId MainhandWeaponModel;
    [FieldOffset(0x18)] public WeaponModelId OffhandWeaponModel;
    [FieldOffset(0x20)] public WeaponModelId CraftToolModel;
    [FieldOffset(0x28)] public GameObjectId CombatTaggerId;
    [FieldOffset(0x30)] public uint BaseId;
    [FieldOffset(0x34)] public uint NameId;
    [FieldOffset(0x38)] public uint LayoutId;
    [FieldOffset(0x3C)] public uint ObjectType; // depends on ObjectKind? can be CompanionOwnerId, can also be FurnitureMemory index
    [FieldOffset(0x40)] public uint EventId;
    [FieldOffset(0x44)] public uint OwnerId;
    [FieldOffset(0x48)] public uint TetherTargetId;
    [FieldOffset(0x4C)] public uint MaxHealthPoints;
    [FieldOffset(0x50)] public uint HealthPoints;
    [FieldOffset(0x54)] public uint DisplayFlags;
    [FieldOffset(0x58)] public ushort FateId;
    [FieldOffset(0x5A)] public ushort MaxResourcePoints; // MP/GP/CP
    [FieldOffset(0x5C)] public ushort ResourcePoints;
    [FieldOffset(0x5E)] private ushort Unk5E;
    [FieldOffset(0x60)] public ushort ModelChara;
    [FieldOffset(0x62)] public ushort Rotation;
    [FieldOffset(0x64)] public ushort MountId;
    [FieldOffset(0x66)] public ushort CompanionId;
    [FieldOffset(0x68)] public ushort FollowMountId;
    [FieldOffset(0x6A)] public ushort OrnamentId;
    [FieldOffset(0x6C)] public ushort TetherId;
    [FieldOffset(0x6E)] public byte SpawnIndex; // unused
    [FieldOffset(0x6F)] public CharacterModes CharacterMode;
    [FieldOffset(0x70)] public byte ModeParam;
    [FieldOffset(0x71)] public ObjectKind ObjectKind;
    [FieldOffset(0x72)] public byte SubKind;
    [FieldOffset(0x73)] public byte VoiceId;
    [FieldOffset(0x74)] public byte FreeCompanyCrestBitfield;
    [FieldOffset(0x75)] public byte Battalion;
    [FieldOffset(0x76)] public byte Level;
    [FieldOffset(0x77)] public byte ClassJobId;
    [FieldOffset(0x78)] public byte EventState;
    [FieldOffset(0x79)] private byte Unk79; // GameObject+0x97
    [FieldOffset(0x7A)] public byte CombatTagType;
    [FieldOffset(0x7B)] public byte BuddyEquipHead;
    [FieldOffset(0x7C)] public byte BuddyEquipChest;
    [FieldOffset(0x7D)] public byte BuddyEquipFeet;
    [FieldOffset(0x7E)] public byte BuddyStain;
    [FieldOffset(0x7F)] public byte StatusLoopVfxId;
    [FieldOffset(0x80)] public byte ForayRank;
    [FieldOffset(0x81)] public byte ForayElement;
    [FieldOffset(0x82)] public byte ModelScaleId; // ModelContainer.ModelScaleId
    [FieldOffset(0x83)] public byte ModelState; // Timeline.ModelState
    [FieldOffset(0x84)] public byte ModelAttributeFlags; // ModelContainer.ModelAttributeFlags
    [FieldOffset(0x85)] public byte AnimationState; // Timeline.AnimationState, 4 bits each

    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray30<StatusEffect> _statusEffects;
    [FieldOffset(0x1F0)] public global::System.Numerics.Vector3 Position;
    [FieldOffset(0x1FC), FixedSizeArray] internal FixedSizeArray10<LegacyEquipmentModelId> _equipmentModelIds;
    [FieldOffset(0x224), FixedSizeArray] internal FixedSizeArray10<byte> _modelStain2Ids;
    [FieldOffset(0x22E), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    [FieldOffset(0x232), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x252)] public CustomizeData CustomizeData;
    [FieldOffset(0x26C), FixedSizeArray(isString: true)] internal FixedSizeArray6<byte> _freeCompanyTag;

    [FieldOffset(0x30), Obsolete("Renamed to BaseId")] public uint BNpcBaseId;
    [FieldOffset(0x34), Obsolete("Renamed to NameId")] public uint BNpcNameId;

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct StatusEffect {
        [FieldOffset(0x0)] public ushort StatusId;
        [FieldOffset(0x2)] public ushort Param;
        [FieldOffset(0x4)] public float RemainingTime;
        [FieldOffset(0x8)] public uint SourceObjectId;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct SpawnObjectPacket {
    [FieldOffset(0x00)] public byte ObjectIndex;
    [FieldOffset(0x01)] public byte ObjectKind;
    [FieldOffset(0x02)] public byte TargetableStatus;
    [FieldOffset(0x03)] public byte Visibility;
    /// <remarks> <see cref="HousingObjectId"/> when <see cref="ObjectKind.HousingEventObject"/>. </remarks>
    [FieldOffset(0x04)] public uint BaseId;
    [FieldOffset(0x08)] public uint EntityId;
    /// <remarks> Used for <see cref="ObjectKind.EventObj"/> or <see cref="ObjectKind.GatheringPoint"/>. </remarks>
    [FieldOffset(0x0C)] public uint LayoutId;
    /// <remarks> Used for <see cref="ObjectKind.EventObj"/>, or for <see cref="ObjectKind.HousingEventObject"/> as bool to decide whether it is a <see cref="HousingCombinedObject"/> (true) or a <see cref="HousingEventObject"/> (false). </remarks>
    [FieldOffset(0x10)] public EventId EventId;
    [FieldOffset(0x14)] public uint OwnerId;
    /// <remarks> Used for <see cref="ObjectKind.EventObj"/>. </remarks>
    [FieldOffset(0x18)] public uint GimmickId;
    [FieldOffset(0x1C)] public float Radius;
    [FieldOffset(0x20)] private ushort Unk20; // SharedGroupTimelineState?
    [FieldOffset(0x22)] public ushort Rotation;
    /// <remarks> Used for <see cref="ObjectKind.EventObj"/>. </remarks>
    [FieldOffset(0x24)] public ushort FateId;
    /// <remarks> Used for <see cref="ObjectKind.EventObj"/>. </remarks>
    [FieldOffset(0x26)] public byte EventState;
    [FieldOffset(0x27)] private byte Unk27;
    [FieldOffset(0x28)] private uint Unk28;
    [FieldOffset(0x2C)] private uint Unk2C;
    [FieldOffset(0x30)] private uint Unk30;
    [FieldOffset(0x34)] public float PositionX;
    [FieldOffset(0x38)] public float PositionY;
    [FieldOffset(0x3C)] public float PositionZ;
}
