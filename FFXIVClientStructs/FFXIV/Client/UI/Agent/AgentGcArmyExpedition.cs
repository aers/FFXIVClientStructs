using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.GcArmyExpedition)]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentGcArmyExpedition {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public GcArmyExpeditionData* ExpeditionData;

    [FieldOffset(0x40)] public int SelectedTab;
    [FieldOffset(0x44)] public int SelectedRow;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1998)]
public unsafe partial struct GcArmyExpeditionData {
    [FieldOffset(0x10)] public int NumEntries;

    [FixedSizeArray<MissionInfo>(50)]
    [FieldOffset(0x18)] public fixed byte MissionInfoArray[0x78 * 50];
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct MissionInfo {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public byte Available;
    [FieldOffset(0x70)] public byte Level;
}
