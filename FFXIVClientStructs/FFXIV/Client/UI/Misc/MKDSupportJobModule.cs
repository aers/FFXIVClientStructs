using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MKDSupportJobModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct MKDSupportJobModule {
    public static MKDSupportJobModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMKDSupportJobModule();
    }

    [FieldOffset(0x48)] public StdVector<MKDSupportJobSettings> JobSettings;

    [StructLayout(LayoutKind.Explicit, Size = 3)]
    public struct MKDSupportJobSettings {
        [FieldOffset(0x00)] public byte JobId;
        [FieldOffset(0x01)] public byte DefaultActionId;
        [FieldOffset(0x02)] public byte ActionHiddenFlags;
    }
}
