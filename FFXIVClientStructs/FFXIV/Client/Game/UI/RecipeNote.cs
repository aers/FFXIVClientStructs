using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RecipeNote
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? B9 ?? ?? ?? ?? 48 89 AB"
[StructLayout(LayoutKind.Explicit, Size = 0xB18)]
public unsafe partial struct RecipeNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 81 FE ?? ?? ?? ?? 75 0F", 3)]
    public static partial RecipeNote* Instance();

    [FieldOffset(0x00)] public fixed uint Jobs[8];  // CraftType -> ClassJob

    [FieldOffset(0xB8)] public RecipeData* RecipeList;

    [StructLayout(LayoutKind.Explicit, Size = 0x3D0)]
    public struct RecipeData {
        [FieldOffset(0x000)] public RecipeEntry* Recipes;
        [FieldOffset(0x3B8)] public ushort SelectedIndex;
        public RecipeEntry* SelectedRecipe => Recipes + SelectedIndex;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public struct RecipeIngredient {
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public uint ItemId;
        [FieldOffset(0x7C)] public uint IconId;

        [FieldOffset(0x82)] public byte Amount;
        [FieldOffset(0x83)] public byte Flags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x02)]
    public struct RecipeCrystal {
        [FieldOffset(0x00)] public sbyte Id; // -1 if empty
        [FieldOffset(0x01)] public byte Amount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x500)]
    public unsafe partial struct RecipeEntry {
        [FixedSizeArray<RecipeIngredient>(8)]
        [FieldOffset(0x00)] public fixed byte Ingredients[8 * 0x88];
        [FixedSizeArray<RecipeCrystal>(2)]
        [FieldOffset(0x440)] public fixed byte Crystals[2 * 0x02];
        [FieldOffset(0x448)] public Utf8String ItemName;
        [FieldOffset(0x4B0)] public uint IconId;
        [FieldOffset(0x4B4)] public uint ItemId;
        [FieldOffset(0x4B8)] public uint StatusRequired;
        [FieldOffset(0x4BC)] public uint ItemRequired;

        [FieldOffset(0x4C2)] public ushort RecipeId;
        [FieldOffset(0x4C4)] public ushort Difficulty; // recipeLevelTable->Difficulty * recipe->DifficultyFactor / 100
        [FieldOffset(0x4C8)] public uint Quality;      // recipeLevelTable->Quality    * recipe->QualityFactor    / 100
        [FieldOffset(0x4CC)] public ushort Durability; // recipeLevelTable->Durability * recipe->DurabilityFactor / 100
        [FieldOffset(0x4CE)] public byte MaterialQualityFactor;

        [FieldOffset(0x4D0)] public ushort RequiredCraftsmanship;
        [FieldOffset(0x4D2)] public ushort RequiredControl;
        [FieldOffset(0x4D4)] public ushort QuickSynthCraftsmanship;
        [FieldOffset(0x4D6)] public ushort QuickSynthControl;
        [FieldOffset(0x4D8)] public ushort SecretRecipeBook;

        [FieldOffset(0x4DC)] public uint RequiredQuality;
        [FieldOffset(0x4E0)] public ushort SuggestedCraftsmanship;
        [FieldOffset(0x4E2)] public ushort ConditionsFlag;

        [FieldOffset(0x4E6)] public byte AmountResult;
        [FieldOffset(0x4E7)] public byte CraftType;
        [FieldOffset(0x4E8)] public byte ClassJobLevel;

        [FieldOffset(0x4EA)] public byte Stars;

        [FieldOffset(0x4EE)] public byte Flags;
        [FieldOffset(0x4EF)] public byte Flags2;
        [FieldOffset(0x4F0)] public uint Number;
        [FieldOffset(0x4F4)] public ushort RecipeLevelTableId;
        [FieldOffset(0x4F6)] public ushort PatchNumber;
    }

    [MemberFunction("4C 8B 81 ?? ?? ?? ?? 44 8B D2")]
    public partial bool IsRecipeUnlocked(ushort recipeId);

    [MemberFunction("40 53 48 83 EC 20 83 FA 07")]
    public partial ushort GetCraftTypeLevel(byte craftType);
}
