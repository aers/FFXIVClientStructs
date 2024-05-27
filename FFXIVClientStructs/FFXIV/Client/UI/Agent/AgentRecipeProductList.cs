namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RecipeProductList)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentRecipeProductList {

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 8B FA B8")]
    public partial void SearchForRecipesUsingItem(uint itemId);
}
