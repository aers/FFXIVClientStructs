using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::EmoteHistoryModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x180)]
public unsafe partial struct EmoteHistoryModule {
    public static EmoteHistoryModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetEmoteHistoryModule();
    }

    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray6<ushort> _history;
    [FieldOffset(0x56), FixedSizeArray] internal FixedSizeArray20<ushort> _favorites;
    [FieldOffset(0x7E), FixedSizeArray] internal FixedSizeArray1<byte> _seenEmotesBitmask; // unknown size

    [MemberFunction("E8 ?? ?? ?? ?? 83 7B 20 00 74 18")]
    public partial bool AddToHistory(ushort emoteId);

    [MemberFunction("48 83 EC 28 48 89 5C 24 ?? 4C 8D 41 4A")]
    public partial bool RemoveFromHistory(ushort emoteId);

    [MemberFunction("40 53 48 83 EC 20 45 33 C9 4C 8D 41 56")]
    public partial bool AddToFavorites(ushort emoteId);

    [MemberFunction("48 83 EC 28 83 FA 14 72 07")]
    public partial bool SetFavorite(int favoriteSlotIndex, ushort emoteId);

    [MemberFunction("48 83 EC 28 83 FA 14 73 3D")]
    public partial bool SwapFavorites(int favoriteSlotIndex1, int favoriteSlotIndex2);

    [MemberFunction("4C 8B C1 66 85 D2 75 07")]
    public partial bool IsUnseen(ushort emoteId);

    [MemberFunction("4C 8B C9 66 85 D2 74 4E")]
    public partial void SetSeen(ushort emoteId);

    public bool RemoveFromFavorites(ushort emoteId) {
        for (var i = 0; i < 20; i++)
            if (Favorites[i] == emoteId)
                return SetFavorite(i, 0);
        return false;
    }
}
