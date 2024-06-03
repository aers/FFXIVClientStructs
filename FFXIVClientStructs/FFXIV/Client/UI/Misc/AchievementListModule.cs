using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AchievementListModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 33 C0"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct AchievementListModule {
    public static AchievementListModule* Instance() => Framework.Instance()->GetUIModule()->GetAchievementListModule();
    // [FieldOffset(0x40)] public byte Unk40;
    [FieldOffset(0x42), FixedSizeArray] internal FixedSizeArray30<ushort> _watchList;
    // [FieldOffset(0x7E)] public byte Unk7E;
    [FieldOffset(0x80)] public byte WatchlistCount; // 30 max

    [MemberFunction("C6 81 ?? ?? ?? ?? ?? 48 8D 41 42")]
    public partial void UpdateWatchlistCount();

    [MemberFunction("48 83 EC 28 33 C0 4C 8D 41 42")]
    public partial bool AddToWatchlist(ushort achievementId);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 FF FF C7")]
    public partial bool RemoveFromWatchlist(ushort achievementId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 B9 ?? ?? ?? ??")]
    public partial bool IsOnWatchlist(ushort achievementId);

    [MemberFunction("33 D2 48 8D 41 42")]
    public partial bool IsWatchlistFull();
}
