using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MycBattleAreaInfo)]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentMycBattleAreaInfo {

    [FieldOffset(0x28)] public MycDynamicEventData* MycDynamicEventData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x178)]
[GenerateInterop]
public unsafe partial struct MycDynamicEventData {
    [FieldOffset(0x0C)] public byte Count;

    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray3<MycDynamicEvent> _array;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct MycDynamicEvent {
    [FieldOffset(0x00)] public uint TimeLeft;
    [FieldOffset(0x04)] public ushort Id;
    [FieldOffset(0x07)] public MycDynamicEventState State;
    [FieldOffset(0x0A)] public ushort ParticipantCount;
    [FieldOffset(0x10)] public Utf8String Name;
}

public enum MycDynamicEventState : byte {
    None = 0,
    Register = 1,
    Commence = 2,
    Underway = 3
}
