using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ItemContextCustomizeModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x198)]
public unsafe partial struct ItemContextCustomizeModule {
    public static ItemContextCustomizeModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetItemContextCustomizeModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray128<byte> _firstTier;
    [FieldOffset(0xC8), FixedSizeArray] internal FixedSizeArray128<byte> _secondTier;

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 7E ?? ?? ?? ?? 48 85 C9")]
    public partial void ResetAll();
}
