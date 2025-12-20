using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MKDSupportJobNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct MKDSupportJobNoteModule {
    public static MKDSupportJobNoteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMKDSupportJobNoteModule();
    }

    [FieldOffset(0x48)] public StdVector<byte> SeenSupportJobs;
}
