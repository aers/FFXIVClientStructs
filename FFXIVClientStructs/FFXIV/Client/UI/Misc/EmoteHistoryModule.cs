using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::EmoteHistoryModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 33 C0"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct EmoteHistoryModule {
    public static EmoteHistoryModule* Instance() => Framework.Instance()->GetUIModule()->GetEmoteHistoryModule();

    [FieldOffset(0x42), FixedSizeArray] internal FixedSizeArray6<ushort> _history;
    [FieldOffset(0x4E), FixedSizeArray] internal FixedSizeArray20<ushort> _favorites;
    [FieldOffset(0x76), FixedSizeArray] internal FixedSizeArray1<byte> _seenEmotesBitmask; // unknown size

    [MemberFunction("E8 ?? ?? ?? ?? 83 7B 20 00 74 18")]
    public partial bool AddToHistory(ushort emoteId);

    [MemberFunction("48 83 EC 28 48 89 5C 24 ?? 4C 8D 41 42")]
    public partial bool RemoveFromHistory(ushort emoteId);

    [MemberFunction("40 53 48 83 EC 20 45 33 C9 4C 8D 41 4E")]
    public partial bool AddToFavorites(ushort emoteId);

    [MemberFunction("48 83 EC 28 83 FA 14 72 07")]
    public partial bool SetFavoriteEmote(int favoriteSlotIndex, ushort emoteId);

    [MemberFunction("48 83 EC 28 83 FA 14 73 3D")]
    public partial bool SwapFavorites(int favoriteSlotIndex1, int favoriteSlotIndex2);

    [MemberFunction("4C 8B C1 66 85 D2 75 07")]
    public partial bool IsUnseen(ushort emoteId);

    [MemberFunction("4C 8B C9 66 85 D2 74 4E")]
    public partial void SetSeen(ushort emoteId);

    public bool RemoveFromFavorites(ushort emoteId) {
        for (var i = 0; i < 20; i++)
            if (Favorites[i] == emoteId)
                return SetFavoriteEmote(i, 0);
        return false;
    }
}
