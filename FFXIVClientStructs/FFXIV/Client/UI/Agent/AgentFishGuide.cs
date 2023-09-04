using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.FishGuide)]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AgentFishGuide {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 44 0F B6 83")]
    public partial void OpenForItemId(uint itemId, bool isSpearfishing);
}
