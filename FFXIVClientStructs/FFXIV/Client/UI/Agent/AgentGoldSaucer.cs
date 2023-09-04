using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.GoldSaucer)]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct AgentGoldSaucer {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x5A)] public short GoldSaucerSelectedTab;
    [FieldOffset(0x5C)] public short ChocoboSeletedTab;
    [FieldOffset(0x100)] public int EditDeckSelectedPage;
    [FieldOffset(0x108)] public int EditDeckSelectedCardIndex;
}
