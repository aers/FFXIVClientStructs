using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::OrnamentListModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct OrnamentListModule {
    public static OrnamentListModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetOrnamentListModule();
    }

    /// <remarks> Value is the Order column from the Ornament sheet + 1. </remarks>
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray10<short> _unseenOrnaments;
}
