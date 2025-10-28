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
[StructLayout(LayoutKind.Explicit, Size = 0xF6EB0)]
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
    [FieldOffset(0x82538)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8DD48)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8EEE0)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8EFC0)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x90198)] internal AddonConfig AddonConfig;
    [FieldOffset(0x90208)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x90738)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x90790)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x911E0)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x91298)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x91548)] internal RecipeFavoriteModule RecipeFavoriteModule;
    [FieldOffset(0x916D8)] internal CraftModule CraftModule;
    [FieldOffset(0x91738)] internal RaptureUiDataModule RaptureUiDataModule;
    [FieldOffset(0x95010)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x95030)] internal WorldHelper WorldHelper;
    [FieldOffset(0x95070)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x95340)] internal RaptureTeleportHistory RaptureTeleportHistory;
    [FieldOffset(0x95408)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x955A0)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x95620)] internal PvpSetModule PvpSetModule;
    [FieldOffset(0x95698)] internal ExtraCommandHelper ExtraCommandHelper;
    [FieldOffset(0x956A8)] internal JobHudManualHelper JobHudManualHelper;
    [FieldOffset(0x956B8)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x95838)] internal MinionListModule MinionListModule;
    [FieldOffset(0x958D8)] internal MountListModule MountListModule;
    [FieldOffset(0x95978)] internal EmjModule EmjModule;
    [FieldOffset(0x95A48)] internal AozNoteModule AozNoteModule;
    [FieldOffset(0x96778)] internal CrossWorldLinkShellModule CrossWorldLinkShellModule;
    [FieldOffset(0x96D70)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x96E00)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x96F40)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x95FA0)] internal ExcelSheetPreloader ExcelSheetPreloader;
    [FieldOffset(0x97BD0)] internal MycNoteModule MycNoteModule;
    [FieldOffset(0x97C88)] internal OrnamentListModule OrnamentListModule;
    [FieldOffset(0x97CE8)] internal MycItemModule MycItemModule;
    [FieldOffset(0x97E08)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0xA1108)] internal InputTimerModule InputTimerModule;
    [FieldOffset(0xA1600)] internal McAggreModule McAggreModule;
    [FieldOffset(0xA18C8)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0xA1E70)] internal BannerModule BannerModule;
    [FieldOffset(0xA1EC0)] internal AdventureNoteModule AdventureNoteModule;
    [FieldOffset(0xA1F20)] internal AkatsukiNoteModule AkatsukiNoteModule;
    [FieldOffset(0xA2008)] internal VVDNotebookModule VVDNotebookModule;
    [FieldOffset(0xA2078)] internal VVDActionModule VVDActionModule;
    [FieldOffset(0xA20C8)] internal TofuModule TofuModule;
    [FieldOffset(0xA2118)] internal FishingModule FishingModule;
    [FieldOffset(0xA21D8)] internal ActionModule ActionModule;
    [FieldOffset(0xA2240)] internal TermFilterModule TermFilterModule;
    [FieldOffset(0xA23D0)] internal ReadyCheckModule ReadyCheckModule;
    [FieldOffset(0xA2420)] internal PartyRoleListModule PartyRoleListModule;
    [FieldOffset(0xA24C8)] internal CatalogSearchBookmarkModule CatalogSearchBookmarkModule;
    [FieldOffset(0xA26A8)] internal DescriptionModule DescriptionModule;
    [FieldOffset(0xA2700)] internal MJICraftworksPresetModule MJICraftworksPresetModule;
    [FieldOffset(0xA2838)] internal PerformanceModule PerformanceModule;
    [FieldOffset(0xA2888)] internal MKDSupportJobModule MKDSupportJobModule;
    [FieldOffset(0xA28E8)] internal MKDLoreModule MKDLoreModule;
    [FieldOffset(0xA2948)] internal MKDSupportJobNoteModule MKDSupportJobNoteModule;
    // [FieldOffset(0xA29A8)] internal nint QPNL; // QuickPanel... something - not in game yet
    // [FieldOffset(0xA2BF8)] internal nint Vf81Struct;
    [FieldOffset(0xA2C90)] internal ConfigModule ConfigModule;
    [FieldOffset(0xB1950)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xB2BA0)] internal PronounModule PronounModule;

    [FieldOffset(0xB2F50)] internal UI3DModule UI3DModule;
    [FieldOffset(0xCA490)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xF4340)] internal InfoModule InfoModule;
    [FieldOffset(0xF5FB8)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xF5FF0)] public Utf8String AddonSheetName;

    [FieldOffset(0xF6060)] public Utf8String UIColorSheetName;

    [FieldOffset(0xF60D8)] public Utf8String CompletionSheetName;
    [FieldOffset(0xF6140)] public Utf8String CompletionOpenIconMacro;
    [FieldOffset(0xF61A8)] public Utf8String CompletionCloseIconMacro;
    [FieldOffset(0xF6210)] public Utf8String NewLineMacro;
    [FieldOffset(0xF6278)] public Utf8String LastTalkName;
    [FieldOffset(0xF62E0)] public Utf8String LastTalkText;
    [FieldOffset(0xF6348)] internal UIInputData UIInputData;
    [FieldOffset(0xF6D78)] internal UIInputModule UIInputModule;
    // [FieldOffset(0xF6D78)] public Vf79Struct;

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
