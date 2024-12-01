using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::PartyRoleListModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct PartyRoleListModule {
    public static PartyRoleListModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetPartyRoleListModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray16<ushort> _tankOrder;
    [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray16<ushort> _healerOrder;
    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray16<ushort> _dpsOrder;
}
