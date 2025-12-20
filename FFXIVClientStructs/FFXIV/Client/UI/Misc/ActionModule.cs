using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ActionModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct ActionModule {
    public static ActionModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetActionModule();
    }

    // [FieldOffset(0x48)] private StdSet<?> Unk48;
    // [FieldOffset(0x58)] private StdSet<?> Unk58;
}
