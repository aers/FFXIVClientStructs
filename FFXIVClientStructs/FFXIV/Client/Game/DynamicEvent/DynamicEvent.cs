using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.DynamicEvent;

public enum DynamicEventState : byte
{
    NotActive = 0,
    Registration = 1,
    Waiting = 2,
    BattleUnderway = 3
}

public enum DynamicEventRegistrationState : byte
{
    NotRegistered = 0,
    Registered = 1,
    Ready = 3,
    Deployed = 4
}

[StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
public struct DynamicEvent
{
    [FieldOffset(0x40)] public uint QuestId;
    [FieldOffset(0x44)] public uint LogMessageId;
    [FieldOffset(0x4E)] public byte DynamicEventTypeId;
    [FieldOffset(0x4F)] public byte DynamicEventEnemyTypeId;
    [FieldOffset(0x50)] public byte MaxParticipants;
    [FieldOffset(0x51)] public byte DurationMinutes;
    [FieldOffset(0x52)] public byte LargeScaleBattleId;
    [FieldOffset(0x53)] public byte SingleBattleId;
    [FieldOffset(0x54)] public uint FinishTimeEpoch; // end time of current state
    [FieldOffset(0x58)] public uint SecondsRemaining; // only used while State == BattleUnderWay
    [FieldOffset(0x5C)] public ushort Duration; // in seconds
    [FieldOffset(0x60)] public ushort DynamicEventId;
    [FieldOffset(0x63)] public DynamicEventState State;
    [FieldOffset(0x64)] public DynamicEventRegistrationState RegistrationState; // self/party registration status
    [FieldOffset(0x65)] public byte NumCombatants;
    [FieldOffset(0x66)] public byte Progress; // 0-100
    [FieldOffset(0x68)] public Utf8String Name;
    [FieldOffset(0xD0)] public Utf8String Description;
    [FieldOffset(0x138)] public uint MapIconId;

    [FieldOffset(0x170)] public Vector3 Position;
}
