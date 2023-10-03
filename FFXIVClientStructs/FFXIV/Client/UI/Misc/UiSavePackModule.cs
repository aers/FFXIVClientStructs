using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::UiSavePackModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 33 FF 48 89 51 10 48 8D 05 ?? ?? ?? ?? 48 89 79 08 48 8B D9 48 89 01 48 89 79 18 4C 8D 05 ?? ?? ?? ?? 89 79 20 8D 57 0C 48 89 79 28 89 79 3C 48 83 C1 30 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 43 48 1E"
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct UiSavePackModule {
    public static UiSavePackModule* Instance() => Framework.Instance()->GetUiModule()->GetUiSavePackModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;

    [VirtualFunction(13)]
    public partial nint GetSegment(byte segment);

    public nint GetSegment(DataSegment segment) => GetSegment((byte)segment);
}

public enum DataSegment : byte {
    LETTER = 0x00, // Ingame Mail
    RETTASK = 0x01,
    FLAGS = 0x02,
    RCFAV = 0x03,
    UIDATA = 0x04,
    TLPH = 0x05,
    ITCC = 0x06,
    PVPSET = 0x07,
    EMTH = 0x08,
    MNONLST = 0x09,
    MUNTLST = 0x0A,
    EMJ = 0x0B,
    AOZNOTE = 0x0C,
    CWLS = 0x0D,
    ARCHVLST = 0x0E,
    GRPPOS = 0x0F,
    CRAFT = 0x10,
    FMARKER = 0x11,
    MYCNOT = 0x12,
    ORNMLST = 0x13,
    MYCITEM = 0x14,
    GRPSTAMP = 0x15,
    RTNR = 0x16,
    BANNER = 0x17,
    ADVNOTE = 0x18,
    AKTKNOT = 0x19,
    VVDNOTE = 0x1A,
    VVDACT = 0x1B,
    TOFU = 0x1C,
}
