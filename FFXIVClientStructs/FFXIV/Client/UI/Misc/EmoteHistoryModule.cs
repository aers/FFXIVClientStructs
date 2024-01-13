using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::EmoteHistoryModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 33 C0"
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct EmoteHistoryModule {
    public static EmoteHistoryModule* Instance() => Framework.Instance()->GetUiModule()->GetEmoteHistoryModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;

    [FieldOffset(0x42)] public fixed ushort History[6];
    [FieldOffset(0x4E)] public fixed ushort Favorites[20];
    [FieldOffset(0x76)] internal fixed byte SeenEmotesBitmask[1]; // unknown size

    [MemberFunction("E8 ?? ?? ?? ?? 8B 43 20 85 C0 74 17")]
    public partial bool AddToHistory(ushort emoteId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 4F 42")]
    public partial bool RemoveFromHistory(ushort emoteId);

    [MemberFunction("40 53 48 83 EC 20 45 33 C9 4C 8D 41 4E")]
    public partial bool AddToFavorites(ushort emoteId);

    [MemberFunction("48 83 EC 28 83 FA 14 72 07")]
    public partial bool SetFavoriteEmote(int favoriteSlotIndex, ushort emoteId);

    [MemberFunction("48 83 EC 28 83 FA 14 73 3D")]
    public partial bool SwapFavorites(int favoriteSlotIndex1, int favoriteSlotIndex2);

    [MemberFunction("4C 8B C1 66 85 D2 75 07")]
    public partial bool IsUnseen(ushort emoteId);

    [MemberFunction("4C 8B C9 66 85 D2 74 4F")]
    public partial void SetSeen(ushort emoteId);

    public bool RemoveFromFavorites(ushort emoteId) {
        for (var i = 0; i < 20; i++)
            if (Favorites[i] == emoteId)
                return SetFavoriteEmote(i, 0);
        return false;
    }
}
