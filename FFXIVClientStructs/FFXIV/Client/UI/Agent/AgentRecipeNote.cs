using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRecipeNote
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RecipeNote)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x568)]
public unsafe partial struct AgentRecipeNote {

    [FieldOffset(0x398)] public uint ContextMenuResultItemId;

    [FieldOffset(0x3B0)] public int SelectedCraftType;
    [FieldOffset(0x3BC)] public int SelectedRecipeIndex;
    [FieldOffset(0x3D4)] public uint ActiveCraftRecipeId; // 0 when not actively crafting, does not include 0x10_000
    [FieldOffset(0x3EC)] public bool RecipeSearchOpen;
    [FieldOffset(0x406)] public bool RecipeSearchProcessing;
    [FieldOffset(0x408)] public Utf8String RecipeSearch;
    [FieldOffset(0x498)] public byte RecipeSearchHistorySelected;
    [FieldOffset(0x4A0)] public StdDeque<Utf8String> RecipeSearchHistory;

    // Add 0x10_000, differentiate duplicate recipes by the CraftType value + 8
    // Name           CraftType ClassJob
    // Carpenter      0         8
    // Blacksmith     1         9
    // Armorer        2         10
    // Goldsmith      3         11
    // Leatherworker  4         12
    // Weaver         5         13
    // Alchemist      6         14
    // Culinarian     7         15
    public void OpenRecipeByRecipeId(uint recipeId) => OpenRecipeByRecipeIdInternal(recipeId + 0x10_000);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 83 F8 06")]
    public partial void OpenRecipeByItemId(uint itemId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 83 B9 ?? ?? ?? ?? ?? 8B FA 48 8B D9 0F 85 ?? ?? ?? ??")]
    public partial void OpenRecipeByRecipeIdInternal(uint internalRecipeId); // Add 0x10_000 to the Recipe row ID

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 48 83 EC 20 80 B9 ?? ?? ?? ?? ??")]
    public partial void SearchRecipe(Utf8String* text, byte a3, bool pushHistory);
}
