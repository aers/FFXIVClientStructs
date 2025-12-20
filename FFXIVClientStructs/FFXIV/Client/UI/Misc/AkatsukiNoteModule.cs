using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AkatsukiNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct AkatsukiNoteModule {
    public static AkatsukiNoteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetAkatsukiNoteModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray80<AkatsukiNoteEntry> _entries;

    [StructLayout(LayoutKind.Explicit, Size = 0x02)]
    public struct AkatsukiNoteEntry {
        [FieldOffset(0x00)] public byte NumSubEntriesSeen; // max seen subrow id of the AkatsukiNote sheet?!
        [FieldOffset(0x01)] public bool IsUnseen;
    }
}
