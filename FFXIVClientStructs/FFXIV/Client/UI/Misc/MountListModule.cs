using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MountListModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 33 C0"
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct MountListModule {
    public static MountListModule* Instance() => Framework.Instance()->GetUiModule()->GetMountListModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    // [FieldOffset(0x40)] public byte Unk40; // set to 1 in ReadFile
    [FieldOffset(0x42)] public fixed ushort UnseenMounts[10]; // Order column of Mount sheet, offset by 1
    [FieldOffset(0x56)] public fixed ushort Favorites[30]; // Order column of Mount sheet, offset by 1
    // [FieldOffset(0x92)] public uint Unk92;

    [MemberFunction("48 83 EC 28 44 0F B7 DA")]
    public partial bool AddToUnseenMounts(ushort orderId);

    [MemberFunction("48 83 EC 28 32 C0")]
    public partial bool RemoveFromUnseenMounts(ushort orderId);

    [MemberFunction("48 83 EC 28 44 0F B7 D2 4C 8B C9 45 32 C0 66 90 41 0F B6 C0 66 83 7C 41 ?? ?? 74 10 41 FE C0 41 80 F8 1E 72 EB 33 C0 48 83 C4 28 C3 32 C9 45 0F B7 C2")]
    public partial bool AddToFavorites(ushort orderId);

    [MemberFunction("48 83 EC 28 45 32 C0 44 0F B7 CA")]
    public partial bool RemoveFromFavorites(ushort orderId);

    private Span<ushort> FavoritesSpan {
        get {
            fixed (ushort* ptr = &Favorites[0]) {
                return new Span<ushort>(ptr, 30);
            }
        }
    }

    public bool SwapFavorites(int favoriteSlotIndex1, int favoriteSlotIndex2) {
        if (favoriteSlotIndex1 >= 30 || favoriteSlotIndex2 >= 30)
            return false;
        (Favorites[favoriteSlotIndex1], Favorites[favoriteSlotIndex2]) = (Favorites[favoriteSlotIndex2], Favorites[favoriteSlotIndex1]);
        UserFileEvent.IsSavePending = true;
        UserFileEvent.SaveFile(false);
        return true;
    }

    public bool IsFavorite(ushort orderId) {
        foreach (ref var fav in FavoritesSpan)
            if (fav == orderId + 1)
                return true;
        return false;
    }

    public bool HasAnyFavorites() {
        foreach (ref var fav in FavoritesSpan)
            if (fav != 0)
                return true;
        return false;
    }

    public bool HasFreeFavoriteSlots() {
        foreach (ref var fav in FavoritesSpan)
            if (fav == 0)
                return true;
        return false;
    }
}
