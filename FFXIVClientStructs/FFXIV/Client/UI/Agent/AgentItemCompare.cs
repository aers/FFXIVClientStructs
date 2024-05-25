using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ItemCompare)]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public partial struct AgentItemComp {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [MemberFunction("E8 ?? ?? ?? ?? EB 3F 83 F8 FE")]
    public partial void CompareItem(ushort parentAddonId, uint itemId, byte stainId);
}
