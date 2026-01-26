using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRecipeNote
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RecipeNote")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3480)]
public unsafe partial struct AddonRecipeNote {
    [FieldOffset(0x238)] public AtkTextNode* CurrentJobLevel; // Job Level String [ex: "Level 90"]
    [FieldOffset(0x240)] public AtkTextNode* CurrentJobName; // Job Name String [ex: "Carpenter"]
    /// <summary>
    /// Sibling container to scrollable list of recipes and parent container to recipe characteristics text panel
    /// </summary>
    [FieldOffset(0x268)] public AtkResNode* RecipeListAndCharacteristicsPanelContainer;
    [FieldOffset(0x330)] public AtkComponentButton* TrialSynthesisButton;
    [FieldOffset(0x338)] public AtkComponentButton* QuickSynthesisButton;
    [FieldOffset(0x340)] public AtkComponentButton* SynthesizeButton;
    [FieldOffset(0x378)] public AtkTextNode* PaginationText; // Pagination Text [ex: "1-32"]
    [FieldOffset(0x3A8)] public AtkTextNode* CharacteristicsTextLine1; // Characteristics Line 1 [ex: "Quick Synthesis Unavailable"]
    [FieldOffset(0x3B0)] public AtkTextNode* CharacteristicsTextLine2; // Characteristics Line 2 [ex: "Craftsmanship Required: 3700"]
    [FieldOffset(0x3B8)] public AtkTextNode* CharacteristicsTextLine3; // Characteristics Line 3 [ex: "Quality Required for Synthesis: 13500"]
    [FieldOffset(0x3C0)] public AtkTextNode* CharacteristicsTextLine4; // Characteristics Line 4 [ex: "Expert Recipe"]
    [FieldOffset(0x3C8)] public AtkTextNode* CharacteristicsTextLine5; // Characteristics Line 5 [ex: "High-quality Uncraftable"]
    [FieldOffset(0x3E0)] public AtkTextNode* RecipeLevelLiteral; // Recipe Level Literal [ex: "Recipe Level"]
    [FieldOffset(0x488)] public AtkTextNode* SelectedRecipeName; // Selected Recipe Name [ex: "Water Otter Fountain Lumber"]
    [FieldOffset(0x490)] public AtkTextNode* SelectedRecipeDurability; // Durability [ex: "60"]
    [FieldOffset(0x498)] public AtkTextNode* SelectedRecipeDifficulty; // Difficulty [ex: "7480"]
    [FieldOffset(0x4A0)] public AtkTextNode* SelectedRecipeStartingQuality; // Starting Quality [ex: "0"]
    [FieldOffset(0x4A8)] public AtkTextNode* SelectedRecipeMaximumQuality; // Maximum Quality [ex: "13620"]
    [FieldOffset(0x4B0)] public AtkTextNode* SelectedRecipeHighestStartingQuality; // Max Starting Quality [ex: "(Max 50%)"]
    [FieldOffset(0x4B8)] public AtkTextNode* BagLiteral; // Bag Literal [ex: "Bag"]
    /// <summary>
    /// Inventory NQ/HQ Recipe Result Count [ex: "0\n\ue03c0", "\ue03c" being the HQ symbol]
    /// The HQ value is not present on items that cannot be HQ [ex: "0"]
    /// </summary>
    [FieldOffset(0x4C0)] public AtkTextNode* SelectedRecipeResultQuantityInInventoryNqAndHq;
    [FieldOffset(0x4C8)] public AtkTextNode* CraftableLiteral; // Craftable Literal [ex: "Craftable"]
    [FieldOffset(0x4D0)] public AtkTextNode* SelectedRecipeQuantityCraftableFromMaterialsInInventory; // Quantity Craftable from Inventory [ex: "10"]
    [FieldOffset(0x4E0)] public AtkTextNode* ProgressCalculationSentence; // Progress calculation sentence [ex: "At 100% efficiency, progress increases by 244."]
    [FieldOffset(0x4E8)] public AtkTextNode* QualityCalculationSentence; // Quality calculation sentence [ex: "At 100% efficiency, quality increases by 247."]
    [FieldOffset(0x500)] public AtkComponentButton* AetherCrystal1Button; // Left Side Aether Shard / Crystal / Clusters Button. Acts similar to an item slot.
    [FieldOffset(0x510)] public AtkTextNode* AetherCrystal1QuantityRequiredForCraft; // Left Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x518)] public AtkTextNode* AetherCrystal1QuantityInInventory; // Left Side Aether Shard / Crystals / Clusters in Inventory [ex: "6328"]
    [FieldOffset(0x520)] public AtkComponentButton* AetherCrystal2Button; // Right Side Aether Shard / Crystal / Clusters Button. Acts similar to an item slot.
    [FieldOffset(0x530)] public AtkTextNode* AetherCrystal2QuantityRequiredForCraft; // Right Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x538)] public AtkTextNode* AetherCrystal2QuantityInInventory; // Right Side Aether Shard / Crystals / Clusters in Inventory [ex: "9999"]
    [FieldOffset(0x548)] public AtkComponentNode* IngredientRow1; // Parent container for all sub-elements of Ingredient Row 1
    [FieldOffset(0x558)] public AtkTextNode* Ingredient1Name; // Ingredient 1 Name [ex: "Hamsa Tenderloin"]
    [FieldOffset(0x560)] public AtkTextNode* Ingredient1QuantityRequiredForCraft; // Ingredient 1 Required Quantity [ex: "1"]
    [FieldOffset(0x580)] public AtkTextNode* Ingredient1QuantityInInventoryNq; // Ingredient 1 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x588)] public AtkTextNode* Ingredient1QuantityInInventoryHq; // Ingredient 1 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x598)] public AtkComponentButton* Ingredient1QuantityIncrementButtonNq; // Ingredient 1 increment button/number for NQ items
    [FieldOffset(0x5A0)] public AtkComponentButton* Ingredient1QuantityIncrementButtonHq; // Ingredient 1 increment button/number for HQ items
    [FieldOffset(0x5D8)] public AtkComponentNode* IngredientRow2; // Parent container for all sub-elements of Ingredient Row 2
    [FieldOffset(0x5E8)] public AtkTextNode* Ingredient2Name; // Ingredient 2 Name [ex: "Coconut Milk"]
    [FieldOffset(0x5F0)] public AtkTextNode* Ingredient2QuantityRequiredForCraft; // Ingredient 2 Required Quantity [ex: "1"]
    [FieldOffset(0x610)] public AtkTextNode* Ingredient2QuantityInInventoryNq; // Ingredient 2 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x618)] public AtkTextNode* Ingredient2QuantityInInventoryHq; // Ingredient 2 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x628)] public AtkComponentButton* Ingredient2QuantityIncrementButtonNq; // Ingredient 2 increment button/number for NQ items
    [FieldOffset(0x630)] public AtkComponentButton* Ingredient2QuantityIncrementButtonHq; // Ingredient 2 increment button/number for HQ items
    [FieldOffset(0x668)] public AtkComponentNode* IngredientRow3; // Parent container for all sub-elements of Ingredient Row 3
    [FieldOffset(0x678)] public AtkTextNode* Ingredient3Name; // Ingredient 3 Name [ex: "Elder Nutmeg Seeds"]
    [FieldOffset(0x680)] public AtkTextNode* Ingredient3QuantityRequiredForCraft; // Ingredient 3 Required Quantity [ex: "2"]
    [FieldOffset(0x6A0)] public AtkTextNode* Ingredient3QuantityInInventoryNq; // Ingredient 3 Available NQ in Inventory [ex: "2"]
    [FieldOffset(0x6A8)] public AtkTextNode* Ingredient3QuantityInInventoryHq; // Ingredient 3 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x6B8)] public AtkComponentButton* Ingredient3QuantityIncrementButtonNq; // Ingredient 3 increment button/number for NQ items
    [FieldOffset(0x6C0)] public AtkComponentButton* Ingredient3QuantityIncrementButtonHq; // Ingredient 3 increment button/number for HQ items
    [FieldOffset(0x6F8)] public AtkComponentNode* IngredientRow4; // Parent container for all sub-elements of Ingredient Row 4
    [FieldOffset(0x708)] public AtkTextNode* Ingredient4Name; // Ingredient 4 Name [ex: "Upland Wheat Flour"]
    [FieldOffset(0x710)] public AtkTextNode* Ingredient4QuantityRequiredForCraft; // Ingredient 4 Required Quantity [ex: "1"]
    [FieldOffset(0x730)] public AtkTextNode* Ingredient4QuantityInInventoryNq; // Ingredient 4 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x738)] public AtkTextNode* Ingredient4QuantityInInventoryHq; // Ingredient 4 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x748)] public AtkComponentButton* Ingredient4QuantityIncrementButtonNq; // Ingredient 4 increment button/number for NQ items
    [FieldOffset(0x750)] public AtkComponentButton* Ingredient4QuantityIncrementButtonHq; // Ingredient 4 increment button/number for HQ items
    [FieldOffset(0x788)] public AtkComponentNode* IngredientRow5; // Parent container for all sub-elements of Ingredient Row 5
    [FieldOffset(0x798)] public AtkTextNode* Ingredient5Name; // Ingredient 5 Name [ex: "Fermented Butter"]
    [FieldOffset(0x7A0)] public AtkTextNode* Ingredient5QuantityRequiredForCraft; // Ingredient 5 Required Quantity [ex: "1"]
    [FieldOffset(0x7C0)] public AtkTextNode* Ingredient5QuantityInInventoryNq; // Ingredient 5 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x7C8)] public AtkTextNode* Ingredient5QuantityInInventoryHq; // Ingredient 5 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x7D8)] public AtkComponentButton* Ingredient5QuantityIncrementButtonNq; // Ingredient 5 increment button/number for NQ items
    [FieldOffset(0x7E0)] public AtkComponentButton* Ingredient5QuantityIncrementButtonHq; // Ingredient 5 increment button/number for HQ items
    [FieldOffset(0x818)] public AtkComponentNode* IngredientRow6; // Parent container for all sub-elements of Ingredient Row 6
    [FieldOffset(0x828)] public AtkTextNode* Ingredient6Name; // Ingredient 6 Name [ex: "Carrot of Happiness"]
    [FieldOffset(0x830)] public AtkTextNode* Ingredient6QuantityRequiredForCraft; // Ingredient 6 Required Quantity [ex: "1"]
    [FieldOffset(0x850)] public AtkTextNode* Ingredient6QuantityInInventoryNq; // Ingredient 6 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x858)] public AtkTextNode* Ingredient6QuantityInInventoryHq; // Ingredient 6 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x868)] public AtkComponentButton* Ingredient6QuantityIncrementButtonNq; // Ingredient 6 increment button/number for NQ items
    [FieldOffset(0x870)] public AtkComponentButton* Ingredient6QuantityIncrementButtonHq; // Ingredient 6 increment button/number for HQ items
}
