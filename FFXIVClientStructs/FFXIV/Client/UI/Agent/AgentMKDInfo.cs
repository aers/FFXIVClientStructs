namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MKDInfo)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentMKDInfo {
    [FieldOffset(0x28)] public bool QuestComplete;

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 0F B6 CA E8 ?? ?? ?? ?? 84 C0")]
    public partial void SyncKnowledgeLevel(byte level);

    [MemberFunction("48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 3D")]
    public partial void OpenMapForDynamicEvent(uint dynamicEventId);
}
