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
