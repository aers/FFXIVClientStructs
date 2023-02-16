using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.FishGuide)]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct AgentFishGuide
{
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 93 ?? ?? ?? ?? 48 8B CE")]
    public partial void OpenForItemId(uint itemId, bool isSpearfishing);
}
