using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::VVDNotebookModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct VVDNotebookModule {
    public static VVDNotebookModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetVVDNotebookModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray3<VVDNotebookSeries> _seenNotes;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public partial struct VVDNotebookSeries {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray12<byte> _contents; // VVDNotebookContents
    }
}
