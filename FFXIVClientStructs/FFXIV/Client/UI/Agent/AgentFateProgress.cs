using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFateProgress
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FateProgress)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18C0)]
public partial struct AgentFateProgress {
    [FieldOffset(0x2A)] public byte TabIndex;

    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray3<FateProgressTab> _tabs;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x7E8)]
public partial struct FateProgressTab {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray6<FateProgressZone> _zones;
}

[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public partial struct FateProgressZone {
    [FieldOffset(0x00)] public uint TerritoryTypeId;
    [FieldOffset(0x04)] public byte DisplayOrder;
    [FieldOffset(0x08)] public Utf8String ZoneName;
    [FieldOffset(0x70)] public byte CurrentRank;
    [FieldOffset(0x71)] public byte MaxRank;
    [FieldOffset(0x72)] public ushort FateProgress;
    [FieldOffset(0x74)] public ushort NeededFates;
    [FieldOffset(0x78)] public Utf8String RankText;
    [FieldOffset(0xE0)] public Utf8String ProgressText;
}
