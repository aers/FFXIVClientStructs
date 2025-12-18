using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::McAggreModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct McAggreModule {
    public static McAggreModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMcAggreModule();
    }

    [FieldOffset(0x48)] private int UnkTimestamp; // read/write as long though
    /// <remarks> Index is MainCommandSheet.Unknown0, if the value is > 0. Stance (RowId 1) is ignored. </remarks>
    [FieldOffset(0x4C), FixedSizeArray] internal FixedSizeArray78<int> _usages;
    /// <remarks> Index is MainCommandSheet.Unknown0, if the value is > 0. </remarks>
    [FieldOffset(0x184), FixedSizeArray] internal FixedSizeArray78<int> _failedUsages;
    [FieldOffset(0x2C0)] private byte Unk2C0;
    [FieldOffset(0x2C1)] private byte Unk2C1;
}
