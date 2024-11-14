using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::VVDActionModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "40 53 48 83 EC 20 4C 8D 05 ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8B C3"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct VVDActionModule {
    public static VVDActionModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetVVDActionModule();
    }

    [FieldOffset(0x48)] public byte Action1;
    [FieldOffset(0x49)] public byte Action2;
}
