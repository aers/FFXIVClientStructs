using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

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
    [FieldOffset(0x38)] public float BaseCastTime;
    [FieldOffset(0x3C)] public float TotalCastTime;

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
