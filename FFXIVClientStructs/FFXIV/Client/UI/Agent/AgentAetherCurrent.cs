namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[VirtualTable("C6 43 30 01 48 8D 05", 7)]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
[GenerateInterop]
[Inherits<AgentInterface>]
public partial struct AgentAetherCurrent {
    [FieldOffset(0x64)] public byte TabIndex;
}
