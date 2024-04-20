using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RecipeItemContext)]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentRecipeItemContext {
    [FieldOffset(0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public uint ResultItemId;

    [MemberFunction("E8 ?? ?? ?? ?? 45 8B C4 41 8B D7")]
    public readonly partial void AddItemContextMenuEntries(uint itemId, byte flags, byte* itemName);
}
