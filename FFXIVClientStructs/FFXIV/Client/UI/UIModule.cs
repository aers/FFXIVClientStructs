using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIModule
//   Client::UI::UIModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0xEE030)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 4C 89 61 ?? 4C 8B F2", 3)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() => Framework.Instance()->GetUiModule();

    [FieldOffset(0x0), Obsolete("Use UIModule.StaticAddressPointers.VTable")] public void* vtbl;
    [FieldOffset(0x0), Obsolete("Use UIModule.StaticAddressPointers.VTable")] public void** vfunc;
    [FieldOffset(0x8)] public void** AtkModuleEvent;
    [FieldOffset(0x10)] public void** ExcelLanguageEvent;
    [FieldOffset(0x18)] public ChangeEventInterface ChangeEventInterface;
    /*
        dq 0                                    ; +0x30
        dq 23000000000h                         ; +0x38
        dq 0                                    ; +0x40
        dq 23000000000h                         ; +0x48
        dq 0                                    ; +0x50
        and so on...
    */

    [FixedSizeArray<RaptureAtkHistory>(19)]
    [FieldOffset(0x3B0)] public fixed byte AtkHistory[19 * 0x38];

    [FieldOffset(0x7E4)] public uint FrameCount;
    [FieldOffset(0x7E8)] internal ExcelModule* ExcelModule;
    [FieldOffset(0x7F0)] internal RaptureTextModule RaptureTextModule;
    // [FieldOffset(0x1650)] internal CompletionModule CompletionModule;
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

    [VirtualFunction(5)]
    public partial ExcelModuleInterface* GetExcelModule();

    [VirtualFunction(6)]
    public partial RaptureTextModule* GetRaptureTextModule();

    [VirtualFunction(7)]
    public partial RaptureAtkModule* GetRaptureAtkModule();

    [VirtualFunction(8)]
    internal partial RaptureAtkModule* GetRaptureAtkModule2();

    [VirtualFunction(9)]
    public partial RaptureShellModule* GetRaptureShellModule();

    [VirtualFunction(10)]
    public partial PronounModule* GetPronounModule();

    [VirtualFunction(11)]
    public partial RaptureLogModule* GetRaptureLogModule();

    [VirtualFunction(12)]
    public partial RaptureMacroModule* GetRaptureMacroModule();

    [VirtualFunction(13)]
    public partial RaptureHotbarModule* GetRaptureHotbarModule();

    [VirtualFunction(14)]
    public partial RaptureGearsetModule* GetRaptureGearsetModule();

    [VirtualFunction(15)]
    public partial AcquaintanceModule* GetAcquaintanceModule();

    [VirtualFunction(16)]
    public partial ItemOrderModule* GetItemOrderModule();

    [VirtualFunction(17)]
    public partial ItemFinderModule* GetItemFinderModule();

    [VirtualFunction(18)]
    public partial ConfigModule* GetConfigModule();

    [VirtualFunction(19)]
    public partial AddonConfig* GetAddonConfig();

    [VirtualFunction(20)]
    public partial UiSavePackModule* GetUiSavePackModule();

    [VirtualFunction(21)]
    public partial LetterDataModule* GetLetterDataModule();

    [VirtualFunction(22)]
    public partial RetainerTaskDataModule* GetRetainerTaskDataModule();

    [VirtualFunction(23)]
    public partial FlagStatusModule* GetFlagStatusModule();

    [VirtualFunction(24)]
    public partial RecipeFavoriteModule* GetRecipeFavoriteModule();

    // [VirtualFunction(25)]
    // public partial CraftModule* GetCraftModule();

    [VirtualFunction(26)]
    public partial RaptureUiDataModule* GetRaptureUiDataModule();

    [VirtualFunction(27)]
    public partial DataCenterHelper* GetDataCenterHelper();

    [VirtualFunction(28)]
    public partial WorldHelper* GetWorldHelper();

    [VirtualFunction(29)]
    public partial GoldSaucerModule* GetGoldSaucerModule();

    [VirtualFunction(30)]
    public partial RaptureTeleportHistory* GetRaptureTeleportHistory();

    [VirtualFunction(31)]
    public partial ItemContextCustomizeModule* GetItemContextCustomizeModule();

    [VirtualFunction(32)]
    public partial RecommendEquipModule* GetRecommendEquipModule();

    [VirtualFunction(33)]
    public partial PvpSetModule* GetPvpSetModule();

    [VirtualFunction(34)]
    public partial InfoModule* GetInfoModule();

    [VirtualFunction(35)]
    public partial UIModuleHelpers* GetUIModuleHelpers();

    [VirtualFunction(36)]
    public partial AgentModule* GetAgentModule();

    // [VirtualFunction(37)]
    // public partial UIModule* GetAfterAgentsPtr(); // points to the field right after the last Agent in AgentModule

    [VirtualFunction(38)]
    public partial UI3DModule* GetUI3DModule();

    // [VirtualFunction(39)]
    // public partial Vf39Struct* GetVf39Struct();

    // [VirtualFunction(40)]
    // public partial Vf40Struct* GetVf40Struct();

    [VirtualFunction(41)]
    public partial EmoteHistoryModule* GetEmoteHistoryModule();

    [VirtualFunction(42)]
    public partial MinionListModule* GetMinionListModule();

    [VirtualFunction(43)]
    public partial MountListModule* GetMountListModule();

    // [VirtualFunction(44)]
    // public partial EmjModule* GetEmjModule();

    [VirtualFunction(45)]
    public partial AozNoteModule* GetAozNoteModule();

    // [VirtualFunction(46)]
    // public partial CrossWorldLinkShellModule* GetCrossWorldLinkShellModule();

    [VirtualFunction(47)]
    public partial AchievementListModule* GetAchievementListModule();

    [VirtualFunction(48)]
    public partial GroupPoseModule* GetGroupPoseModule();

    [VirtualFunction(49)]
    public partial FieldMarkerModule* GetFieldMarkerModule();

    // [VirtualFunction(50)]
    // public partial StdMap* GetUnkStdMap967C8();

    // [VirtualFunction(51)]
    // public partial MycNoteModule* GetMycNoteModule();

    // [VirtualFunction(52)]
    // public partial OrnamentListModule* GetOrnamentListModule();

    // [VirtualFunction(53)]
    // public partial MycItemModule* GetMycItemModule();

    // [VirtualFunction(54)]
    // public partial GroupPoseStampModule* GetGroupPoseStampModule();

    [VirtualFunction(55)]
    public partial InputTimerModule* GetInputTimerModule();

    // [VirtualFunction(56)]
    // public partial McAggreModule* GetMcAggreModule();

    [VirtualFunction(57)]
    public partial RetainerCommentModule* GetRetainerCommentModule();

    [VirtualFunction(58)]
    public partial BannerModule* GetBannerModule();

    // [VirtualFunction(59)]
    // public partial AdventureNoteModule* GetAdventureNoteModule();

    // [VirtualFunction(60)]
    // public partial AkatsukiNoteModule* GetAkatsukiNoteModule();

    // [VirtualFunction(61)]
    // public partial VVDNoteModule* GetVVDNoteModule();

    [VirtualFunction(62)]
    public partial VVDActionModule* GetVVDActionModule();

    // [VirtualFunction(63)]
    // public partial TofuModule* GetTofuModule();

    // [VirtualFunction(64)]
    // public partial FishingModule* GetFishingModule();

    [VirtualFunction(65)]
    public partial UIInputData* GetUIInputData();

    [VirtualFunction(66)]
    public partial UIInputModule* GetUIInputModule();

    // [VirtualFunction(67)]
    // public partial Vf67Struct* GetVf67Struct();

    [VirtualFunction(68)]
    public partial LogFilterConfig* GetLogFilterConfig();

    // [VirtualFunction(69)]
    // public partial Vf69Struct* GetVf69Struct();

    // [VirtualFunction(70)]
    // public partial void EnableCutsceneInputMode();

    // [VirtualFunction(71)]
    // public partial void DisableCutsceneInputMode();

    [VirtualFunction(76)]
    public partial bool EnterGPose();

    [VirtualFunction(77)]
    public partial void ExitGPose();

    [VirtualFunction(78)]
    public partial bool IsInGPose();

    [VirtualFunction(79)]
    public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);

    [VirtualFunction(80)]
    public partial void ExitIdleCam();

    [VirtualFunction(81)]
    public partial bool IsInIdleCam();

    [VirtualFunction(90)]
    public partial void ShowEurekaHud();

    [VirtualFunction(91)]
    public partial void HideEurekaHud();

    [VirtualFunction(107)]
    public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);

    [VirtualFunction(108)]
    public partial void ClearAtkHistory(int historyIdx);

    [VirtualFunction(143)]
    public partial void ToggleUi(UiFlags flags, bool enable, bool unknown = true);

    [VirtualFunction(153)]
    public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);

    [VirtualFunction(154)]
    public partial void HideGoldSaucerReward();

    [VirtualFunction(155)]
    public partial void ShowTextRelicAtma(uint itemId);

    [VirtualFunction(163)]
    public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);

    [VirtualFunction(167)]
    public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);

    [VirtualFunction(168)]
    [GenerateCStrOverloads]
    public partial void ShowText(int position, byte* text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);

    [VirtualFunction(169)]
    public partial void ShowTextChain(int chain, int hqChain = 0);

    [VirtualFunction(170)]
    [GenerateCStrOverloads]
    public partial void ShowAreaText(byte* text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);

    [VirtualFunction(171)]
    [GenerateCStrOverloads]
    public partial void ShowPoisonText(byte* text, int layer = 0);

    [VirtualFunction(172)]
    [GenerateCStrOverloads]
    public partial void ShowErrorText(byte* text, bool forceVisible = true);

    [VirtualFunction(173)]
    public partial void ShowTextClassChange(uint classJobId);

    [VirtualFunction(174)]
    public partial void ShowGetAction(ActionType actionType, uint actionId);

    [VirtualFunction(175)]
    public partial void ShowLocationTitle(int territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);

    [VirtualFunction(179)]
    public partial void ShowGrandCompany1(uint gc, uint gcRank, bool playSound = true);

    [VirtualFunction(182)]
    public partial void ShowStreak(int streak, int streakType);

    [VirtualFunction(183)]
    public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);

    [VirtualFunction(184)]
    public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!

    [VirtualFunction(185)]
    [GenerateCStrOverloads]
    public partial void ShowBattleTalk(byte* name, byte* text, float duration, byte style);

    [VirtualFunction(186)]
    [GenerateCStrOverloads]
    public partial void ShowBattleTalkImage(byte* name, byte* text, float duration, uint image, byte style);

    [VirtualFunction(188)]
    [GenerateCStrOverloads]
    public partial void ShowBattleTalkSound(byte* name, byte* text, float duration, int sound, byte style);

    [VirtualFunction(193)]
    public partial void ExecuteMainCommand(uint command);

    [VirtualFunction(194)]
    public partial bool IsMainCommandUnlocked(uint command);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 39 BE")]
    public static partial bool PlaySound(uint effectId, long a2 = 0, long a3 = 0, byte a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 BF 4C 8B CB")]
    [GenerateCStrOverloads]
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
