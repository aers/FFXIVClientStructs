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

    [FieldOffset(0x250)] public AtkImageNode* CurrentJobImage;

    /// <summary>
    /// Sibling container to scrollable list of recipes and parent container to recipe characteristics text panel
    /// </summary>
    [FieldOffset(0x268)] public AtkResNode* RecipeListAndCharacteristicsPanelContainer;

    [FieldOffset(0x278), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _tabButtons;
    [FieldOffset(0x2E8), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkImageNode>> _tabButtonImages;
    [FieldOffset(0x330)] public AtkComponentButton* TrialSynthesisButton;
    [FieldOffset(0x338)] public AtkComponentButton* QuickSynthesisButton;
    [FieldOffset(0x340)] public AtkComponentButton* SynthesizeButton;
    [FieldOffset(0x348)] public AtkComponentButton* PreviousCategoryButton;
    [FieldOffset(0x350)] public AtkComponentButton* NextCategoryButton;
    [FieldOffset(0x358)] public AtkComponentButton* PreviousPageButton;
    [FieldOffset(0x360)] public AtkComponentButton* NextPageButton;
    [FieldOffset(0x368)] public AtkComponentButton* RecipeFilterButton;
    [FieldOffset(0x370)] public AtkImageNode* RecipeFilterButtonImage;
    [FieldOffset(0x378)] public AtkTextNode* PaginationText; // Pagination Text [ex: "1-32"]
    [FieldOffset(0x380), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentBase>> _characteristicsComponents;
    [FieldOffset(0x3A8), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkTextNode>> _characteristicsTexts;
    [FieldOffset(0x3D0)] public AtkTextNode* SearchHintText;

    [FieldOffset(0x3E0)] public AtkTextNode* RecipeLevelLiteral; // Recipe Level Literal [ex: "Recipe Level"]

    [FieldOffset(0x448)] public AtkComponentTreeList* RecipeList;
    [FieldOffset(0x468)] public AtkComponentDropDownList* CategoryDropDown;
    [FieldOffset(0x478)] public AtkComponentButton* SelectedRecipeIconButton;
    [FieldOffset(0x480)] public AtkComponentIcon* SelectedRecipeIcon;
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
    [FieldOffset(0x4F0)] public AtkComponentButton* NqFillButton;
    [FieldOffset(0x4F8)] public AtkComponentButton* HqFillButton;
    [FieldOffset(0x500), FixedSizeArray] internal FixedSizeArray2<CrystalNodes> _crystals;
    [FieldOffset(0x540), FixedSizeArray] internal FixedSizeArray6<IngredientNodes> _ingredients;

    [FieldOffset(0x908)] public AtkComponentTextInput* SearchTextInput;

    [FieldOffset(0x3A8), Obsolete("Use CharacteristicsTexts[0}")] public AtkTextNode* CharacteristicsTextLine1; // Characteristics Line 1 [ex: "Quick Synthesis Unavailable"]
    [FieldOffset(0x3B0), Obsolete("Use CharacteristicsTexts[1}")] public AtkTextNode* CharacteristicsTextLine2; // Characteristics Line 2 [ex: "Craftsmanship Required: 3700"]
    [FieldOffset(0x3B8), Obsolete("Use CharacteristicsTexts[2}")] public AtkTextNode* CharacteristicsTextLine3; // Characteristics Line 3 [ex: "Quality Required for Synthesis: 13500"]
    [FieldOffset(0x3C0), Obsolete("Use CharacteristicsTexts[3}")] public AtkTextNode* CharacteristicsTextLine4; // Characteristics Line 4 [ex: "Expert Recipe"]
    [FieldOffset(0x3C8), Obsolete("Use CharacteristicsTexts[4}")] public AtkTextNode* CharacteristicsTextLine5; // Characteristics Line 5 [ex: "High-quality Uncraftable"]
    [FieldOffset(0x510), Obsolete("Use Crystals[0].QuantityRequiredForCraft")] public AtkTextNode* AetherCrystal1QuantityRequiredForCraft; // Left Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x518), Obsolete("Use Crystals[0].QuantityInInventory")] public AtkTextNode* AetherCrystal1QuantityInInventory; // Left Side Aether Shard / Crystals / Clusters in Inventory [ex: "6328"]
    [FieldOffset(0x530), Obsolete("Use Crystals[1].QuantityRequiredForCraft")] public AtkTextNode* AetherCrystal2QuantityRequiredForCraft; // Right Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x538), Obsolete("Use Crystals[1].QuantityInInventory")] public AtkTextNode* AetherCrystal2QuantityInInventory; // Right Side Aether Shard / Crystals / Clusters in Inventory [ex: "9999"]
    [FieldOffset(0x558), Obsolete("Use Ingredients[0].Name")] public AtkTextNode* Ingredient1Name; // Ingredient 1 Name [ex: "Hamsa Tenderloin"]
    [FieldOffset(0x560), Obsolete("Use Ingredients[0].QuantityRequiredForCraft")] public AtkTextNode* Ingredient1QuantityRequiredForCraft; // Ingredient 1 Required Quantity [ex: "1"]
    [FieldOffset(0x580), Obsolete("Use Ingredients[0].QuantityInInventoryNq")] public AtkTextNode* Ingredient1QuantityInInventoryNq; // Ingredient 1 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x588), Obsolete("Use Ingredients[0].QuantityInInventoryHq")] public AtkTextNode* Ingredient1QuantityInInventoryHq; // Ingredient 1 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x5E8), Obsolete("Use Ingredients[1].Name")] public AtkTextNode* Ingredient2Name; // Ingredient 2 Name [ex: "Coconut Milk"]
    [FieldOffset(0x5F0), Obsolete("Use Ingredients[1].QuantityRequiredForCraft")] public AtkTextNode* Ingredient2QuantityRequiredForCraft; // Ingredient 2 Required Quantity [ex: "1"]
    [FieldOffset(0x610), Obsolete("Use Ingredients[1].QuantityInInventoryNq")] public AtkTextNode* Ingredient2QuantityInInventoryNq; // Ingredient 2 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x618), Obsolete("Use Ingredients[1].QuantityInInventoryHq")] public AtkTextNode* Ingredient2QuantityInInventoryHq; // Ingredient 2 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x678), Obsolete("Use Ingredients[2].Name")] public AtkTextNode* Ingredient3Name; // Ingredient 3 Name [ex: "Elder Nutmeg Seeds"]
    [FieldOffset(0x680), Obsolete("Use Ingredients[2].QuantityRequiredForCraft")] public AtkTextNode* Ingredient3QuantityRequiredForCraft; // Ingredient 3 Required Quantity [ex: "2"]
    [FieldOffset(0x6A0), Obsolete("Use Ingredients[2].QuantityInInventoryNq")] public AtkTextNode* Ingredient3QuantityInInventoryNq; // Ingredient 3 Available NQ in Inventory [ex: "2"]
    [FieldOffset(0x6A8), Obsolete("Use Ingredients[2].QuantityInInventoryHq")] public AtkTextNode* Ingredient3QuantityInInventoryHq; // Ingredient 3 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x708), Obsolete("Use Ingredients[3].Name")] public AtkTextNode* Ingredient4Name; // Ingredient 4 Name [ex: "Upland Wheat Flour"]
    [FieldOffset(0x710), Obsolete("Use Ingredients[3].QuantityRequiredForCraft")] public AtkTextNode* Ingredient4QuantityRequiredForCraft; // Ingredient 4 Required Quantity [ex: "1"]
    [FieldOffset(0x730), Obsolete("Use Ingredients[3].QuantityInInventoryNq")] public AtkTextNode* Ingredient4QuantityInInventoryNq; // Ingredient 4 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x738), Obsolete("Use Ingredients[3].QuantityInInventoryHq")] public AtkTextNode* Ingredient4QuantityInInventoryHq; // Ingredient 4 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x798), Obsolete("Use Ingredients[4].Name")] public AtkTextNode* Ingredient5Name; // Ingredient 5 Name [ex: "Fermented Butter"]
    [FieldOffset(0x7A0), Obsolete("Use Ingredients[4].QuantityRequiredForCraft")] public AtkTextNode* Ingredient5QuantityRequiredForCraft; // Ingredient 5 Required Quantity [ex: "1"]
    [FieldOffset(0x7C0), Obsolete("Use Ingredients[4].QuantityInInventoryNq")] public AtkTextNode* Ingredient5QuantityInInventoryNq; // Ingredient 5 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x7C8), Obsolete("Use Ingredients[4].QuantityInInventoryHq")] public AtkTextNode* Ingredient5QuantityInInventoryHq; // Ingredient 5 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x828), Obsolete("Use Ingredients[5].Name")] public AtkTextNode* Ingredient6Name; // Ingredient 6 Name [ex: "Carrot of Happiness"]
    [FieldOffset(0x830), Obsolete("Use Ingredients[5].QuantityRequiredForCraft")] public AtkTextNode* Ingredient6QuantityRequiredForCraft; // Ingredient 6 Required Quantity [ex: "1"]
    [FieldOffset(0x850), Obsolete("Use Ingredients[5].QuantityInInventoryNq")] public AtkTextNode* Ingredient6QuantityInInventoryNq; // Ingredient 6 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x858), Obsolete("Use Ingredients[5].QuantityInInventoryHq")] public AtkTextNode* Ingredient6QuantityInInventoryHq; // Ingredient 6 Available HQ in Inventory [ex: "0"]

    // Aether Shard / Crystals / Clusters
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CrystalNodes {
        [FieldOffset(0x00)] public AtkComponentButton* Button;
        [FieldOffset(0x08)] public AtkImageNode* Image;
        [FieldOffset(0x10)] public AtkTextNode* QuantityRequiredForCraft;
        [FieldOffset(0x18)] public AtkTextNode* QuantityInInventory;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public struct IngredientNodes {
        [FieldOffset(0x00)] public AtkComponentBase* Component;
        [FieldOffset(0x08)] public AtkComponentNode* ComponentNode;
        [FieldOffset(0x10)] public AtkResNode* NameContainer;
        [FieldOffset(0x18)] public AtkTextNode* Name;
        [FieldOffset(0x20)] public AtkTextNode* QuantityRequiredForCraft;
        [FieldOffset(0x28)] public AtkComponentButton* IconButton;
        [FieldOffset(0x30)] public AtkComponentIcon* Icon;
        [FieldOffset(0x38)] public AtkResNode* InitialQualityBoostIconContainer;
        [FieldOffset(0x40)] public AtkTextNode* QuantityInInventoryNq;
        [FieldOffset(0x48)] public AtkTextNode* QuantityInInventoryHq;
        [FieldOffset(0x50)] public AtkTextNode* QuantityUnselectedText;
        [FieldOffset(0x58)] public AtkComponentButton* QuantityIncrementButtonNq;
        [FieldOffset(0x60)] public AtkComponentButton* QuantityIncrementButtonHq;
        [FieldOffset(0x70)] public AtkTextNode* QuantityIncrementButtonNqText;
        [FieldOffset(0x78)] public AtkTextNode* QuantityIncrementButtonHqText;
    }
}
