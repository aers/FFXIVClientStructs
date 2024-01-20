using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MycBattleAreaInfo)]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentMycBattleAreaInfo {
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public MycDynamicEventData* MycDynamicEventData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct MycDynamicEventData {
    [FieldOffset(0x0C)] public byte Count;

    [FixedSizeArray<MycDynamicEvent>(3)]
    [FieldOffset(0x10)] public fixed byte Array[3 * 0x78];
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
