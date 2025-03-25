using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RecipeFavoriteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct RecipeFavoriteModule {
    public static RecipeFavoriteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRecipeFavoriteModule();
    }

    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray8<CraftingTypeEntry> _craftingTypes;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct CraftingTypeEntry {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray10<RecipeEntry> _recipes;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public partial struct RecipeEntry {
        [FieldOffset(0)] public ushort RecipeId;
        [FieldOffset(0x2)] public bool IsFavorite;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 B9 ?? ?? ?? ?? 0F 45 F9")]
    public partial RecipeEntry* GetEntry(byte craftType, ushort recipeId);

    [MemberFunction("E8 ?? ?? ?? ?? C6 44 24 ?? ?? 41 B9 ?? ?? ?? ?? C6 44 24")]
    public partial bool IsFavorited(byte craftType, ushort recipeId);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 4C 24 ?? 48 8B 74 24 ??")]
    public partial uint RemoveFromFavorites(byte craftType, ushort recipeId); // returns LogMessage RowId

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 49 8B CE 49 8B 06")]
    public partial uint AddToFavorites(byte craftType, ushort recipeId); // returns LogMessage RowId
}
