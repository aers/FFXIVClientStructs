using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.GatheringNote)]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct AgentGatheringNote {
    public static AgentGatheringNote* Instance() => (AgentGatheringNote*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.GatheringNote);

    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0xB8)] public GatheringAreaInfo* GatheringAreaInfo; // Represents the currently set gathering area

    [MemberFunction("E8 ?? ?? ?? ?? EB 63 48 83 F8")]
    public partial void OpenGatherableByItemId(ushort itemID);
}

// 0xC8 is the minimum size, total size is unknown, 0x10 + sizeof(OpenMapInfo) [0xB8]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct GatheringAreaInfo {
    [FieldOffset(0x10)] public OpenMapInfo OpenMapInfo;
}
