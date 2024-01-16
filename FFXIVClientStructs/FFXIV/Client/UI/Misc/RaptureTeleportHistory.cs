using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureTeleportHistory
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4"
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct RaptureTeleportHistory {
    public static RaptureTeleportHistory* Instance() => Framework.Instance()->GetUiModule()->GetRaptureTeleportHistory();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
}
