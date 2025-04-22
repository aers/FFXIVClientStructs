using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RecipeNote
// ctor "E8 ?? ?? ?? ?? BD ?? ?? ?? ?? 4C 89 A6"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB40)]
public unsafe partial struct RecipeNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 8B D6 85 FF", 3)]
    public static partial RecipeNote* Instance();

    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8<uint> _jobs;  // CraftType -> ClassJob

    [FieldOffset(0xB8)] public RecipeData* RecipeList;

    [StructLayout(LayoutKind.Explicit, Size = 0x450)]
    public struct RecipeData {
        // E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 33 FF 48 85 C9 74 0C E8 ?? ?? ?? ?? 48 89 BE ?? ?? ?? ?? 48 8B 86 ?? ?? ?? ?? 48 89 5C 24   (7.1)
        [FieldOffset(0x00)] public RecipeEntry* Recipes;
        [FieldOffset(0x08)] public int RecipeCount;
        [FieldOffset(0x438)] public ushort SelectedIndex;
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

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x400)]
    public unsafe partial struct RecipeEntry {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray6<RecipeIngredient> _ingredients;
        [FieldOffset(0x330), FixedSizeArray] internal FixedSizeArray2<RecipeCrystal> _crystals;
        [FieldOffset(0x338)] public Utf8String ItemName;
        [FieldOffset(0x3A0)] public uint IconId;
        [FieldOffset(0x3A4)] public uint ItemId;
        [FieldOffset(0x3A8)] public uint StatusRequired;
        [FieldOffset(0x3AC)] public uint ItemRequired;

        [FieldOffset(0x3B2)] public ushort RecipeId;
        [FieldOffset(0x3B4)] public ushort Difficulty; // recipeLevelTable->Difficulty * recipe->DifficultyFactor / 100
        [FieldOffset(0x3B8)] public uint Quality;      // recipeLevelTable->Quality    * recipe->QualityFactor    / 100
        [FieldOffset(0x3BC)] public ushort Durability; // recipeLevelTable->Durability * recipe->DurabilityFactor / 100
        [FieldOffset(0x3BE)] public byte MaterialQualityFactor;

        [FieldOffset(0x3C0)] public ushort RequiredCraftsmanship;
        [FieldOffset(0x3C2)] public ushort RequiredControl;
        [FieldOffset(0x3C4)] public ushort QuickSynthCraftsmanship;
        [FieldOffset(0x3C6)] public ushort QuickSynthControl;
        [FieldOffset(0x3C8)] public ushort SecretRecipeBook;

        [FieldOffset(0x3CC)] public uint RequiredQuality;
        [FieldOffset(0x3D0)] public ushort SuggestedCraftsmanship;
        [FieldOffset(0x3D2)] public ushort ConditionsFlag;

        [FieldOffset(0x3D6)] public byte AmountResult;
        [FieldOffset(0x3D7)] public byte CraftType;
        [FieldOffset(0x3D8)] public byte ClassJobLevel;

        [FieldOffset(0x3DA)] public byte Stars;

        [FieldOffset(0x3DE)] public byte Flags;
        [FieldOffset(0x3DF)] public byte Flags2;
        [FieldOffset(0x3E0)] public uint Number;
        [FieldOffset(0x3E4)] public ushort RecipeLevelTableId;
        [FieldOffset(0x3E6)] public ushort PatchNumber;
    }

    [MemberFunction("4C 8B 81 ?? ?? ?? ?? 4D 85 C0 74 2E")]
    public partial bool IsRecipeUnlocked(ushort recipeId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 F8 6B 83")]
    public partial ushort GetCraftTypeLevel(byte craftType);
}
