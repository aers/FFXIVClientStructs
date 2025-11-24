using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AdventureNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AdventureNoteModule {
    public static AdventureNoteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetAdventureNoteModule();
    }

    [FieldOffset(0x49)] public bool AutomaticallyDisplayRecord;
    /// <remarks>
    /// Adventure RowIds are EventIds, this is the EntryId part of it
    /// </remarks>
    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray10<short> _unseenAdventureNoteIds;
}
