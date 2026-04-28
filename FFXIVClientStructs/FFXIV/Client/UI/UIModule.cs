using FFXIVClientStructs.FFXIV.Client.System.Framework;
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
[StructLayout(LayoutKind.Explicit, Size = 0xFFB40)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 4C 24 ?? 48 89 01", 3, 248)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() {
        var framework = Framework.Instance();
        return framework == null ? null : framework->GetUIModule();
    }

    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray57<UIModuleHandler> _uIModuleHandlers;
    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray23<RaptureAtkHistory> _atkHistory;
    [FieldOffset(0x8C8)] public int LinkshellCycle;
    [FieldOffset(0x8CC)] public int CrossWorldLinkshellCycle;
    [FieldOffset(0x8D0)] public bool ShouldExitGame;
    [FieldOffset(0x8D4)] public uint FrameCount;
    [FieldOffset(0x8D8)] internal ExcelModuleInterface* ExcelModuleInterface; // this is Component::Excel::ExcelModuleInterface, not Common::Component::Excel::ExcelModuleInterface!
    [FieldOffset(0x8E0)] internal RaptureTextModule RaptureTextModule;
    [FieldOffset(0x1748)] public CompletionModule CompletionModule;
    [FieldOffset(0x1AC0)] internal RaptureLogModule RaptureLogModule;
    [FieldOffset(0x6190)] public UserFileManager UserFileManager;
    [FieldOffset(0x61B0)] internal RaptureMacroModule RaptureMacroModule;
    [FieldOffset(0x57C60)] internal RaptureHotbarModule RaptureHotbarModule;
    [FieldOffset(0x83058)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8E7A0)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8F938)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8FA18)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x91428)] internal AddonConfig AddonConfig;
    [FieldOffset(0x91498)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x919C8)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x91A20)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x92470)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x92528)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x927D8)] internal RecipeFavoriteModule RecipeFavoriteModule;
    [FieldOffset(0x92968)] internal CraftModule CraftModule;
    [FieldOffset(0x929C8)] internal UiDataModule UiDataModule;
    [FieldOffset(0x962A0)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x962C0)] internal WorldHelper WorldHelper;
    [FieldOffset(0x96310)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x965E0)] internal TeleportHistoryModule TeleportHistoryModule;
    [FieldOffset(0x966A8)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x96840)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x968C0)] internal PvpSetModule PvpSetModule;
    [FieldOffset(0x96938)] internal ExtraCommandHelper ExtraCommandHelper;
    [FieldOffset(0x96948)] internal JobHudManualHelper JobHudManualHelper;
    [FieldOffset(0x96958)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x96AD8)] internal MinionListModule MinionListModule;
    [FieldOffset(0x96B78)] internal MountListModule MountListModule;
    [FieldOffset(0x96C18)] internal EmjModule EmjModule;
    [FieldOffset(0x96CE8)] internal AozNoteModule AozNoteModule;
    [FieldOffset(0x97A18)] internal CrossWorldLinkShellModule CrossWorldLinkShellModule;
    [FieldOffset(0x98010)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x980A0)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x981E0)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x96280)] internal ExcelSheetPreloader ExcelSheetPreloader;
    [FieldOffset(0x98E70)] internal MycNoteModule MycNoteModule;
    [FieldOffset(0x98F28)] internal OrnamentListModule OrnamentListModule;
    [FieldOffset(0x98F88)] internal MycItemModule MycItemModule;
    [FieldOffset(0x990A8)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0xA9108)] internal InputTimerModule InputTimerModule;
    [FieldOffset(0xA9600)] internal McAggreModule McAggreModule;
    [FieldOffset(0xA98C8)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0xA9E70)] internal BannerModule BannerModule;
    [FieldOffset(0xA9EC0)] internal AdventureNoteModule AdventureNoteModule;
    [FieldOffset(0xA9F20)] internal AkatsukiNoteModule AkatsukiNoteModule;
    [FieldOffset(0xAA008)] internal VVDNotebookModule VVDNotebookModule;
    [FieldOffset(0xAA088)] internal VVDActionModule VVDActionModule;
    [FieldOffset(0xAA0D8)] internal TofuModule TofuModule;
    [FieldOffset(0xAA128)] internal FishingModule FishingModule;
    [FieldOffset(0xAA1E8)] internal ActionModule ActionModule;
    [FieldOffset(0xAA250)] internal TermFilterModule TermFilterModule;
    [FieldOffset(0xAA3E0)] internal ReadyCheckModule ReadyCheckModule;
    [FieldOffset(0xAA430)] internal PartyRoleListModule PartyRoleListModule;
    [FieldOffset(0xAA4D8)] internal CatalogSearchBookmarkModule CatalogSearchBookmarkModule;
    [FieldOffset(0xAA6B8)] internal DescriptionModule DescriptionModule;
    [FieldOffset(0xAA710)] internal MJICraftworksPresetModule MJICraftworksPresetModule;
    [FieldOffset(0xAA848)] internal PerformanceModule PerformanceModule;
    [FieldOffset(0xAA898)] internal MKDSupportJobModule MKDSupportJobModule;
    [FieldOffset(0xAA8F8)] internal MKDLoreModule MKDLoreModule;
    [FieldOffset(0xAA958)] internal MKDSupportJobNoteModule MKDSupportJobNoteModule;
    [FieldOffset(0xAA9B8)] internal QuickPanelModule QuickPanelModule;
    [FieldOffset(0xAAC28)] internal GlassesModule GlassesModule;
    // [FieldOffset(0xAACA0)] internal XBMNOTE;
    // [FieldOffset(0xAAD00)] internal XBM;
    // [FieldOffset(0xAAD88)] internal nint Vf81Struct;
    [FieldOffset(0xAAE20)] internal ConfigModule ConfigModule;
    [FieldOffset(0xB9B30)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xBAD80)] internal PronounModule PronounModule;

    [FieldOffset(0xBB130)] internal UI3DModule UI3DModule;
    [FieldOffset(0xD2670)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xFCFB0)] internal InfoModule InfoModule;
    [FieldOffset(0xFEC28)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xFEC78)] public Utf8String AddonSheetName;

    [FieldOffset(0xFECE8)] public Utf8String UIColorSheetName;

    [FieldOffset(0xFED60)] public Utf8String CompletionSheetName;
    [FieldOffset(0xFEDC8)] public Utf8String CompletionOpenIconMacro;
    [FieldOffset(0xFEE30)] public Utf8String CompletionCloseIconMacro;
    [FieldOffset(0xFEE98)] public Utf8String NewLineMacro;
    [FieldOffset(0xFEF00)] public Utf8String LastTalkName;
    [FieldOffset(0xFEF68)] public Utf8String LastTalkText;
    [FieldOffset(0xFEFD0)] internal UIInputData UIInputData;
    [FieldOffset(0xFFA00)] internal UIInputModule UIInputModule;
    // [FieldOffset(0xF7AF8)] public Vf79Struct;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F2 48 8B F9 45 84 C9")]
    public partial void ProcessChatBoxEntry(Utf8String* message, nint a4 = 0, bool saveToHistory = false);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct UIModuleHandler {
        // called via AtkModuleEvent.CallHandler()
        [FieldOffset(0x0)] public delegate* unmanaged<void*, AtkValue*, AtkValue*, uint, AtkValue*> FunctionPtr; // (mostLikelyUIModule, result, values, valueCount) -> result
        [FieldOffset(0x8)] public uint UIModuleOffset;
    }
}

[Flags]
public enum UiFlags {
    None = 0,
    Shortcuts = 1 << 0, // disable ui shortcuts
    Hud = 1 << 1,
    Nameplates = 1 << 2,
    Chat = 1 << 3,
    ActionBars = 1 << 4,
    Unk32 = 1 << 5, // same as 1 ?
    TargetInfo = 1 << 6 // + disable system menu / ESC key
}
