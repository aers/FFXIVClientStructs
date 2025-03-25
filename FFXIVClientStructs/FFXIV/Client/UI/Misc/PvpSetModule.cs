using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// The struct layout is purely speculative, as additional PvP actions were removed from the game.

// Client::UI::Misc::PvpSetModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct PvpSetModule {
    public static PvpSetModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetPvpSetModule();
    }

    // TODO: struct size decreased in 7.2 from 0xA0
    /*
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray20<AdditionalPvpActions> _additionalActions;
    [FieldOffset(0x98)] internal byte Unk90;

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public struct AdditionalPvpActions {
        [FieldOffset(0)] public ushort ActionId1;
        [FieldOffset(2)] public ushort ActionId2;
    }
    */
}
