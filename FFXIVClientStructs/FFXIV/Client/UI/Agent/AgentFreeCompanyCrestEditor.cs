using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.FreeCompanyCrestEditor)]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct AgentFreeCompanyCrestEditor {
    public static AgentFreeCompanyCrestEditor* Instance() =>
        (AgentFreeCompanyCrestEditor*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.FreeCompanyCrestEditor);

    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x60)] public CrestData OriginalCrest;
    [FieldOffset(0x68)] public CrestData CurrentCrest;
}
