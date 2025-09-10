using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ExtraCommandHelper
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExtraCommandHelper {
    public static ExtraCommandHelper* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetExtraCommandHelper();
    }

    [FieldOffset(0x08)] public UIModule* UIModulePtr;

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4C 24 ?? 0F B6 E8")]
    public partial bool CanExecuteExtraCommand(int commandId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 8A ?? ?? ?? ?? E8")]
    public partial void ExecuteExtraCommand(int commandId);
}
