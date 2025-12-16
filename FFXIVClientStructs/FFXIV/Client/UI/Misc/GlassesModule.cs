using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::GlassesModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct GlassesModule {
    public static GlassesModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetGlassesModule();
    }
}
