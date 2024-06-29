using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRecipeNote
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RecipeNote")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3BA8)]
public unsafe partial struct AddonRecipeNote {
    [FieldOffset(0x230)] public AtkTextNode* CurrentJobLevel; // Job Level String [ex: "Level 90"]
    [FieldOffset(0x238)] public AtkTextNode* CurrentJobName; // Job Name String [ex: "Carpenter"]
    [FieldOffset(0x328)] public AtkComponentButton* TrialSynthesisButton;
    [FieldOffset(0x330)] public AtkComponentButton* QuickSynthesisButton;
    [FieldOffset(0x338)] public AtkComponentButton* SynthesizeButton;
    [FieldOffset(0x370)] public AtkTextNode* PaginationText; // Pagination Text [ex: "1-32"]
    [FieldOffset(0x3A0)] public AtkTextNode* CharacteristicsTextLine1; // Characteristics Line 1 [ex: "Quick Synthesis Unavailable"]
    [FieldOffset(0x3A8)] public AtkTextNode* CharacteristicsTextLine2; // Characteristics Line 2 [ex: "Craftsmanship Required: 3700"]
    [FieldOffset(0x3B0)] public AtkTextNode* CharacteristicsTextLine3; // Characteristics Line 3 [ex: "Quality Required for Synthesis: 13500"]
    [FieldOffset(0x3B8)] public AtkTextNode* CharacteristicsTextLine4; // Characteristics Line 4 [ex: "Expert Recipe"]
    [FieldOffset(0x3C0)] public AtkTextNode* CharacteristicsTextLine5; // Characteristics Line 5 [ex: "High-quality Uncraftable"]
    [FieldOffset(0x3D8)] public AtkTextNode* RecipeLevelLiteral; // Recipe Level Literal [ex: "Recipe Level"]
    [FieldOffset(0x480)] public AtkTextNode* SelectedRecipeName; // Selected Recipe Name [ex: "Water Otter Fountain Lumber"]
    [FieldOffset(0x488)] public AtkTextNode* SelectedRecipeDurability; // Durability [ex: "60"]
    [FieldOffset(0x490)] public AtkTextNode* SelectedRecipeDifficulty; // Difficulty [ex: "7480"]
    [FieldOffset(0x498)] public AtkTextNode* SelectedRecipeStartingQuality; // Starting Quality [ex: "0"]
    [FieldOffset(0x4A0)] public AtkTextNode* SelectedRecipeMaximumQuality; // Maximum Quality [ex: "13620"]
    [FieldOffset(0x4A8)] public AtkTextNode* SelectedRecipeHighestStartingQuality; // Max Starting Quality [ex: "(Max 50%)"]
    [FieldOffset(0x4B0)] public AtkTextNode* BagLiteral; // Bag Literal [ex: "Bag"]
    /// <summary>
    /// Inventory NQ/HQ Recipe Result Count [ex: "0\n\ue03c0", "\ue03c" being the HQ symbol]
    /// The HQ value is not present on items that cannot be HQ [ex: "0"]
    /// </summary>
    [FieldOffset(0x4B8)] public AtkTextNode* SelectedRecipeResultQuantityInInventoryNqAndHq;
    [FieldOffset(0x4C0)] public AtkTextNode* CraftableLiteral; // Craftable Literal [ex: "Craftable"]
    [FieldOffset(0x4C8)] public AtkTextNode* SelectedRecipeQuantityCraftableFromMaterialsInInventory; // Quantity Craftable from Inventory [ex: "10"]
    [FieldOffset(0x4D8)] public AtkTextNode* ProgressCalculationSentence; // Progress calculation sentence [ex: "At 100% efficiency, progress increases by 244."]
    [FieldOffset(0x4E0)] public AtkTextNode* QualityCalculationSentence; // Quality calculation sentence [ex: "At 100% efficiency, quality increases by 247."]
    [FieldOffset(0x4F8)] public AtkTextNode* AetherCrystal1QuantityRequiredForCraft; // Left Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x500)] public AtkTextNode* AetherCrystal1QuantityInInventory; // Left Side Aether Shard / Crystals / Clusters in Inventory [ex: "6328"]
    [FieldOffset(0x518)] public AtkTextNode* AetherCrystal2QuantityRequiredForCraft; // Right Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x520)] public AtkTextNode* AetherCrystal2QuantityInInventory; // Right Side Aether Shard / Crystals / Clusters in Inventory [ex: "9999"]
    [FieldOffset(0x540)] public AtkTextNode* Ingredient1Name; // Ingredient 1 Name [ex: "Hamsa Tenderloin"]
    [FieldOffset(0x548)] public AtkTextNode* Ingredient1QuantityRequiredForCraft; // Ingredient 1 Required Quantity [ex: "1"]
    [FieldOffset(0x568)] public AtkTextNode* Ingredient1QuantityInInventoryNq; // Ingredient 1 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x570)] public AtkTextNode* Ingredient1QuantityInInventoryHq; // Ingredient 1 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x5B8)] public AtkTextNode* Ingredient2Name; // Ingredient 2 Name [ex: "Coconut Milk"]
    [FieldOffset(0x5C0)] public AtkTextNode* Ingredient2QuantityRequiredForCraft; // Ingredient 2 Required Quantity [ex: "1"]
    [FieldOffset(0x5E0)] public AtkTextNode* Ingredient2QuantityInInventoryNq; // Ingredient 2 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x5E8)] public AtkTextNode* Ingredient2QuantityInInventoryHq; // Ingredient 2 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x630)] public AtkTextNode* Ingredient3Name; // Ingredient 3 Name [ex: "Elder Nutmeg Seeds"]
    [FieldOffset(0x638)] public AtkTextNode* Ingredient3QuantityRequiredForCraft; // Ingredient 3 Required Quantity [ex: "2"]
    [FieldOffset(0x658)] public AtkTextNode* Ingredient3QuantityInInventoryNq; // Ingredient 3 Available NQ in Inventory [ex: "2"]
    [FieldOffset(0x660)] public AtkTextNode* Ingredient3QuantityInInventoryHq; // Ingredient 3 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x6A8)] public AtkTextNode* Ingredient4Name; // Ingredient 4 Name [ex: "Upland Wheat Flour"]
    [FieldOffset(0x6B0)] public AtkTextNode* Ingredient4QuantityRequiredForCraft; // Ingredient 4 Required Quantity [ex: "1"]
    [FieldOffset(0x6D0)] public AtkTextNode* Ingredient4QuantityInInventoryNq; // Ingredient 4 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x6D8)] public AtkTextNode* Ingredient4QuantityInInventoryHq; // Ingredient 4 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x720)] public AtkTextNode* Ingredient5Name; // Ingredient 5 Name [ex: "Fermented Butter"]
    [FieldOffset(0x728)] public AtkTextNode* Ingredient5QuantityRequiredForCraft; // Ingredient 5 Required Quantity [ex: "1"]
    [FieldOffset(0x748)] public AtkTextNode* Ingredient5QuantityInInventoryNq; // Ingredient 5 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x750)] public AtkTextNode* Ingredient5QuantityInInventoryHq; // Ingredient 5 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x798)] public AtkTextNode* Ingredient6Name; // Ingredient 6 Name [ex: "Carrot of Happiness"]
    [FieldOffset(0x7A0)] public AtkTextNode* Ingredient6QuantityRequiredForCraft; // Ingredient 6 Required Quantity [ex: "1"]
    [FieldOffset(0x7C0)] public AtkTextNode* Ingredient6QuantityInInventoryNq; // Ingredient 6 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x7C8)] public AtkTextNode* Ingredient6QuantityInInventoryHq; // Ingredient 6 Available HQ in Inventory [ex: "0"]
}
