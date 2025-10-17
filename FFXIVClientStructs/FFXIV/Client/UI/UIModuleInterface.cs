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
    [VirtualFunction(25)] public partial CraftModule* GetCraftModule();
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
    [VirtualFunction(40)] public partial ExtraCommandHelper* GetExtraCommandHelper();
    [VirtualFunction(41)] public partial JobHudManualHelper* GetJobHudManualHelper();
    [VirtualFunction(42)] public partial EmoteHistoryModule* GetEmoteHistoryModule();
    [VirtualFunction(43)] public partial MinionListModule* GetMinionListModule();
    [VirtualFunction(44)] public partial MountListModule* GetMountListModule();
    [VirtualFunction(45)] public partial EmjModule* GetEmjModule();
    [VirtualFunction(46)] public partial AozNoteModule* GetAozNoteModule();
    [VirtualFunction(47)] public partial CrossWorldLinkShellModule* GetCrossWorldLinkShellModule();
    [VirtualFunction(48)] public partial AchievementListModule* GetAchievementListModule();
    [VirtualFunction(49)] public partial GroupPoseModule* GetGroupPoseModule();
    [VirtualFunction(50)] public partial FieldMarkerModule* GetFieldMarkerModule();
    // [VirtualFunction(51)] public partial StdMap* GetUnkStdMap95FC0();
    [VirtualFunction(52)] public partial MycNoteModule* GetMycNoteModule();
    [VirtualFunction(53)] public partial OrnamentListModule* GetOrnamentListModule();
    [VirtualFunction(54)] public partial MycItemModule* GetMycItemModule();
    [VirtualFunction(55)] public partial GroupPoseStampModule* GetGroupPoseStampModule();
    [VirtualFunction(56)] public partial InputTimerModule* GetInputTimerModule();
    [VirtualFunction(57)] public partial McAggreModule* GetMcAggreModule();
    [VirtualFunction(58)] public partial RetainerCommentModule* GetRetainerCommentModule();
    [VirtualFunction(59)] public partial BannerModule* GetBannerModule();
    [VirtualFunction(60)] public partial AdventureNoteModule* GetAdventureNoteModule();
    [VirtualFunction(61)] public partial AkatsukiNoteModule* GetAkatsukiNoteModule();
    [VirtualFunction(62)] public partial VVDNotebookModule* GetVVDNotebookModule();
    [VirtualFunction(63)] public partial VVDActionModule* GetVVDActionModule();
    [VirtualFunction(64)] public partial TofuModule* GetTofuModule();
    [VirtualFunction(65)] public partial FishingModule* GetFishingModule();
    [VirtualFunction(66)] public partial ActionModule* GetActionModule();
    [VirtualFunction(67)] public partial TermFilterModule* GetTermFilterModule();
    [VirtualFunction(68)] public partial ReadyCheckModule* GetReadyCheckModule();
    [VirtualFunction(69)] public partial PartyRoleListModule* GetPartyRoleListModule();
    [VirtualFunction(70)] public partial CatalogSearchBookmarkModule* GetCatalogSearchBookmarkModule();
    [VirtualFunction(71)] public partial DescriptionModule* GetDescriptionModule();
    [VirtualFunction(72)] public partial MJICraftworksPresetModule* GetMJICraftworksPresetModule();
    [VirtualFunction(73)] public partial PerformanceModule* GetPerformanceModule();
    [VirtualFunction(74)] public partial MKDSupportJobModule* GetMKDSupportJobModule();
    [VirtualFunction(75)] public partial MKDLoreModule* GetMKDLoreModule();
    [VirtualFunction(76)] public partial MKDSupportJobNoteModule* GetMKDSupportJobNoteModule();
    // [VirtualFunction(77)] public partial QPNL* GetQPNL();
    [VirtualFunction(78)] public partial UIInputData* GetUIInputData();
    [VirtualFunction(79)] public partial UIInputModule* GetUIInputModule();
    // [VirtualFunction(80)] public partial Vf79Struct* GetVf70Struct();
    [VirtualFunction(81)] public partial LogFilterConfig* GetLogFilterConfig();
    // [VirtualFunction(82)] public partial Vf81Struct* GetVf81Struct();
    // [VirtualFunction(83)] public partial void EnableCutsceneInputMode();
    // [VirtualFunction(84)] public partial void DisableCutsceneInputMode();

    [VirtualFunction(89)] public partial bool EnterGPose();
    [VirtualFunction(90)] public partial void ExitGPose();
    [VirtualFunction(91)] public partial bool IsInGPose();
    [VirtualFunction(92)] public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);
    [VirtualFunction(93)] public partial void ExitIdleCam();
    [VirtualFunction(94)] public partial bool IsInIdleCam();
    [VirtualFunction(100)] public partial void ShowDeepDungeonHud();
    [VirtualFunction(101)] public partial void HideDeepDungeonHud();
    [VirtualFunction(103)] public partial void ShowEurekaHud();
    [VirtualFunction(104)] public partial void HideEurekaHud();

    // [VirtualFunction(110)] public partial ??? CloseMiniMap(???);
    // [VirtualFunction(111)] public partial ??? OpenMiniMap(???);
    [VirtualFunction(112)] public partial bool IsPadModeEnabled();
    [VirtualFunction(113)] public partial bool IsPadMouseModeEnabled();

    [VirtualFunction(115)] public partial bool SetPadMode(bool enable);
    [VirtualFunction(116)] public partial void CancelDragDrop(bool condition = true); // doesn't do anything when false is passed
    // [VirtualFunction(117)] public partial ??? IsUIHidden(???);
    [VirtualFunction(118)] public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);
    [VirtualFunction(119)] public partial void ClearAtkHistory(int historyIdx);
    [VirtualFunction(120)] public partial bool IsPerforming();

    [VirtualFunction(122)] public partial void HandlePacket(UIModulePacketType type, uint uintParam, void* packet);

    // TODO: Not checked after 7.3, just blindly +1'd, but all seem correct.

    // [VirtualFunction(123)] public partial ??? ShowContentIntroduction(???);
    // [VirtualFunction(124)] public partial ??? IsContentIntroductionInvisible(???);
    // [VirtualFunction(125)] public partial ??? HideContentIntroduction(???);
    [VirtualFunction(136)] public partial void SetCursorVisibility(bool visible);
    // [VirtualFunction(137)] public partial ??? ToggleCursor(???);
    // [VirtualFunction(151)] public partial ??? ShowEventFadeIn(???);
    // [VirtualFunction(152)] public partial ??? ShowEventFadeOut(???);
    [VirtualFunction(156)] public partial void ToggleUi(UIModule.UiFlags flags, bool enable, bool unknown = true);
    // [VirtualFunction(157)] public partial ??? ToggleUi_2(???);
    // [VirtualFunction(159)] public partial ??? LoadScreenHideUi(???);
    // [VirtualFunction(160)] public partial ??? LoadScreenShowUi(???);
    // [VirtualFunction(162)] public partial ??? AnnounceHowTo(???);
    // [VirtualFunction(164)] public partial ??? HideHowTo(???);
    [VirtualFunction(166)] public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);
    [VirtualFunction(167)] public partial void HideGoldSaucerReward();
    // [VirtualFunction(168)] public partial ??? HideGoldSaucerReward_2(???);
    [VirtualFunction(173)] public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);
    // [VirtualFunction(175)] public partial ??? OpenMiniGame(???);
    // [VirtualFunction(176)] public partial ??? HideHousingHarvest(???);
    [VirtualFunction(177)] public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);

    // 7.2: everything after not checked yet
    [VirtualFunction(178), GenerateStringOverloads] public partial void ShowText(int position, CStringPointer text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);
    [VirtualFunction(179)] public partial void ShowTextChain(int chain, int hqChain = 0);
    [VirtualFunction(180), GenerateStringOverloads] public partial void ShowWideText(CStringPointer text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);
    [VirtualFunction(181), GenerateStringOverloads] public partial void ShowPoisonText(CStringPointer text, int layer = 0);
    [VirtualFunction(182), GenerateStringOverloads] public partial void ShowErrorText(CStringPointer text, bool forceVisible = true);
    [VirtualFunction(183)] public partial void ShowTextClassChange(uint classJobId);
    [VirtualFunction(184)] public partial void ShowGetAction(ActionType actionType, uint actionId);
    [VirtualFunction(185)] public partial void ShowLocationTitle(uint territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);
    // [VirtualFunction(186)] public partial ??? HideLocationTitle(???);
    [VirtualFunction(189)] public partial void ShowGrandCompanyRankUp(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(192)] public partial void ShowStreak(int streak, int streakType);
    [VirtualFunction(193)] public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);
    [VirtualFunction(194)] public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!
    [VirtualFunction(195), GenerateStringOverloads] public partial void ShowBattleTalk(CStringPointer name, CStringPointer text, float duration, byte style);
    [VirtualFunction(196), GenerateStringOverloads] public partial void ShowBattleTalkImage(CStringPointer name, CStringPointer text, float duration, uint image, byte style, int sound = -1, uint entityId = 0xE0000000);
    // [VirtualFunction(197)] public partial ??? ShowBattleTalkUnknown(???);
    [VirtualFunction(198), GenerateStringOverloads] public partial void ShowBattleTalkSound(CStringPointer name, CStringPointer text, float duration, int sound, byte style);
    /// <param name="type">0 = Inventory, 1 = Key Items</param>
    [VirtualFunction(200)] public partial void OpenInventory(byte type = 0);
    [VirtualFunction(201)] public partial void CloseInventory();
    [VirtualFunction(202)] public partial bool IsInventoryOpen();
    [VirtualFunction(203)] public partial void ExecuteMainCommand(uint command);
    [VirtualFunction(204)] public partial bool IsMainCommandUnlocked(uint command);
    // [VirtualFunction(207)] public partial ??? ShowRaceCountdownEnd(???);
    // [VirtualFunction(211)] public partial ??? IsDutyRaidFinderOpen(???);
    [VirtualFunction(213)] public partial void ShowTalkSubtitle(Utf8String* text, float duration);
    [VirtualFunction(214)] public partial void HideTalkSubtitle();
    [VirtualFunction(217)] public partial void ShowAdventureNotice(int index);
    [VirtualFunction(220)] public partial void SetLinkshellCycle(int linkshellCycle);
    [VirtualFunction(221)] public partial int RotateLinkshellHistory(int offset);
    [VirtualFunction(222)] public partial void SetCrossWorldLinkshellCycle(int crossWorldLinkshellCycle);
    [VirtualFunction(223)] public partial int RotateCrossLinkshellHistory(int offset);
    // [VirtualFunction(239)] public partial ??? ShowRaceCountdownStart(???);
    // [VirtualFunction(240)] public partial ??? ShowRaceCountdownEnd_2(???);

    [VirtualFunction(245)] public partial bool ShouldLimitFps();
}

public enum UIModulePacketType {
    ClassJobChange = 2,
    LevelChange = 3,
    ShowLogMessage = 4,
    Login = 6,
    Logout = 7,
    CloseLogoutDialog = 8,
    StartLogoutCountdown = 9,
    UnlockedMapMarkersUpdated = 10,
    PrintPlayTime = 11,
}
