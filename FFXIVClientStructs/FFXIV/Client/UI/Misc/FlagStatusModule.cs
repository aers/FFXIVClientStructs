using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::FlagStatusModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct FlagStatusModule {
    public static FlagStatusModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetFlagStatusModule();
    }

    /// <remarks>
    /// 13 = Default Currency Setting (Index of Rotation array in UIModule.UIModuleHelpers.CurrencySettings)
    /// </remarks>
    [FieldOffset(0x1AC), FixedSizeArray] internal FixedSizeArray64<byte> _flags;
}
