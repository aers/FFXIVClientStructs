using FFXIVClientStructs.FFXIV.Client.Game;
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
    [VirtualFunction(79)] public partial XBMNoteModule* GetXBMNoteModule();
    [VirtualFunction(80)] public partial XBMModule* GetXBMModule();
    [VirtualFunction(81)] public partial UIInputData* GetUIInputData();
    [VirtualFunction(82)] public partial UIInputModule* GetUIInputModule();
    // [VirtualFunction(83)] public partial Vf79Struct* GetVf70Struct();
    [VirtualFunction(84)] public partial LogFilterConfig* GetLogFilterConfig();
    // [VirtualFunction(85)] public partial Vf81Struct* GetVf81Struct();
    // [VirtualFunction(86)] public partial void EnableCutsceneInputMode();
    // [VirtualFunction(87)] public partial void DisableCutsceneInputMode();

    [VirtualFunction(92)] public partial bool EnterGPose();
    [VirtualFunction(93)] public partial void ExitGPose();
    [VirtualFunction(94)] public partial bool IsInGPose();
    [VirtualFunction(95)] public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);
    [VirtualFunction(96)] public partial void ExitIdleCam();
    [VirtualFunction(97)] public partial bool IsInIdleCam();
    [VirtualFunction(103)] public partial void ShowDeepDungeonHud();
    [VirtualFunction(104)] public partial void HideDeepDungeonHud();
    [VirtualFunction(106)] public partial void ShowEurekaHud();
    [VirtualFunction(107)] public partial void HideEurekaHud();

    // [VirtualFunction(113)] public partial ??? CloseMiniMap(???);
    // [VirtualFunction(114)] public partial ??? OpenMiniMap(???);
    [VirtualFunction(115)] public partial bool IsPadModeEnabled();
    [VirtualFunction(116)] public partial bool IsPadMouseModeEnabled();

    [VirtualFunction(118)] public partial bool SetPadMode(bool enable);
    [VirtualFunction(119)] public partial void CancelDragDrop(bool condition = true); // doesn't do anything when false is passed
    // [VirtualFunction(120)] public partial ??? IsUIHidden(???);
    [VirtualFunction(121)] public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);
    [VirtualFunction(122)] public partial void ClearAtkHistory(int historyIdx);
    [VirtualFunction(123)] public partial bool IsPerforming();

    [VirtualFunction(125)] public partial void HandlePacket(UIModulePacketType type, uint uintParam, void* packet);

    // [VirtualFunction(126)] public partial ??? ShowContentIntroduction(???);
    // [VirtualFunction(127)] public partial ??? IsContentIntroductionInvisible(???);
    // [VirtualFunction(128)] public partial ??? HideContentIntroduction(???);
    [VirtualFunction(131)] public partial void ChangeUIMode(GameUIMode uiMode);
    [VirtualFunction(132)] public partial bool InContentsReplay();
    [VirtualFunction(139)] public partial void SetCursorVisibility(bool visible);
    // [VirtualFunction(140)] public partial ??? ToggleCursor(???);
    // [VirtualFunction(154)] public partial ??? ShowEventFadeIn(???);
    // [VirtualFunction(155)] public partial ??? ShowEventFadeOut(???);
    [VirtualFunction(159)] public partial void ToggleUi(UiFlags flags, bool enable, bool disableTransition = true);
    // [VirtualFunction(160)] public partial ??? ToggleUi_2(???);
    // [VirtualFunction(162)] public partial ??? LoadScreenHideUi(???);
    // [VirtualFunction(163)] public partial ??? LoadScreenShowUi(???);
    // [VirtualFunction(165)] public partial ??? AnnounceHowTo(???);
    // [VirtualFunction(167)] public partial ??? HideHowTo(???);
    [VirtualFunction(169)] public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);
    [VirtualFunction(170)] public partial void HideGoldSaucerReward();
    // [VirtualFunction(171)] public partial ??? HideGoldSaucerReward_2(???);
    [VirtualFunction(176)] public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);
    // [VirtualFunction(178)] public partial ??? OpenMiniGame(???);
    // [VirtualFunction(179)] public partial ??? HideHousingHarvest(???);
    [VirtualFunction(180)] public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);

    [VirtualFunction(181), GenerateStringOverloads] public partial void ShowText(int position, CStringPointer text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);
    [VirtualFunction(182)] public partial void ShowTextChain(int chain, int hqChain = 0);
    [VirtualFunction(183), GenerateStringOverloads] public partial void ShowWideText(CStringPointer text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);
    [VirtualFunction(184), GenerateStringOverloads] public partial void ShowPoisonText(CStringPointer text, int layer = 0);
    [VirtualFunction(185), GenerateStringOverloads] public partial void ShowErrorText(CStringPointer text, bool forceVisible = true);
    [VirtualFunction(186)] public partial void ShowTextClassChange(uint classJobId);
    [VirtualFunction(187)] public partial void ShowGetAction(ActionType actionType, uint actionId);
    [VirtualFunction(188)] public partial void ShowLocationTitle(uint territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);
    // [VirtualFunction(189)] public partial ??? HideLocationTitle(???);
    [VirtualFunction(192)] public partial void ShowGrandCompanyRankUp(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(195)] public partial void ShowStreak(int streak, int streakType);
    [VirtualFunction(196)] public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);
    [VirtualFunction(197)] public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!
    [VirtualFunction(198), GenerateStringOverloads] public partial void ShowBattleTalk(CStringPointer name, CStringPointer text, float duration, byte style);
    [VirtualFunction(199), GenerateStringOverloads] public partial void ShowBattleTalkImage(CStringPointer name, CStringPointer text, float duration, uint image, byte style, int sound = -1, uint entityId = 0xE0000000);
    // [VirtualFunction(200)] private partial ??? ShowBattleTalkUnknown(???);
    [VirtualFunction(201), GenerateStringOverloads] public partial void ShowBattleTalkSound(CStringPointer name, CStringPointer text, float duration, int sound, byte style);
    /// <param name="type">0 = Inventory, 1 = Key Items</param>
    [VirtualFunction(203)] public partial void OpenInventory(byte type = 0);
    [VirtualFunction(204)] public partial void CloseInventory();
    [VirtualFunction(205)] public partial bool IsInventoryOpen();
    [VirtualFunction(206)] public partial void ExecuteMainCommand(uint command);
    [VirtualFunction(207)] public partial bool IsMainCommandUnlocked(uint command);
    // [VirtualFunction(210)] public partial ??? ShowRaceCountdownEnd(???);
    // [VirtualFunction(214)] public partial ??? IsDutyRaidFinderOpen(???);
    [VirtualFunction(216)] public partial void ShowTalkSubtitle(Utf8String* text, float duration);
    [VirtualFunction(217)] public partial void HideTalkSubtitle();
    [VirtualFunction(220)] public partial void ShowAdventureNotice(int index);
    [VirtualFunction(223)] public partial void SetLinkshellCycle(int linkshellCycle);
    [VirtualFunction(224)] public partial int RotateLinkshellHistory(int offset);
    [VirtualFunction(225)] public partial void SetCrossWorldLinkshellCycle(int crossWorldLinkshellCycle);
    [VirtualFunction(226)] public partial int RotateCrossLinkshellHistory(int offset);
    // [VirtualFunction(242)] public partial ??? ShowRaceCountdownStart(???);
    // [VirtualFunction(243)] public partial ??? ShowRaceCountdownEnd_2(???);

    [VirtualFunction(247)] public partial bool ShouldLimitFps();
}

public enum UIModulePacketType {
    Unknown0 = 0,
    Unknown1 = 1, // chat message?
    ClassJobChange = 2,
    LevelChange = 3,
    ShowLogMessage = 4,
    ZoneInit = 5,
    Login = 6,
    Logout = 7,
    CloseLogoutDialog = 8,
    StartLogoutCountdown = 9,
    UnlockedMapMarkersUpdated = 10,
    PrintPlayTime = 11,
    Unknown12 = 12, // case doesn't exist
    Unknown13 = 13, // contents finder update?
    Unknown14 = 14, // party size changed?
    Unknown15 = 15, // party state changed?
    SetLoginSummonCompanionId = 16, // FlagStatusModule UIFlag 1
    Unknown17 = 17, // ScenarioTree
    Unknown18 = 18, // chat message?
    Unknown19 = 19, // InfoProxy 0x19 (PvP team?)
    Unknown20 = 20, // InfoProxy 0x1D (PvPTeamOrganization?)
    Unknown21 = 21, // CrossWorldLinkShell
    Unknown22 = 22, // ReadyCheck
    Unknown23 = 23, // case doesn't exist
    Unknown24 = 24, // WorldTravel
    Unknown25 = 25, // WorldTravel
    Unknown26 = 26, // CircleList
    Unknown27 = 27, // Circle
    Unknown28 = 28, // CircleFinder
    Unknown29 = 29, // MentorCondition
    Unknown30 = 30, // PerformanceReadyCheck
    Unknown31 = 31, // QuestRedoHud
    Unknown32 = 32, // OrnamentNoteBook
    Unknown33 = 33, // something Retainer
    Unknown34 = 34, // sets uintParam to InputTimerModule+0x4F4
    Unknown35 = 35, // FateProgress
    Unknown36 = 36, // Glasses
    TofuReceiveBoard = 37,
    TofuRealTimeUpdate = 38,
    TofuStopShare = 39,
    TofuConfirmation = 40,

    [Obsolete("Renamed to ZoneInit", true)]
    InitZone = 5,
}
