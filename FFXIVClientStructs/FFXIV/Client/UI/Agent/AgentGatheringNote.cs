namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.GatheringNote)]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentGatheringNote {

    [FieldOffset(0xB8)] public GatheringAreaInfo* GatheringAreaInfo; // Represents the currently set gathering area

    [MemberFunction("E8 ?? ?? ?? ?? EB 63 48 83 F8")]
    public partial void OpenGatherableByItemId(ushort itemId);
}

// 0xC8 is the minimum size, total size is unknown, 0x10 + sizeof(OpenMapInfo) [0xB8]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct GatheringAreaInfo {
    [FieldOffset(0x10)] public OpenMapInfo OpenMapInfo;
}
