using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::VVDNotebookModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct VVDNotebookModule {
    public static VVDNotebookModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetVVDNotebookModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray4<VVDNotebookSeries> _seenNotes;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 13)]
    public partial struct VVDNotebookSeries {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray13<byte> _contents; // VVDNotebookContents
    }
}
