using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.WKSMissionInfomation)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct AgentWKSMissionInfomation {
    [FieldOffset(0x28)] public MissionInfo* Data;
    [FieldOffset(0x30)] public Utf8String MissionTitle;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct MissionInfo {
        [FieldOffset(0x00)] public long ServerTime;
        [FieldOffset(0x0C)] public uint CurrentMissionUnitId;
        [FieldOffset(0x10)] public byte State;
        [FieldOffset(0x14)] public byte Flags;
    }
}
