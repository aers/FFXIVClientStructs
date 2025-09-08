using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MycNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct MycNoteModule {
    public static MycNoteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMycNoteModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray55<bool> _unk48; // _seenMycNotes1?
    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray55<bool> _unk80; // _seenMycNotes2?
}
