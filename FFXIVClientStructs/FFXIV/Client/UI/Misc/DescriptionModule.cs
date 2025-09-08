using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::DescriptionModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct DescriptionModule {
    public static DescriptionModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetDescriptionModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray4<uint> _seenDescriptionBitfields;
}
