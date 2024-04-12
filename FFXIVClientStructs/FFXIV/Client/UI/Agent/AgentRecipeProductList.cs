using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RecipeProductList)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentRecipeProductList {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 8B FA B8")]
    public partial void SearchForRecipesUsingItem(uint itemId);
}
