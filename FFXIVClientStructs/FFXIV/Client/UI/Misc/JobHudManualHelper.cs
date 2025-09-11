namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::JobHudManualHelper
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct JobHudManualHelper {
    public static JobHudManualHelper* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetJobHudManualHelper();
    }

    [FieldOffset(0x08)] public UIModule* UIModulePtr;
}
