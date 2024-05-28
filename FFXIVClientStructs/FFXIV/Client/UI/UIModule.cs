using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using FFXIVClientStructs.FFXIV.Component.Completion;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIModule
//   Client::UI::UIModuleInterface
[GenerateInterop, Inherits<UIModuleInterface>, Inherits<ChangeEventInterface>(0x18)]
[StructLayout(LayoutKind.Explicit, Size = 0xEE030)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 61 ?? 4C 8B F2", 3)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() => Framework.Instance()->GetUiModule();

    [FieldOffset(0x8)] public void** AtkModuleEvent;
    [FieldOffset(0x10)] public void** ExcelLanguageEvent;

    [FieldOffset(0x3B0), FixedSizeArray] internal FixedSizeArray19<RaptureAtkHistory> _atkHistory;
    [FieldOffset(0x7D8)] public int LinkshellCycle;
    [FieldOffset(0x7DC)] public int CrossWorldLinkshellCycle;

    [FieldOffset(0x7E4)] public uint FrameCount;
    [FieldOffset(0x7E8)] internal ExcelModule* ExcelModule;
    [FieldOffset(0x7F0)] internal RaptureTextModule RaptureTextModule;
    [FieldOffset(0x1650)] internal CompletionModule CompletionModule;
    [FieldOffset(0x19C8)] internal RaptureLogModule RaptureLogModule;
    // [FieldOffset(0x4E50)] internal UserFileManager UserFileManager;
    [FieldOffset(0x4E70)] internal RaptureMacroModule RaptureMacroModule;
    [FieldOffset(0x56918)] internal RaptureHotbarModule RaptureHotbarModule;
    [FieldOffset(0x7F210)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8A880)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8B978)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8BA50)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x8CC20)] internal AddonConfig AddonConfig;
    [FieldOffset(0x8CC88)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x8D1B0)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x8D200)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x8DC48)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x8DCF8)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x8DFA0)] internal RecipeFavoriteModule RecipeFavoriteModule;
    // [FieldOffset(0x8E128)] internal CraftModule CraftModule;
    [FieldOffset(0x8E180)] internal RaptureUiDataModule RaptureUiDataModule;
    [FieldOffset(0x93C68)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x93C88)] internal WorldHelper WorldHelper;
    [FieldOffset(0x93CC8)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x93F90)] internal RaptureTeleportHistory RaptureTeleportHistory;
    [FieldOffset(0x94050)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x941E0)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x94260)] internal PvpSetModule PvpSetModule;
    // [FieldOffset(0x942F8)] internal Vf39Struct;
    // [FieldOffset(0x94308)] internal Vf40Struct;
    [FieldOffset(0x94318)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x94490)] internal MinionListModule MinionListModule;
    [FieldOffset(0x94528)] internal MountListModule MountListModule;
    // [FieldOffset(0x945C0)] internal EmjModule EmjModule;
    [FieldOffset(0x94680)] internal AozNoteModule AozNoteModule;
    // [FieldOffset(0x953A8)] internal CrossworldLinkShellModule CrossworldLinkShellModule;
    [FieldOffset(0x95998)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x95A20)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x95B50)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x967C8)] UnkStdMap967C8?
    // [FieldOffset(0x967D8)] internal MycNoteModule MycNoteModule;
    // [FieldOffset(0x96888)] internal OrnamentListModule OrnamentListModule;
    // [FieldOffset(0x968E0)] internal MycItemModule MycItemModule;
    // [FieldOffset(0x969F8)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0x9FCF0)] internal InputTimerModule InputTimerModule;
    // [FieldOffset(0xA01E8)] internal McAggreModule McAggreModule;
    [FieldOffset(0xA0490)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0xA0A30)] internal BannerModule BannerModule;
    // [FieldOffset(0xA0A78)] internal AdventureNoteModule AdventureNoteModule;
    // [FieldOffset(0xA0AD0)] internal AkatsukiNoteModule AkatsukiNoteModule;
    // [FieldOffset(0xA0BB0)] internal VVDNoteModule VVDNoteModule;
    [FieldOffset(0xA0C18)] internal VVDActionModule VVDActionModule;
    // [FieldOffset(0xA0C60)] internal TofuModule TofuModule;
    // [FieldOffset(0xA0CA8)] internal FishingModule FishingModule;
    // [FieldOffset(0xA0D60)] internal Vf69Struct;
    [FieldOffset(0xA0DF8)] internal ConfigModule ConfigModule;
    [FieldOffset(0xAF3C0)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xB05C8)] internal PronounModule PronounModule;

    [FieldOffset(0xB0980)] internal UI3DModule UI3DModule;
    [FieldOffset(0xC2560)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xEB4F8)] internal InfoModule InfoModule;
    [FieldOffset(0xED168)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xED178)] internal Utf8String AddonSheetName;

    [FieldOffset(0xED1E8)] internal Utf8String UIColorSheetName;

    [FieldOffset(0xED260)] internal Utf8String CompletionSheetName;
    [FieldOffset(0xED2C8)] internal Utf8String UnkED2C8;
    [FieldOffset(0xED330)] internal Utf8String UnkED330;
    [FieldOffset(0xED398)] internal Utf8String UnkED398;
    [FieldOffset(0xED400)] public Utf8String LastTalkName;
    [FieldOffset(0xED468)] public Utf8String LastTalkText;
    [FieldOffset(0xED4D0)] internal UIInputData UIInputData;
    [FieldOffset(0xEDEF0)] internal UIInputModule UIInputModule;
    // [FieldOffset(0xEDFE0)] internal Vf67Struct;

    [MemberFunction("E8 ?? ?? ?? ?? 4D 39 BE")]
    public static partial bool PlaySound(uint effectId, long a2 = 0, long a3 = 0, byte a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 BF 4C 8B CB"), GenerateStringOverloads]
    public static partial bool IsPlayerCharacterName(byte* name);

    public static void PlayChatSoundEffect(uint effectId) {
        if (effectId is < 1 or > 16)
            throw new ArgumentException("Valid chat sfx values are 1 through 16.");

        PlaySound(effectId + 0x24u, 0, 0, 0);
    }

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
}
