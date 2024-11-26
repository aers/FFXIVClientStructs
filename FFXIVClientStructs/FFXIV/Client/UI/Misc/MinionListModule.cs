using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MinionListModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct MinionListModule {
    public static MinionListModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMinionListModule();
    }

    // [FieldOffset(0x48)] public byte Unk40; // set to 1 in ReadFile
    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray10<ushort> _unseenCompanions;
    [FieldOffset(0x5E), FixedSizeArray] internal FixedSizeArray30<ushort> _favorites;
    // [FieldOffset(0x9A)] public uint Unk92;

    [MemberFunction("48 83 EC 28 44 0F B7 D2 4C 8B C9 45 32 C0 66 90 41 0F B6 C0 66 44 39 54 41 ??")]
    public partial bool AddToUnseenCompanions(ushort companionId);

    [MemberFunction("40 57 48 83 EC 20 4C 8B C1")]
    public partial bool RemoveFromUnseenCompanions(ushort companionId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 41 8D 5E 0B")]
    public partial bool IsFavorite(ushort companionId);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 86 ?? ?? ?? ?? 49 8B 4E 10")]
    public partial bool AddToFavorites(ushort companionId);

    [MemberFunction("48 83 EC 28 4C 8B C9 32 C0")]
    public partial bool RemoveFromFavorites(ushort companionId);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 8E ?? ?? ?? ?? 4C 8D 44 24 ?? 49 83 C1 03")]
    public partial bool SwapFavorites(int favoriteSlotIndex1, int favoriteSlotIndex2);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 48 8D 93 ?? ?? ?? ?? 48 8B CB")]
    public partial bool HasAnyFavorites();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 49 8B 96 ?? ?? ?? ?? 49 8B CE")]
    public partial bool HasFreeFavoriteSlots();
}
