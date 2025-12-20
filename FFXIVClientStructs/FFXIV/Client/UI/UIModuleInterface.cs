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
    [VirtualFunction(4)] public partial void ExitGame();
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
    [VirtualFunction(26)] public partial UiDataModule* GetUiDataModule();
    [VirtualFunction(27)] public partial DataCenterHelper* GetDataCenterHelper();
    [VirtualFunction(28)] public partial WorldHelper* GetWorldHelper();
    [VirtualFunction(29)] public partial GoldSaucerModule* GetGoldSaucerModule();
    [VirtualFunction(30)] public partial TeleportHistoryModule* GetTeleportHistoryModule();
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
    // [VirtualFunction(51)] private partial StdMap* GetUnkStdMap95FC0();
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
    [VirtualFunction(77)] public partial QuickPanelModule* GetQuickPanelModule();
    [VirtualFunction(78)] public partial GlassesModule* GetGlassesModule();
    [VirtualFunction(79)] public partial UIInputData* GetUIInputData();
    [VirtualFunction(80)] public partial UIInputModule* GetUIInputModule();
    // [VirtualFunction(81)] public partial Vf79Struct* GetVf70Struct();
    [VirtualFunction(82)] public partial LogFilterConfig* GetLogFilterConfig();
    // [VirtualFunction(83)] public partial Vf81Struct* GetVf81Struct();
    // [VirtualFunction(84)] public partial void EnableCutsceneInputMode();
    // [VirtualFunction(85)] public partial void DisableCutsceneInputMode();

    [VirtualFunction(90)] public partial bool EnterGPose();
    [VirtualFunction(91)] public partial void ExitGPose();
    [VirtualFunction(92)] public partial bool IsInGPose();
    [VirtualFunction(93)] public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);
    [VirtualFunction(94)] public partial void ExitIdleCam();
    [VirtualFunction(95)] public partial bool IsInIdleCam();
    [VirtualFunction(101)] public partial void ShowDeepDungeonHud();
    [VirtualFunction(102)] public partial void HideDeepDungeonHud();
    [VirtualFunction(104)] public partial void ShowEurekaHud();
    [VirtualFunction(105)] public partial void HideEurekaHud();

    // [VirtualFunction(111)] public partial ??? CloseMiniMap(???);
    // [VirtualFunction(112)] public partial ??? OpenMiniMap(???);
    [VirtualFunction(113)] public partial bool IsPadModeEnabled();
    [VirtualFunction(114)] public partial bool IsPadMouseModeEnabled();

    [VirtualFunction(116)] public partial bool SetPadMode(bool enable);
    [VirtualFunction(117)] public partial void CancelDragDrop(bool condition = true); // doesn't do anything when false is passed
    // [VirtualFunction(118)] public partial ??? IsUIHidden(???);
    [VirtualFunction(119)] public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);
    [VirtualFunction(120)] public partial void ClearAtkHistory(int historyIdx);
    [VirtualFunction(121)] public partial bool IsPerforming();

    [VirtualFunction(123)] public partial void HandlePacket(UIModulePacketType type, uint uintParam, void* packet);

    // [VirtualFunction(124)] public partial ??? ShowContentIntroduction(???);
    // [VirtualFunction(125)] public partial ??? IsContentIntroductionInvisible(???);
    // [VirtualFunction(126)] public partial ??? HideContentIntroduction(???);
    [VirtualFunction(129)] public partial void ChangeUIMode(GameUIMode uiMode);
    [VirtualFunction(130)] public partial bool InContentsReplay();
    [VirtualFunction(137)] public partial void SetCursorVisibility(bool visible);
    // [VirtualFunction(138)] public partial ??? ToggleCursor(???);
    // [VirtualFunction(152)] public partial ??? ShowEventFadeIn(???);
    // [VirtualFunction(153)] public partial ??? ShowEventFadeOut(???);
    [VirtualFunction(157)] public partial void ToggleUi(UIModule.UiFlags flags, bool enable, bool unknown = true);
    // [VirtualFunction(158)] public partial ??? ToggleUi_2(???);
    // [VirtualFunction(160)] public partial ??? LoadScreenHideUi(???);
    // [VirtualFunction(161)] public partial ??? LoadScreenShowUi(???);
    // [VirtualFunction(163)] public partial ??? AnnounceHowTo(???);
    // [VirtualFunction(165)] public partial ??? HideHowTo(???);
    [VirtualFunction(167)] public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);
    [VirtualFunction(168)] public partial void HideGoldSaucerReward();
    // [VirtualFunction(169)] public partial ??? HideGoldSaucerReward_2(???);
    [VirtualFunction(174)] public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);
    // [VirtualFunction(176)] public partial ??? OpenMiniGame(???);
    // [VirtualFunction(177)] public partial ??? HideHousingHarvest(???);
    [VirtualFunction(178)] public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);

    [VirtualFunction(179), GenerateStringOverloads] public partial void ShowText(int position, CStringPointer text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);
    [VirtualFunction(180)] public partial void ShowTextChain(int chain, int hqChain = 0);
    [VirtualFunction(181), GenerateStringOverloads] public partial void ShowWideText(CStringPointer text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);
    [VirtualFunction(182), GenerateStringOverloads] public partial void ShowPoisonText(CStringPointer text, int layer = 0);
    [VirtualFunction(183), GenerateStringOverloads] public partial void ShowErrorText(CStringPointer text, bool forceVisible = true);
    [VirtualFunction(184)] public partial void ShowTextClassChange(uint classJobId);
    [VirtualFunction(185)] public partial void ShowGetAction(ActionType actionType, uint actionId);
    [VirtualFunction(186)] public partial void ShowLocationTitle(uint territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);
    // [VirtualFunction(187)] public partial ??? HideLocationTitle(???);
    [VirtualFunction(190)] public partial void ShowGrandCompanyRankUp(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(193)] public partial void ShowStreak(int streak, int streakType);
    [VirtualFunction(194)] public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);
    [VirtualFunction(195)] public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!
    [VirtualFunction(196), GenerateStringOverloads] public partial void ShowBattleTalk(CStringPointer name, CStringPointer text, float duration, byte style);
    [VirtualFunction(197), GenerateStringOverloads] public partial void ShowBattleTalkImage(CStringPointer name, CStringPointer text, float duration, uint image, byte style, int sound = -1, uint entityId = 0xE0000000);
    // [VirtualFunction(198)] private partial ??? ShowBattleTalkUnknown(???);
    [VirtualFunction(199), GenerateStringOverloads] public partial void ShowBattleTalkSound(CStringPointer name, CStringPointer text, float duration, int sound, byte style);
    /// <param name="type">0 = Inventory, 1 = Key Items</param>
    [VirtualFunction(201)] public partial void OpenInventory(byte type = 0);
    [VirtualFunction(202)] public partial void CloseInventory();
    [VirtualFunction(203)] public partial bool IsInventoryOpen();
    [VirtualFunction(204)] public partial void ExecuteMainCommand(uint command);
    [VirtualFunction(205)] public partial bool IsMainCommandUnlocked(uint command);
    // [VirtualFunction(208)] public partial ??? ShowRaceCountdownEnd(???);
    // [VirtualFunction(212)] public partial ??? IsDutyRaidFinderOpen(???);
    [VirtualFunction(214)] public partial void ShowTalkSubtitle(Utf8String* text, float duration);
    [VirtualFunction(215)] public partial void HideTalkSubtitle();
    [VirtualFunction(218)] public partial void ShowAdventureNotice(int index);
    [VirtualFunction(221)] public partial void SetLinkshellCycle(int linkshellCycle);
    [VirtualFunction(222)] public partial int RotateLinkshellHistory(int offset);
    [VirtualFunction(223)] public partial void SetCrossWorldLinkshellCycle(int crossWorldLinkshellCycle);
    [VirtualFunction(224)] public partial int RotateCrossLinkshellHistory(int offset);
    // [VirtualFunction(240)] public partial ??? ShowRaceCountdownStart(???);
    // [VirtualFunction(241)] public partial ??? ShowRaceCountdownEnd_2(???);

    [VirtualFunction(245)] public partial bool ShouldLimitFps();
}

public enum UIModulePacketType {
    ClassJobChange = 2,
    LevelChange = 3,
    ShowLogMessage = 4,
    Login = 6,
    InitZone = 5,
    Logout = 7,
    CloseLogoutDialog = 8,
    StartLogoutCountdown = 9,
    UnlockedMapMarkersUpdated = 10,
    PrintPlayTime = 11,
}
