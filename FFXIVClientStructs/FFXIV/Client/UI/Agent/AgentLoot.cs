using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Loot)]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentLoot {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x2C)] public byte HoveredSlotIndex;
    [FieldOffset(0x30)] public uint HoveredItemId;
    [FieldOffset(0x74)] public int SelectedSlotIndex;
    [FieldOffset(0x7C)] public int NumItems;
}
