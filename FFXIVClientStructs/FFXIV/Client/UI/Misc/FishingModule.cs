using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::FishingModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct FishingModule {
    public static FishingModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetFishingModule();
    }

    [FieldOffset(0x48)] public StdSet<ushort> SortedUnseenFish;
    [FieldOffset(0x58), FixedSizeArray] internal FixedSizeArray50<ushort> _unseenFish; // not sure if it starts here or at 0x56
    [FieldOffset(0xBC)] public ushort UnseenFishCount;
}
