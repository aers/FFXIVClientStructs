using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[VTableAddress("C6 43 30 01 48 8D 05", 7)]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public partial struct AgentAetherCurrent {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x64)] public byte TabIndex;
}
