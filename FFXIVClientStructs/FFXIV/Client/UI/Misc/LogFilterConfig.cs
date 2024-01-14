using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::LogFilterConfig
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 33 FF 48 89 51 10 48 8D 05 ?? ?? ?? ?? 48 89 79 08 48 8B D9 48 89 01 48 89 79 18 4C 8D 05 ?? ?? ?? ?? 89 79 20 8D 57 0C 48 89 79 28 89 79 3C 48 83 C1 30 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 8D 4F 13"
[StructLayout(LayoutKind.Explicit, Size = 0x528)]
public unsafe partial struct LogFilterConfig {
    public static LogFilterConfig* Instance() => Framework.Instance()->GetUiModule()->GetLogFilterConfig();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
}
