namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Loot)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentLoot {
    [FieldOffset(0x2C)] public byte HoveredSlotIndex;
    [FieldOffset(0x30)] public uint HoveredItemId;
    [FieldOffset(0x74)] public int SelectedSlotIndex;
    [FieldOffset(0x7C)] public int NumItems;
}
