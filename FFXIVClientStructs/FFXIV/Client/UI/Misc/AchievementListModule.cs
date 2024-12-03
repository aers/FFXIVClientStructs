using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AchievementListModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AchievementListModule {
    public static AchievementListModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetAchievementListModule();
    }

    // [FieldOffset(0x48)] public byte Unk40;
    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray30<ushort> _watchList;
    // [FieldOffset(0x86)] public byte Unk7E;
    [FieldOffset(0x88)] public byte WatchlistCount; // 30 max

    [MemberFunction("C6 81 ?? ?? ?? ?? ?? 48 8D 41 4A")]
    public partial void UpdateWatchlistCount();

    [MemberFunction("48 83 EC 28 33 C0 4C 8D 41 4A")]
    public partial bool AddToWatchlist(ushort achievementId);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 FF FF C7")]
    public partial bool RemoveFromWatchlist(ushort achievementId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 B9 ?? ?? ?? ??")]
    public partial bool IsOnWatchlist(ushort achievementId);

    [MemberFunction("33 D2 48 8D 41 4A")]
    public partial bool IsWatchlistFull();
}
