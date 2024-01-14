using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RecipeFavoriteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8"
[StructLayout(LayoutKind.Explicit, Size = 0x188)]
public unsafe partial struct RecipeFavoriteModule {
    public static RecipeFavoriteModule* Instance() => Framework.Instance()->GetUiModule()->GetRecipeFavoriteModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;

    [FixedSizeArray<CraftingTypeEntry>(8)]
    [FieldOffset(0x42)] public fixed byte CraftingTypes[8 * 10 * 0x4];

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct CraftingTypeEntry {
        [FixedSizeArray<RecipeEntry>(10)]
        [FieldOffset(0)] public fixed byte Recipes[10 * 0x4];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public partial struct RecipeEntry {
        [FieldOffset(0)] public ushort RecipeId;
        [FieldOffset(0x2)] public bool IsFavorite;
    }

    [MemberFunction("48 63 C2 45 0F B7 C8")]
    public partial RecipeEntry* GetEntry(byte craftType, ushort recipeID);

    [MemberFunction("85 D2 78 32 48 63 C2")]
    public partial bool IsFavorited(byte craftType, ushort recipeID);

    [MemberFunction("E8 ?? ?? ?? ?? 8B CD 48 8B C5")]
    public partial uint RemoveFromFavorites(byte craftType, ushort recipeID); // returns LogMessage RowId

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 49 8B CE")]
    public partial uint AddToFavorites(byte craftType, ushort recipeID); // returns LogMessage RowId
}
