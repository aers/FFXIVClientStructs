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
    // ActiveCraft Ingredients info, structure with unions, dunno
    // ActiveCraft Crystals info, something from 0x2F8?
    [FieldOffset(0x110)] public uint ActiveCraftStatusRequired;
    [FieldOffset(0x114)] public uint ActiveCraftItemRequired;
    [FieldOffset(0x118)] public ushort ActiveCraftRecipeId;
    [FieldOffset(0x11A)] public ushort ActiveCraftRequiredCraftsmanship;
    [FieldOffset(0x11C)] public ushort ActiveCraftRequiredControl;
    [FieldOffset(0x11E)] public ushort ActiveCraftQuickSynthCraftsmanship;
    [FieldOffset(0x120)] public ushort ActiveCraftQuickSynthControl;
    [FieldOffset(0x122)] public ushort ActiveCraftSecretRecipeBook;
    [FieldOffset(0x124)] public byte ActiveCraftCrystals0Amount;
    [FieldOffset(0x125)] public byte ActiveCraftCrystals1Amount;
    [FieldOffset(0x126)] public byte ActiveCraftCraftType;

    [FieldOffset(0x12A)] public uint ActiveCraftRequiresMeisterSoulCrystal;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x460)]
    public partial struct RecipeData {
        // E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 33 FF 48 85 C9 74 0C E8 ?? ?? ?? ?? 48 89 BE ?? ?? ?? ?? 48 8B 86 ?? ?? ?? ?? 48 89 5C 24   (7.1)
        [FieldOffset(0x00)] public RecipeEntry* Recipes;
        [FieldOffset(0x08)] public int RecipeCount;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray8<NoteBookDivisionIdsArray> _noteBookDivisionIds; // index is CraftType
        [FieldOffset(0x448)] public ushort SelectedIndex;
        [FieldOffset(0x44F), FixedSizeArray] internal FixedSizeArray8<byte> _numAvailableNoteBookDivisions; // index is CraftType
        [FieldOffset(0x457), FixedSizeArray] internal FixedSizeArray8<byte> _numAvailableSecretNoteBookDivisions; // index is CraftType
        public RecipeEntry* SelectedRecipe => Recipes + SelectedIndex;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 66 * 2)]
    public partial struct NoteBookDivisionIdsArray {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray66<ushort> _noteBookDivisionIds;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public struct RecipeIngredient {
        [FieldOffset(0x08)] public byte NQCount;
        [FieldOffset(0x09)] public byte HQCount;

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
        [FieldOffset(0x3B0)] public bool RequiresMeisterSoulCrystal;

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
        [FieldOffset(0x3F0)] public ushort DisplayPriority;
        [FieldOffset(0x3F2)] public ushort MaxAdjustableJobLevel;
        [FieldOffset(0x3F4)] public ushort DifficultyFactor;
        [FieldOffset(0x3F6)] public ushort QualityFactor;
        [FieldOffset(0x3F8)] public ushort DurabilityFactor;
    }

    [MemberFunction("48 89 4C 24 ?? 53 55 56 57 41 54 41 55 41 56 41 57 48 83 EC ?? 48 8B E9 E8 ?? ?? ?? ?? 45 33 C0")]
    public partial void InitializeRecipeList();

    [MemberFunction("4C 8B 81 ?? ?? ?? ?? 4D 85 C0 74 ?? ?? ?? ?? 4D 85 C9")]
    public partial bool IsRecipeUnlocked(ushort recipeId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 F8 6B 83")]
    public partial ushort GetCraftTypeLevel(byte craftType);

    [MemberFunction("E8 ?? ?? ?? ?? 48 63 76")]
    public partial uint GetNoteBookDivisionIdByRecipe([CExporterExcel("Recipe")] void* recipeRow);
}
