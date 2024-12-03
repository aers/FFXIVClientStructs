using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::LogFilterConfig
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x530)]
public unsafe partial struct LogFilterConfig {
    public static LogFilterConfig* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetLogFilterConfig();
    }
}
