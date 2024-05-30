using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.GcArmyExpedition)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentGcArmyExpedition {
    [FieldOffset(0x28)] public GcArmyExpeditionData* ExpeditionData;

    [FieldOffset(0x40)] public int SelectedTab;
    [FieldOffset(0x44)] public int SelectedRow;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1998)]
public unsafe partial struct GcArmyExpeditionData {
    [FieldOffset(0x10)] public int NumEntries;

    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray50<MissionInfo> _missionInfo;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct MissionInfo {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public byte Available;
    [FieldOffset(0x70)] public byte Level;
}
