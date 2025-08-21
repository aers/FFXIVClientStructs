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

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 48 83 EC ?? 0F B6 D9")]
    public static partial void UpdateJobSettings(byte job, byte defaultAction, byte actionHiddenFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 3F 48 8B 4F 08")]
    public static partial void GetJobSettings(byte job, byte* outDefaultAction, byte* outActionHiddenFlags);
}
