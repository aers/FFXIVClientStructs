using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRecipeNote
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RecipeNote")]
[StructLayout(LayoutKind.Explicit, Size = 0x3B90)]
public unsafe struct AddonRecipeNote {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* CurrentJobLevel; // Job Level String [ex: "Level 90"]
    [FieldOffset(0x228)] public AtkTextNode* CurrentJobName; // Job Name String [ex: "Carpenter"]
    [FieldOffset(0x230)] public AtkTextNode* Unk230;
    [FieldOffset(0x238)] public AtkImageNode* Unk238;
    [FieldOffset(0x248)] public AtkResNode* Unk248;
    [FieldOffset(0x250)] public AtkResNode* Unk250;
    [FieldOffset(0x258)] public AtkResNode* Unk258;
    [FieldOffset(0x260)] public AtkComponentRadioButton* Unk260;
    [FieldOffset(0x268)] public AtkComponentRadioButton* Unk268;
    [FieldOffset(0x270)] public AtkComponentRadioButton* Unk270;
    [FieldOffset(0x278)] public AtkComponentRadioButton* Unk278;
    [FieldOffset(0x280)] public AtkComponentRadioButton* Unk280;
    [FieldOffset(0x288)] public AtkComponentRadioButton* Unk288;
    [FieldOffset(0x290)] public AtkComponentRadioButton* Unk290;
    [FieldOffset(0x298)] public AtkComponentRadioButton* Unk298;
    [FieldOffset(0x2A0)] public AtkComponentRadioButton* Unk2A0;
    [FieldOffset(0x2D0)] public AtkImageNode* Unk2D0;
    [FieldOffset(0x2D8)] public AtkImageNode* Unk2D8;
    [FieldOffset(0x2E0)] public AtkImageNode* Unk2E0;
    [FieldOffset(0x2E8)] public AtkImageNode* Unk2E8;
    [FieldOffset(0x2F0)] public AtkImageNode* Unk2F0;
    [FieldOffset(0x2F8)] public AtkImageNode* Unk2F8;
    [FieldOffset(0x300)] public AtkImageNode* Unk300;
    [FieldOffset(0x308)] public AtkImageNode* Unk308;
    [FieldOffset(0x310)] public AtkImageNode* Unk310;
    [FieldOffset(0x318)] public AtkComponentButton* TrialSynthesisButton;
    [FieldOffset(0x320)] public AtkComponentButton* QuickSynthesisButton;
    [FieldOffset(0x328)] public AtkComponentButton* SynthesizeButton;
    [FieldOffset(0x330)] public AtkComponentButton* Unk330;
    [FieldOffset(0x338)] public AtkComponentButton* Unk338;
    [FieldOffset(0x340)] public AtkComponentButton* Unk340;
    [FieldOffset(0x348)] public AtkComponentButton* Unk348;
    [FieldOffset(0x350)] public AtkComponentButton* Unk350;
    [FieldOffset(0x358)] public AtkResNode* Unk358;
    [FieldOffset(0x360)] public AtkTextNode* PaginationText; // Pagination Text [ex: "1-32"]
    [FieldOffset(0x368)] public AtkComponentBase* Unk368;
    [FieldOffset(0x370)] public AtkComponentBase* Unk370;
    [FieldOffset(0x378)] public AtkComponentBase* Unk378;
    [FieldOffset(0x380)] public AtkComponentBase* Unk380;
    [FieldOffset(0x388)] public AtkComponentBase* Unk388;
    [FieldOffset(0x390)] public AtkTextNode* CharacteristicsTextLine1; // Characteristics Line 1 [ex: "Quick Synthesis Unavailable"]
    [FieldOffset(0x398)] public AtkTextNode* CharacteristicsTextLine2; // Characteristics Line 2 [ex: "Craftsmanship Required: 3700"]
    [FieldOffset(0x3A0)] public AtkTextNode* CharacteristicsTextLine3; // Characteristics Line 3 [ex: "Quality Required for Synthesis: 13500"]
    [FieldOffset(0x3A8)] public AtkTextNode* CharacteristicsTextLine4; // Characteristics Line 4 [ex: "Expert Recipe"]
    [FieldOffset(0x3B0)] public AtkTextNode* CharacteristicsTextLine5; // Characteristics Line 5 [ex: "High-quality Uncraftable"]
    [FieldOffset(0x3B8)] public AtkTextNode* Unk3B8;
    [FieldOffset(0x3C0)] public AtkResNode* Unk3C0;
    [FieldOffset(0x3C8)] public AtkTextNode* RecipeLevelLiteral; // Recipe Level Literal [ex: "Recipe Level"]
    [FieldOffset(0x3D0)] public AtkComponentButton* Unk3D0;
    [FieldOffset(0x3D8)] public AtkResNode* Unk3D8;
    [FieldOffset(0x3E0)] public AtkComponentButton* Unk3E0;
    [FieldOffset(0x3E8)] public AtkResNode* Unk3E8;
    [FieldOffset(0x3F0)] public AtkResNode* Unk3F0;
    [FieldOffset(0x3F8)] public void* Unk3F8; // AtkComponentList
    [FieldOffset(0x400)] public void* Unk400; // AtkComponentTreeList
    [FieldOffset(0x408)] public void* Unk408; // vtbl
    [FieldOffset(0x410)] public AddonRecipeNote* this410;
    [FieldOffset(0x418)] public void* Unk418; // func
    [FieldOffset(0x420)] public void* Unk420; // AtkComponentTreeList
    [FieldOffset(0x428)] public void* Unk428; // vtbl
    [FieldOffset(0x430)] public AddonRecipeNote* this430;
    [FieldOffset(0x438)] public void* Unk438; // func
    [FieldOffset(0x440)] public void* Unk440;
    [FieldOffset(0x448)] public void* Unk448;
    [FieldOffset(0x450)] public void* Unk450;
    [FieldOffset(0x458)] public void* Unk458;
    [FieldOffset(0x460)] public void* Unk460;
    [FieldOffset(0x468)] public void* Unk468;
    [FieldOffset(0x470)] public AtkTextNode* SelectedRecipeName; // Selected Recipe Name [ex: "Water Otter Fountain Lumber"]
    [FieldOffset(0x478)] public AtkTextNode* SelectedRecipeDurability; // Durability [ex: "60"]
    [FieldOffset(0x480)] public AtkTextNode* SelectedRecipeDifficulty; // Difficulty [ex: "7480"]
    [FieldOffset(0x488)] public AtkTextNode* SelectedRecipeStartingQuality; // Starting Quality [ex: "0"]
    [FieldOffset(0x490)] public AtkTextNode* SelectedRecipeMaximumQuality; // Maximum Quality [ex: "13620"]
    [FieldOffset(0x498)] public AtkTextNode* SelectedRecipeHighestStartingQuality; // Max Starting Quality [ex: "(Max 50%)"]
    [FieldOffset(0x4A0)] public AtkTextNode* BagLiteral; // Bag Literal [ex: "Bag"]
    /// <summary>
    /// Inventory NQ/HQ Recipe Result Count [ex: "0\n\ue03c0", "\ue03c" being the HQ symbol]
    /// The HQ value is not present on items that cannot be HQ [ex: "0"]
    /// </summary>
    [FieldOffset(0x4A8)] public AtkTextNode* SelectedRecipeResultQuantityInInventoryNqAndHq;
    [FieldOffset(0x4B0)] public AtkTextNode* CraftableLiteral; // Craftable Literal [ex: "Craftable"]
    [FieldOffset(0x4B8)] public AtkTextNode* SelectedRecipeQuantityCraftableFromMaterialsInInventory; // Quantity Craftable from Inventory [ex: "10"]
    [FieldOffset(0x4C0)] public void* Unk4C0;
    [FieldOffset(0x4C8)] public AtkTextNode* ProgressCalculationSentence; // Progress calculation sentence [ex: "At 100% efficiency, progress increases by 244."]
    [FieldOffset(0x4D0)] public AtkTextNode* QualityCalculationSentence; // Quality calculation sentence [ex: "At 100% efficiency, quality increases by 247."]
    [FieldOffset(0x4D8)] public void* Unk4D8;
    [FieldOffset(0x4E0)] public void* Unk4E0;
    [FieldOffset(0x4E8)] public AtkTextNode* AetherCrystal1QuantityRequiredForCraft; // Left Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x4F0)] public AtkTextNode* AetherCrystal1QuantityInInventory; // Left Side Aether Shard / Crystals / Clusters in Inventory [ex: "6328"]
    [FieldOffset(0x4F8)] public void* Unk4F8;
    [FieldOffset(0x500)] public void* Unk500;
    [FieldOffset(0x508)] public AtkTextNode* AetherCrystal2QuantityRequiredForCraft; // Right Side Crystal Requirement [ex: "3"]
    [FieldOffset(0x510)] public AtkTextNode* AetherCrystal2QuantityInInventory; // Right Side Aether Shard / Crystals / Clusters in Inventory [ex: "9999"]
    [FieldOffset(0x518)] public void* Unk518;
    [FieldOffset(0x520)] public void* Unk520;
    [FieldOffset(0x528)] public void* Unk528;
    [FieldOffset(0x530)] public AtkTextNode* Ingredient1Name; // Ingredient 1 Name [ex: "Hamsa Tenderloin"]
    [FieldOffset(0x538)] public AtkTextNode* Ingredient1QuantityRequiredForCraft; // Ingredient 1 Required Quantity [ex: "1"]
    [FieldOffset(0x540)] public void* Unk540;
    [FieldOffset(0x548)] public void* Unk548;
    [FieldOffset(0x550)] public void* Unk550;
    [FieldOffset(0x558)] public AtkTextNode* Ingredient1QuantityInInventoryNq; // Ingredient 1 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x560)] public AtkTextNode* Ingredient1QuantityInInventoryHq; // Ingredient 1 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x578)] public void* Unk578;
    [FieldOffset(0x580)] public void* Unk580;
    [FieldOffset(0x588)] public void* Unk588;
    [FieldOffset(0x590)] public void* Unk590;
    [FieldOffset(0x598)] public void* Unk598;
    [FieldOffset(0x5A0)] public void* Unk5A0;
    [FieldOffset(0x5A8)] public AtkTextNode* Ingredient2Name; // Ingredient 2 Name [ex: "Coconut Milk"]
    [FieldOffset(0x5B0)] public AtkTextNode* Ingredient2QuantityRequiredForCraft; // Ingredient 2 Required Quantity [ex: "1"]
    [FieldOffset(0x5B8)] public void* Unk5B8;
    [FieldOffset(0x5C0)] public void* Unk5C0;
    [FieldOffset(0x5C8)] public void* Unk5C8;
    [FieldOffset(0x5D0)] public AtkTextNode* Ingredient2QuantityInInventoryNq; // Ingredient 2 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x5D8)] public AtkTextNode* Ingredient2QuantityInInventoryHq; // Ingredient 2 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x5E8)] public void* Unk5E8;
    [FieldOffset(0x5F0)] public void* Unk5F0;
    [FieldOffset(0x5F8)] public void* Unk5F8;
    [FieldOffset(0x600)] public void* Unk600;
    [FieldOffset(0x608)] public void* Unk608;
    [FieldOffset(0x610)] public void* Unk610;
    [FieldOffset(0x618)] public void* Unk618;
    [FieldOffset(0x620)] public AtkTextNode* Ingredient3Name; // Ingredient 3 Name [ex: "Elder Nutmeg Seeds"]
    [FieldOffset(0x628)] public AtkTextNode* Ingredient3QuantityRequiredForCraft; // Ingredient 3 Required Quantity [ex: "2"]
    [FieldOffset(0x630)] public void* Unk630;
    [FieldOffset(0x638)] public void* Unk638;
    [FieldOffset(0x640)] public void* Unk640;
    [FieldOffset(0x648)] public AtkTextNode* Ingredient3QuantityInInventoryNq; // Ingredient 3 Available NQ in Inventory [ex: "2"]
    [FieldOffset(0x650)] public AtkTextNode* Ingredient3QuantityInInventoryHq; // Ingredient 3 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x658)] public void* Unk658;
    [FieldOffset(0x660)] public void* Unk660;
    [FieldOffset(0x668)] public void* Unk668;
    [FieldOffset(0x670)] public void* Unk670;
    [FieldOffset(0x678)] public void* Unk678;
    [FieldOffset(0x680)] public void* Unk680;
    [FieldOffset(0x688)] public void* Unk688;
    [FieldOffset(0x690)] public void* Unk690;
    [FieldOffset(0x698)] public AtkTextNode* Ingredient4Name; // Ingredient 4 Name [ex: "Upland Wheat Flour"]
    [FieldOffset(0x6A0)] public AtkTextNode* Ingredient4QuantityRequiredForCraft; // Ingredient 4 Required Quantity [ex: "1"]
    [FieldOffset(0x6A8)] public void* Unk6A8;
    [FieldOffset(0x6B0)] public void* Unk6B0;
    [FieldOffset(0x6C0)] public AtkTextNode* Ingredient4QuantityInInventoryNq; // Ingredient 4 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x6C8)] public AtkTextNode* Ingredient4QuantityInInventoryHq; // Ingredient 4 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x6D0)] public void* Unk6D0;
    [FieldOffset(0x6D8)] public void* Unk6D8;
    [FieldOffset(0x6E0)] public void* Unk6E0;
    [FieldOffset(0x6E8)] public void* Unk6E8;
    [FieldOffset(0x6F0)] public void* Unk6F0;
    [FieldOffset(0x6F8)] public void* Unk6F8;
    [FieldOffset(0x700)] public void* Unk700;
    [FieldOffset(0x708)] public void* Unk708;
    [FieldOffset(0x710)] public AtkTextNode* Ingredient5Name; // Ingredient 5 Name [ex: "Fermented Butter"]
    [FieldOffset(0x718)] public AtkTextNode* Ingredient5QuantityRequiredForCraft; // Ingredient 5 Required Quantity [ex: "1"]
    [FieldOffset(0x720)] public void* Unk720;
    [FieldOffset(0x738)] public AtkTextNode* Ingredient5QuantityInInventoryNq; // Ingredient 5 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x740)] public AtkTextNode* Ingredient5QuantityInInventoryHq; // Ingredient 5 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x748)] public void* Unk748;
    [FieldOffset(0x750)] public void* Unk750;
    [FieldOffset(0x758)] public void* Unk758;
    [FieldOffset(0x760)] public void* Unk760;
    [FieldOffset(0x768)] public void* Unk768;
    [FieldOffset(0x770)] public void* Unk770;
    [FieldOffset(0x778)] public void* Unk778;
    [FieldOffset(0x780)] public void* Unk780;
    [FieldOffset(0x788)] public AtkTextNode* Ingredient6Name; // Ingredient 6 Name [ex: "Carrot of Happiness"]
    [FieldOffset(0x790)] public AtkTextNode* Ingredient6QuantityRequiredForCraft; // Ingredient 6 Required Quantity [ex: "1"]
    [FieldOffset(0x7A8)] public void* Unk7A8; // vtbl Component::GUI::AtkSimpleTween
    [FieldOffset(0x7B0)] public AtkTextNode* Ingredient6QuantityInInventoryNq; // Ingredient 6 Available NQ in Inventory [ex: "1"]
    [FieldOffset(0x7B8)] public AtkTextNode* Ingredient6QuantityInInventoryHq; // Ingredient 6 Available HQ in Inventory [ex: "0"]
    [FieldOffset(0x800)] public AddonRecipeNote* this800;
    [FieldOffset(0x808)] public AtkStage* Unk808;
    [FieldOffset(0x810)] public AtkComponentTextInput* Unk810;
    [FieldOffset(0x818)] public AddonRecipeNote* this818;

    [FieldOffset(0xB50)] public char* UnkB50; // TODO: change to byte*
    [FieldOffset(0xB60)] public char* UnkB60; // TODO: change to byte*
    [FieldOffset(0xB70)] public char* UnkB70; // TODO: change to byte*
    [FieldOffset(0xB80)] public char* UnkB80; // TODO: change to byte*
    [FieldOffset(0xB90)] public char* UnkB90; // TODO: change to byte*
    [FieldOffset(0xBA0)] public char* UnkBA0; // TODO: change to byte*
    [FieldOffset(0xBB0)] public char* UnkBB0; // TODO: change to byte*
    [FieldOffset(0xBC0)] public char* UnkBC0; // TODO: change to byte*
    [FieldOffset(0xBD0)] public char* UnkBD0; // TODO: change to byte*
    [FieldOffset(0xBE0)] public char* UnkBE0; // TODO: change to byte*
    [FieldOffset(0xBF0)] public char* UnkBF0; // TODO: change to byte*
    [FieldOffset(0xC00)] public char* UnkC00; // TODO: change to byte*
    [FieldOffset(0xC10)] public char* UnkC10; // TODO: change to byte*

    [FieldOffset(0x2138)] public char* Unk2138; // TODO: change to byte*
    [FieldOffset(0x2140)] public char* Unk2140; // TODO: change to byte*
    [FieldOffset(0x2148)] public char* Unk2148; // TODO: change to byte*
    [FieldOffset(0x2150)] public char* Unk2150; // TODO: change to byte*
    [FieldOffset(0x2158)] public char* Unk2158; // TODO: change to byte*
    [FieldOffset(0x2160)] public char* Unk2160; // TODO: change to byte*
    [FieldOffset(0x2168)] public char* Unk2168; // TODO: change to byte*
    [FieldOffset(0x2170)] public char* Unk2170; // TODO: change to byte*
    [FieldOffset(0x2178)] public char* Unk2178; // TODO: change to byte*
}
