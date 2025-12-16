using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Component.Completion;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using ChangeEventInterface = FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase.ChangeEventInterface;
using ExcelModuleInterface = FFXIVClientStructs.FFXIV.Component.Excel.ExcelModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIModule
//   Client::UI::UIModuleInterface
//   Component::GUI::AtkModuleEvent
//   Component::Excel::ExcelLanguageEvent
//   Common::Configuration::ConfigBase::ChangeEventInterface
[GenerateInterop]
[Inherits<UIModuleInterface>, Inherits<AtkModuleEvent>, Inherits<ExcelLanguageEvent>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xFEEB0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 4C 24 ?? 48 89 01", 3)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() {
        var framework = Framework.Instance();
        return framework == null ? null : framework->GetUIModule();
    }

    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray57<UIModuleHandler> _uIModuleHandlers;
    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray19<RaptureAtkHistory> _atkHistory;
    [FieldOffset(0x7E8)] public int LinkshellCycle;
    [FieldOffset(0x7EC)] public int CrossWorldLinkshellCycle;
    [FieldOffset(0x7F0)] public bool ShouldExitGame;
    [FieldOffset(0x7F4)] public uint FrameCount;
    [FieldOffset(0x7F8)] internal ExcelModuleInterface* ExcelModuleInterface; // this is Component::Excel::ExcelModuleInterface, not Common::Component::Excel::ExcelModuleInterface!
    [FieldOffset(0x800)] internal RaptureTextModule RaptureTextModule;
    [FieldOffset(0x1668)] public CompletionModule CompletionModule;
    [FieldOffset(0x19E0)] internal RaptureLogModule RaptureLogModule;
    [FieldOffset(0x60B0)] public UserFileManager UserFileManager;
    [FieldOffset(0x60D0)] internal RaptureMacroModule RaptureMacroModule;
    [FieldOffset(0x57B80)] internal RaptureHotbarModule RaptureHotbarModule;
    [FieldOffset(0x82F78)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8E6C0)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8F858)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8F938)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x91150)] internal AddonConfig AddonConfig;
    [FieldOffset(0x911C0)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x916F0)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x91748)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x92198)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x92250)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x92500)] internal RecipeFavoriteModule RecipeFavoriteModule;
    [FieldOffset(0x92690)] internal CraftModule CraftModule;
    [FieldOffset(0x926F0)] internal UiDataModule UiDataModule;
    [FieldOffset(0x95FC8)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x95FE8)] internal WorldHelper WorldHelper;
    [FieldOffset(0x96028)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x962F8)] internal TeleportHistoryModule TeleportHistoryModule;
    [FieldOffset(0x963C0)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x96558)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x965D8)] internal PvpSetModule PvpSetModule;
    [FieldOffset(0x96650)] internal ExtraCommandHelper ExtraCommandHelper;
    [FieldOffset(0x96660)] internal JobHudManualHelper JobHudManualHelper;
    [FieldOffset(0x96670)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x967F0)] internal MinionListModule MinionListModule;
    [FieldOffset(0x96890)] internal MountListModule MountListModule;
    [FieldOffset(0x96930)] internal EmjModule EmjModule;
    [FieldOffset(0x96A00)] internal AozNoteModule AozNoteModule;
    [FieldOffset(0x97730)] internal CrossWorldLinkShellModule CrossWorldLinkShellModule;
    [FieldOffset(0x97D28)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x97DC0)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x97F00)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x95FA0)] internal ExcelSheetPreloader ExcelSheetPreloader;
    [FieldOffset(0x98B90)] internal MycNoteModule MycNoteModule;
    [FieldOffset(0x98C48)] internal OrnamentListModule OrnamentListModule;
    [FieldOffset(0x98CA8)] internal MycItemModule MycItemModule;
    [FieldOffset(0x98DC8)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0xA8E28)] internal InputTimerModule InputTimerModule;
    [FieldOffset(0xA9320)] internal McAggreModule McAggreModule;
    [FieldOffset(0xA95E8)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0xA9B90)] internal BannerModule BannerModule;
    [FieldOffset(0xA9BE0)] internal AdventureNoteModule AdventureNoteModule;
    [FieldOffset(0xA9C40)] internal AkatsukiNoteModule AkatsukiNoteModule;
    [FieldOffset(0xA9D28)] internal VVDNotebookModule VVDNotebookModule;
    [FieldOffset(0xA9DA8)] internal VVDActionModule VVDActionModule;
    [FieldOffset(0xA9DF8)] internal TofuModule TofuModule;
    [FieldOffset(0xA9E48)] internal FishingModule FishingModule;
    [FieldOffset(0xA9F08)] internal ActionModule ActionModule;
    [FieldOffset(0xA9F70)] internal TermFilterModule TermFilterModule;
    [FieldOffset(0xAA100)] internal ReadyCheckModule ReadyCheckModule;
    [FieldOffset(0xAA150)] internal PartyRoleListModule PartyRoleListModule;
    [FieldOffset(0xAA1F8)] internal CatalogSearchBookmarkModule CatalogSearchBookmarkModule;
    [FieldOffset(0xAA3D8)] internal DescriptionModule DescriptionModule;
    [FieldOffset(0xAA430)] internal MJICraftworksPresetModule MJICraftworksPresetModule;
    [FieldOffset(0xAA568)] internal PerformanceModule PerformanceModule;
    [FieldOffset(0xAA5B8)] internal MKDSupportJobModule MKDSupportJobModule;
    [FieldOffset(0xAA618)] internal MKDLoreModule MKDLoreModule;
    [FieldOffset(0xAA678)] internal MKDSupportJobNoteModule MKDSupportJobNoteModule;
    [FieldOffset(0xAA6D8)] internal QuickPanelModule QuickPanelModule;
    [FieldOffset(0xAA948)] internal GlassesModule GlassesModule;
    // [FieldOffset(0xA2BF8)] internal nint Vf81Struct;
    [FieldOffset(0xAAA58)] internal ConfigModule ConfigModule;
    [FieldOffset(0xB9718)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xBA968)] internal PronounModule PronounModule;

    [FieldOffset(0xBAD20)] internal UI3DModule UI3DModule;
    [FieldOffset(0xD2260)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xFC330)] internal InfoModule InfoModule;
    [FieldOffset(0xFDFA8)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xFDFE8)] public Utf8String AddonSheetName;

    [FieldOffset(0xFE058)] public Utf8String UIColorSheetName;

    [FieldOffset(0xFE0D0)] public Utf8String CompletionSheetName;
    [FieldOffset(0xFE138)] public Utf8String CompletionOpenIconMacro;
    [FieldOffset(0xFE1A0)] public Utf8String CompletionCloseIconMacro;
    [FieldOffset(0xFE208)] public Utf8String NewLineMacro;
    [FieldOffset(0xFE270)] public Utf8String LastTalkName;
    [FieldOffset(0xFE2D8)] public Utf8String LastTalkText;
    [FieldOffset(0xFE340)] internal UIInputData UIInputData;
    [FieldOffset(0xFED70)] internal UIInputModule UIInputModule;
    // [FieldOffset(0xF6E68)] public Vf79Struct;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F2 48 8B F9 45 84 C9")]
    public partial void ProcessChatBoxEntry(Utf8String* message, nint a4 = 0, bool saveToHistory = false);

    [Flags]
    public enum UiFlags {
        Shortcuts = 1, //disable ui shortcuts
        Hud = 2,
        Nameplates = 4,
        Chat = 8,
        ActionBars = 16,
        Unk32 = 32, //same as 1 ?
        TargetInfo = 64 //+disable system menu / ESC key
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct UIModuleHandler {
        // called via AtkModuleEvent.CallHandler()
        [FieldOffset(0x0)] public delegate* unmanaged<void*, AtkValue*, AtkValue*, uint, AtkValue*> FunctionPtr; // (mostLikelyUIModule, result, values, valueCount) -> result
        [FieldOffset(0x8)] public uint UIModuleOffset;
    }
}
