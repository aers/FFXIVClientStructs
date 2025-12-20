using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CatalogSearchBookmarkModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct CatalogSearchBookmarkModule {
    public static CatalogSearchBookmarkModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetCatalogSearchBookmarkModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray16<uint> _wishlistItemIds;
    [FieldOffset(0x1D8)] public int WishlistItemCount;

    [MemberFunction("44 8B 81 ?? ?? ?? ?? 44 8B CA")]
    public partial bool AddToWishlist(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 89 AF ?? ?? ?? ?? EB")]
    public partial void RemoveFromWishlist(uint itemId);
}
