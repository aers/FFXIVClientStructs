using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::TeleportHistoryModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct TeleportHistoryModule {
    public static TeleportHistoryModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetTeleportHistoryModule();
    }

    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray20<TeleportHistoryEntry> _history;

    /// <summary>
    /// Adds a Teleport desination to the history.
    /// </summary>
    /// <param name="aetheryteId">The Aetheryte RowId</param>
    /// <param name="a2">Always passed as false</param>
    /// <param name="ward">The Ward index</param>
    /// <param name="plot">The Plot index</param>
    /// <param name="subIndex">The SubIndex</param>
    /// <returns>LogMessage RowId</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 83 C4 ?? 5F C3 FF 50")]
    public partial uint AddToHistory(ushort aetheryteId, bool a2, byte ward, byte plot, byte subIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 C6 44 24 ?? 00 84 C0")]
    public partial bool IsInHistory(ushort aetheryteId, byte ward, byte plot, byte subIndex);

    [StructLayout(LayoutKind.Explicit, Size = 0x06)]
    public partial struct TeleportHistoryEntry {
        [FieldOffset(0x00)] public ushort AetheryteId;
        [FieldOffset(0x02)] public byte Flags; // & 1 != 0 means its not empty
        [FieldOffset(0x03)] public byte Ward;
        [FieldOffset(0x04)] public byte Plot;
        [FieldOffset(0x05)] public byte SubIndex;
    }
}
