using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct UIModuleInterface {
    [VirtualFunction(5)] public partial ExcelModuleInterface* GetExcelModuleInterface();
    [VirtualFunction(6)] public partial RaptureTextModule* GetRaptureTextModule();
    [VirtualFunction(7)] public partial RaptureAtkModule* GetRaptureAtkModule();
    [VirtualFunction(8)] internal partial RaptureAtkModule* GetRaptureAtkModule2();
    [VirtualFunction(9)] public partial RaptureShellModule* GetRaptureShellModule();
    [VirtualFunction(10)] public partial PronounModule* GetPronounModule();
    [VirtualFunction(11)] public partial RaptureLogModule* GetRaptureLogModule();
    [VirtualFunction(12)] public partial RaptureMacroModule* GetRaptureMacroModule();
    [VirtualFunction(13)] public partial RaptureHotbarModule* GetRaptureHotbarModule();
    [VirtualFunction(14)] public partial RaptureGearsetModule* GetRaptureGearsetModule();
    [VirtualFunction(15)] public partial AcquaintanceModule* GetAcquaintanceModule();
    [VirtualFunction(16)] public partial ItemOrderModule* GetItemOrderModule();
    [VirtualFunction(17)] public partial ItemFinderModule* GetItemFinderModule();
    [VirtualFunction(18)] public partial ConfigModule* GetConfigModule();
    [VirtualFunction(19)] public partial AddonConfig* GetAddonConfig();
    [VirtualFunction(20)] public partial UiSavePackModule* GetUiSavePackModule();
    [VirtualFunction(21)] public partial LetterDataModule* GetLetterDataModule();
    [VirtualFunction(22)] public partial RetainerTaskDataModule* GetRetainerTaskDataModule();
    [VirtualFunction(23)] public partial FlagStatusModule* GetFlagStatusModule();
    [VirtualFunction(24)] public partial RecipeFavoriteModule* GetRecipeFavoriteModule();
    // [VirtualFunction(25)] public partial CraftModule* GetCraftModule();
    [VirtualFunction(26)] public partial RaptureUiDataModule* GetRaptureUiDataModule();
    [VirtualFunction(27)] public partial DataCenterHelper* GetDataCenterHelper();
    [VirtualFunction(28)] public partial WorldHelper* GetWorldHelper();
    [VirtualFunction(29)] public partial GoldSaucerModule* GetGoldSaucerModule();
    [VirtualFunction(30)] public partial RaptureTeleportHistory* GetRaptureTeleportHistory();
    [VirtualFunction(31)] public partial ItemContextCustomizeModule* GetItemContextCustomizeModule();
    [VirtualFunction(32)] public partial RecommendEquipModule* GetRecommendEquipModule();
    [VirtualFunction(33)] public partial PvpSetModule* GetPvpSetModule();
    // [VirtualFunction(34)] public partial InfoModule* GetInfoModule(); // new 7.0
    [VirtualFunction(35)] public partial InfoModule* GetInfoModule();
    [VirtualFunction(36)] public partial UIModuleHelpers* GetUIModuleHelpers();
    [VirtualFunction(37)] public partial AgentModule* GetAgentModule();
    [VirtualFunction(38)] public partial AgentHelpers* GetAgentHelpers();
    [VirtualFunction(39)] public partial UI3DModule* GetUI3DModule();
    // [VirtualFunction(40)] public partial Vf40Struct* GetVf40Struct();
    // [VirtualFunction(41)] public partial Vf41Struct* GetVf40Struct();
    [VirtualFunction(42)] public partial EmoteHistoryModule* GetEmoteHistoryModule();
    [VirtualFunction(43)] public partial MinionListModule* GetMinionListModule();
    [VirtualFunction(44)] public partial MountListModule* GetMountListModule();
    // [VirtualFunction(45)] public partial EmjModule* GetEmjModule();
    [VirtualFunction(46)] public partial AozNoteModule* GetAozNoteModule();
    // [VirtualFunction(47)] public partial CrossWorldLinkShellModule* GetCrossWorldLinkShellModule();
    [VirtualFunction(48)] public partial AchievementListModule* GetAchievementListModule();
    [VirtualFunction(49)] public partial GroupPoseModule* GetGroupPoseModule();
    [VirtualFunction(50)] public partial FieldMarkerModule* GetFieldMarkerModule();
    // [VirtualFunction(51)] public partial StdMap* GetUnkStdMap95FC0();
    // [VirtualFunction(52)] public partial MycNoteModule* GetMycNoteModule();
    // [VirtualFunction(53)] public partial OrnamentListModule* GetOrnamentListModule();
    // [VirtualFunction(54)] public partial MycItemModule* GetMycItemModule();
    // [VirtualFunction(55)] public partial GroupPoseStampModule* GetGroupPoseStampModule();
    [VirtualFunction(56)] public partial InputTimerModule* GetInputTimerModule();
    // [VirtualFunction(57)] public partial McAggreModule* GetMcAggreModule();
    [VirtualFunction(58)] public partial RetainerCommentModule* GetRetainerCommentModule();
    [VirtualFunction(59)] public partial BannerModule* GetBannerModule();
    // [VirtualFunction(60)] public partial AdventureNoteModule* GetAdventureNoteModule();
    // [VirtualFunction(61)] public partial AkatsukiNoteModule* GetAkatsukiNoteModule();
    // [VirtualFunction(62)] public partial VVDNoteModule* GetVVDNoteModule();
    [VirtualFunction(63)] public partial VVDActionModule* GetVVDActionModule();
    // [VirtualFunction(64)] public partial TofuModule* GetTofuModule();
    // [VirtualFunction(65)] public partial FishingModule* GetFishingModule();
    // [VirtualFunction(66)] public partial ACTION* GetACTION();
    [VirtualFunction(67)] public partial TermFilterModule* GetTermFilterModule();
    // [VirtualFunction(68)] public partial READYC* GetREADYC();
    [VirtualFunction(69)] public partial PartyRoleListModule* GetPartyRoleListModule();
    // [VirtualFunction(70)] public partial CATSBM* GetCATSBM();
    // [VirtualFunction(71)] public partial DESCRI* GetDESCRI();
    // [VirtualFunction(72)] public partial MJICWSP* GetMJICWSP();
    // [VirtualFunction(73)] public partial PERFORM* GetPERFORM();
    // [VirtualFunction(74)] public partial MKDSJOB* GetMKDSJOB();
    // [VirtualFunction(75)] public partial MKDLORE* GetMKDLORE();
    // [VirtualFunction(76)] public partial MKDSJN* GetMKDSJN();
    [VirtualFunction(77)] public partial UIInputData* GetUIInputData();
    [VirtualFunction(78)] public partial UIInputModule* GetUIInputModule();
    // [VirtualFunction(79)] public partial Vf79Struct* GetVf70Struct();
    [VirtualFunction(80)] public partial LogFilterConfig* GetLogFilterConfig();
    // [VirtualFunction(81)] public partial Vf81Struct* GetVf81Struct();
    // [VirtualFunction(82)] public partial void EnableCutsceneInputMode();
    // [VirtualFunction(83)] public partial void DisableCutsceneInputMode();

    [VirtualFunction(88)] public partial bool EnterGPose();
    [VirtualFunction(89)] public partial void ExitGPose();
    [VirtualFunction(90)] public partial bool IsInGPose();
    [VirtualFunction(91)] public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);
    [VirtualFunction(92)] public partial void ExitIdleCam();
    [VirtualFunction(93)] public partial bool IsInIdleCam();
    [VirtualFunction(99)] public partial void ShowDeepDungeonHud();
    [VirtualFunction(100)] public partial void HideDeepDungeonHud();
    [VirtualFunction(102)] public partial void ShowEurekaHud();
    [VirtualFunction(103)] public partial void HideEurekaHud();

    // [VirtualFunction(109)] public partial ??? CloseMiniMap(???);
    // [VirtualFunction(110)] public partial ??? OpenMiniMap(???);
    // [VirtualFunction(111)] public partial ??? IsGamePadInputActive(???);

    // [VirtualFunction(114)] public partial ??? ToggleInputMode(???);
    [VirtualFunction(115)] public partial void CancelDragDrop(bool condition = true); // doesn't do anything when false is passed
    // [VirtualFunction(116)] public partial ??? IsUIHidden(???);
    [VirtualFunction(117)] public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);
    [VirtualFunction(118)] public partial void ClearAtkHistory(int historyIdx);

    [VirtualFunction(121)] public partial void HandlePacket(UIModulePacketType type, uint uintParam, void* packet);
    // [VirtualFunction(122)] public partial ??? ShowContentIntroduction(???);
    // [VirtualFunction(123)] public partial ??? IsContentIntroductionInvisible(???);
    // [VirtualFunction(124)] public partial ??? HideContentIntroduction(???);
    [VirtualFunction(135)] public partial void SetCursorVisibility(bool visible);
    // [VirtualFunction(136)] public partial ??? ToggleCursor(???);
    // [VirtualFunction(150)] public partial ??? ShowEventFadeIn(???);
    // [VirtualFunction(151)] public partial ??? ShowEventFadeOut(???);
    [VirtualFunction(155)] public partial void ToggleUi(UIModule.UiFlags flags, bool enable, bool unknown = true);
    // [VirtualFunction(156)] public partial ??? ToggleUi_2(???);
    // [VirtualFunction(158)] public partial ??? LoadScreenHideUi(???);
    // [VirtualFunction(159)] public partial ??? LoadScreenShowUi(???);
    // [VirtualFunction(161)] public partial ??? AnnounceHowTo(???);
    // [VirtualFunction(163)] public partial ??? HideHowTo(???);
    [VirtualFunction(165)] public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);
    [VirtualFunction(166)] public partial void HideGoldSaucerReward();
    // [VirtualFunction(167)] public partial ??? HideGoldSaucerReward_2(???);
    [VirtualFunction(172)] public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);
    // [VirtualFunction(174)] public partial ??? OpenMiniGame(???);
    // [VirtualFunction(175)] public partial ??? HideHousingHarvest(???);
    [VirtualFunction(176)] public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);

    // 7.2: everything after not checked yet
    [VirtualFunction(177), GenerateStringOverloads] public partial void ShowText(int position, CStringPointer text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);
    [VirtualFunction(178)] public partial void ShowTextChain(int chain, int hqChain = 0);
    [VirtualFunction(179), GenerateStringOverloads] public partial void ShowWideText(CStringPointer text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);
    [VirtualFunction(180), GenerateStringOverloads] public partial void ShowPoisonText(CStringPointer text, int layer = 0);
    [VirtualFunction(181), GenerateStringOverloads] public partial void ShowErrorText(CStringPointer text, bool forceVisible = true);
    [VirtualFunction(182)] public partial void ShowTextClassChange(uint classJobId);
    [VirtualFunction(183)] public partial void ShowGetAction(ActionType actionType, uint actionId);
    [VirtualFunction(184)] public partial void ShowLocationTitle(uint territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);
    // [VirtualFunction(185)] public partial ??? HideLocationTitle(???);
    [VirtualFunction(188)] public partial void ShowGrandCompanyRankUp(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(191)] public partial void ShowStreak(int streak, int streakType);
    [VirtualFunction(192)] public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);
    [VirtualFunction(193)] public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!
    [VirtualFunction(194), GenerateStringOverloads] public partial void ShowBattleTalk(CStringPointer name, CStringPointer text, float duration, byte style);
    [VirtualFunction(195), GenerateStringOverloads] public partial void ShowBattleTalkImage(CStringPointer name, CStringPointer text, float duration, uint image, byte style, int sound = -1, uint entityId = 0xE0000000);
    // [VirtualFunction(196)] public partial ??? ShowBattleTalkUnknown(???);
    [VirtualFunction(197), GenerateStringOverloads] public partial void ShowBattleTalkSound(CStringPointer name, CStringPointer text, float duration, int sound, byte style);
    /// <param name="type">0 = Inventory, 1 = Key Items</param>
    [VirtualFunction(199)] public partial void OpenInventory(byte type = 0);
    [VirtualFunction(200)] public partial void CloseInventory();
    [VirtualFunction(201)] public partial bool IsInventoryOpen();
    [VirtualFunction(202)] public partial void ExecuteMainCommand(uint command);
    [VirtualFunction(203)] public partial bool IsMainCommandUnlocked(uint command);
    // [VirtualFunction(206)] public partial ??? ShowRaceCountdownEnd(???);
    // [VirtualFunction(210)] public partial ??? IsDutyRaidFinderOpen(???);
    [VirtualFunction(212)] public partial void ShowTalkSubtitle(Utf8String* text, float duration);
    [VirtualFunction(213)] public partial void HideTalkSubtitle();
    [VirtualFunction(216)] public partial void ShowAdventureNotice(int index);
    [VirtualFunction(220)] public partial int RotateLinkshellHistory(int offset);
    [VirtualFunction(221)] public partial void SetLinkshellCycle(int linkshellCycle);
    [VirtualFunction(222)] public partial int RotateCrossLinkshellHistory(int offset);
    // [VirtualFunction(238)] public partial ??? ShowRaceCountdownStart(???);
    // [VirtualFunction(239)] public partial ??? ShowRaceCountdownEnd_2(???);
}

public enum UIModulePacketType {
    ClassJobChange = 2,
    LevelChange = 3,
    ShowLogMessage = 4,
    Login = 6,
    Logout = 7,
    CloseLogoutDialog = 8,
    StartLogoutCountdown = 9,
    PrintPlayTime = 11,
}
