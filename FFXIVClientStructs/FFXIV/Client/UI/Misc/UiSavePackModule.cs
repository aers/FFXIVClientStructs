using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::UiSavePackModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct UiSavePackModule {
    public static UiSavePackModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetUiSavePackModule();
    }

    [VirtualFunction(14)]
    public partial nint GetSegment(byte segment);

    public nint GetSegment(DataSegment segment) => GetSegment((byte)segment);
}

public enum DataSegment : byte {
    LETTER = 0x00, // LetterData (Ingame Mail)
    RETTASK = 0x01, // RetainerTaskData
    FLAGS = 0x02, // FlagStatus
    RCFAV = 0x03, // RecipeFavorite
    UIDATA = 0x04, // UiData
    TLPH = 0x05, // TeleportHistory
    ITCC = 0x06, // ItemContextCustomize
    PVPSET = 0x07, // PvpSet
    EMTH = 0x08, // EmoteHistory
    MNONLST = 0x09, // MinionList
    MUNTLST = 0x0A, // MountList
    EMJ = 0x0B, // Emj
    AOZNOTE = 0x0C, // AozNote
    CWLS = 0x0D, // CrossWorldLinkShell
    ARCHVLST = 0x0E, // AchievementList
    GRPPOS = 0x0F, // GroupPose
    CRAFT = 0x10, // Craft
    FMARKER = 0x11, // FieldMarker
    MYCNOT = 0x12, // MycNote
    ORNMLST = 0x13, // OrnamentList
    MYCITEM = 0x14, // MycIte
    GRPSTAMP = 0x15, // GroupPoseStamp
    RTNR = 0x16, // RetainerComment
    BANNER = 0x17, // Banner
    ADVNOTE = 0x18, // AdventureNote
    AKTKNOT = 0x19, // AkatsukiNote
    VVDNOTE = 0x1A, // VVDNote
    VVDACT = 0x1B, // VVDAction
    TOFU = 0x1C, // Tofu
    FISHING = 0x1D, // Fishing
    ACTION = 0x1E, // Action
    TFILTER = 0x1F, // TermFilter
    READYC = 0x20, // ReadyCheck
    PTRLST = 0x21, // PartyRoleList
    CATSBM = 0x22, // CatalogSearchBookmark
    DESCRI = 0x23, // Description
    MJICWSP = 0x24, // MjiCreateWorkshopPreset
    PERFORM = 0x25, // PerformanceModule
    MKDSJOB = 0x26, // MKDSupportJob
    MKDLORE = 0x27, // MKDLore
    MKDSJN = 0x28, // MKDSupportJobNote
    QPNL = 0x29,
}
