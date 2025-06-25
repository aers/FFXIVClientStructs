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
[StructLayout(LayoutKind.Explicit, Size = 0xF4C10)]
[VirtualTable("4C 89 79 28 48 8D 0D", 7)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() {
        var framework = Framework.Instance();
        return framework == null ? null : framework->GetUIModule();
    }

    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray57<UIModuleHandler> _uIModuleHandlers;
    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray19<RaptureAtkHistory> _atkHistory;
    [FieldOffset(0x7E8)] public int LinkshellCycle;
    [FieldOffset(0x7EC)] public int CrossWorldLinkshellCycle;

    [FieldOffset(0x7F4)] public uint FrameCount;
    [FieldOffset(0x7F8)] internal ExcelModuleInterface* ExcelModuleInterface; // this is Component::Excel::ExcelModuleInterface, not Common::Component::Excel::ExcelModuleInterface!
    [FieldOffset(0x800)] internal RaptureTextModule RaptureTextModule;
    [FieldOffset(0x1668)] public CompletionModule CompletionModule;
    [FieldOffset(0x19E0)] internal RaptureLogModule RaptureLogModule;
    [FieldOffset(0x60B0)] public UserFileManager UserFileManager;
    [FieldOffset(0x60D0)] internal RaptureMacroModule RaptureMacroModule;
    [FieldOffset(0x57B80)] internal RaptureHotbarModule RaptureHotbarModule;
    [FieldOffset(0x80910)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8C120)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8D2B8)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8D398)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x8E570)] internal AddonConfig AddonConfig;
    [FieldOffset(0x8E5E0)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x8EB10)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x8EB68)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x8F5B8)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x8F670)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x8F920)] internal RecipeFavoriteModule RecipeFavoriteModule;
    // [FieldOffset(0x8FAB0)] internal CraftModule CraftModule;
    [FieldOffset(0x8FB10)] internal RaptureUiDataModule RaptureUiDataModule;
    [FieldOffset(0x933E8)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x93408)] internal WorldHelper WorldHelper;
    [FieldOffset(0x93448)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x93718)] internal RaptureTeleportHistory RaptureTeleportHistory;
    [FieldOffset(0x937E0)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x93978)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x939F8)] internal PvpSetModule PvpSetModule;
    // [FieldOffset(0x93A70)] internal Vf40Struct;
    // [FieldOffset(0x93A80)] internal Vf41Struct;
    [FieldOffset(0x93A90)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x93C10)] internal MinionListModule MinionListModule;
    [FieldOffset(0x93CB0)] internal MountListModule MountListModule;
    // [FieldOffset(0x93D50)] internal EmjModule EmjModule;
    [FieldOffset(0x93E20)] internal AozNoteModule AozNoteModule;
    // [FieldOffset(0x94B50)] internal CrossworldLinkShellModule CrossworldLinkShellModule;
    [FieldOffset(0x95148)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x951E0)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x95320)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x95FA0)] internal ExcelSheetPreloader ExcelSheetPreloader;
    // [FieldOffset(0x95FB0)] internal MycNoteModule MycNoteModule;
    // [FieldOffset(0x96068)] internal OrnamentListModule OrnamentListModule;
    // [FieldOffset(0x960C8)] internal MycItemModule MycItemModule;
    // [FieldOffset(0x961E8)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0x9F4E8)] internal InputTimerModule InputTimerModule;
    // [FieldOffset(0x9F9E0)] internal McAggreModule McAggreModule;
    [FieldOffset(0x9FCA8)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0xA0250)] internal BannerModule BannerModule;
    // [FieldOffset(0xA02A0)] internal AdventureNoteModule AdventureNoteModule;
    // [FieldOffset(0xA0300)] internal AkatsukiNoteModule AkatsukiNoteModule;
    // [FieldOffset(0xA03E8)] internal VVDNoteModule VVDNoteModule;
    [FieldOffset(0xA0458)] internal VVDActionModule VVDActionModule;
    // [FieldOffset(0xA04A8)] internal TOFU;
    // [FieldOffset(0xA04F8)] internal FISHING;
    // [FieldOffset(0xA05B8)] internal ACTION;
    // [FieldOffset(0xA0620)] internal TFILTER;
    // [FieldOffset(0xA07B0)] internal READYC;
    // [FieldOffset(0xA0800)] internal PTRLST;
    // [FieldOffset(0xA08A8)] internal CATSBM;
    // [FieldOffset(0xA0A88)] internal DESCRI;
    // [FieldOffset(0xA0AE0)] internal MJICWSP;
    // [FieldOffset(0xA0C18)] internal PERFORM;
    // [FieldOffset(0xA0C68)] internal MKDSJOB;
    // [FieldOffset(0xA0CC8)] internal MKDLORE;
    // [FieldOffset(0xA0D28)] internal MKDSJN;
    // [FieldOffset(0xA0D88)] internal Vf81Struct;
    [FieldOffset(0xA0E20)] internal ConfigModule ConfigModule;
    [FieldOffset(0xAF950)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xB0BA0)] internal PronounModule PronounModule;

    [FieldOffset(0xB0F50)] internal UI3DModule UI3DModule;
    [FieldOffset(0xC8490)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xF2098)] internal InfoModule InfoModule;
    [FieldOffset(0xF3D10)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xF3D48)] public Utf8String AddonSheetName;

    [FieldOffset(0xF3DB8)] public Utf8String UIColorSheetName;

    [FieldOffset(0xF3E30)] public Utf8String CompletionSheetName;
    [FieldOffset(0xF3E98)] public Utf8String CompletionOpenIconMacro;
    [FieldOffset(0xF3F00)] public Utf8String CompletionCloseIconMacro;
    [FieldOffset(0xF3F68)] public Utf8String NewLineMacro;
    [FieldOffset(0xF3FD0)] public Utf8String LastTalkName;
    [FieldOffset(0xF4038)] public Utf8String LastTalkText;
    [FieldOffset(0xF40A0)] internal UIInputData UIInputData;
    [FieldOffset(0xF4AD0)] internal UIInputModule UIInputModule;
    // [FieldOffset(0xF4BC0)] public Vf79Struct;

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
