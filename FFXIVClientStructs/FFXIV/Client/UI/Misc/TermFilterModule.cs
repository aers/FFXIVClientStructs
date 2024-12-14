using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::TermFilterModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct TermFilterModule {
    public static TermFilterModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetTermFilterModule();
    }

    [FieldOffset(0x49)] public TermFilterSetting Setting;
    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray10<TermFilterEntry> _termFilters;
    [FieldOffset(0x18A)] public bool TermFiltersEnabled;

    [MemberFunction("45 84 C9 74 16 45 85 C0")]
    public partial int SetEntry(TermFilterEntry* entry, int index, bool skipIfNotEmpty = false);

    [MemberFunction("85 D2 78 2D 83 FA 0A")]
    public partial int ClearEntry(int index);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct TermFilterEntry {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray31<byte> _term; // NOT null terminated
        [FieldOffset(0x1F)] public TermFilterChannelFlag ChannelFlag; // mask: 0b0001_1111?
    }

    [Flags]
    public enum TermFilterChannelFlag : byte {
        None = 0,
        Say = 1 << 0,
        Yell = 1 << 1,
        Shout = 1 << 2,
        Tell = 1 << 3,
        CustomEmotes = 1 << 4,
    }

    public enum TermFilterSetting : byte {
        DisplayFilterNumber = 0,
        HideMessageEntirety = 1,
    }
}
