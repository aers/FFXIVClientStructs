namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGatheringNote
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GatheringNote)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct AgentGatheringNote {
    [FieldOffset(0xA0)] public uint ContextMenuItemId;

    [FieldOffset(0xB8)] public GatheringAreaInfo* GatheringAreaInfo; // Represents the currently set gathering area

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 83 F8 08")]
    public partial void OpenGatherableByItemId(ushort itemId);
}

// 0xC8 is the minimum size, total size is unknown, 0x10 + sizeof(OpenMapInfo) [0xB8]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct GatheringAreaInfo {
    [FieldOffset(0x10)] public OpenMapInfo OpenMapInfo;
}
