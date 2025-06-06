namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MKDSupportJob)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentMKDSupportJob {
    [FieldOffset(0x28)] private uint SelectedAction;
    [FieldOffset(0x2C)] private uint SelectedActionIcon;
    [FieldOffset(0x30)] public byte CurrentJob;
    [FieldOffset(0x31)] public byte DefaultAction;
    [FieldOffset(0x32)] public byte ActionHiddenFlags;
}
