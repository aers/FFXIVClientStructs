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
    [VirtualFunction(5)] public partial ExcelModuleInterface* GetExcelModule();
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
    // [VirtualFunction(34)] public partial Vf34Struct* GetVf34Struct(); // new 7.0
    [VirtualFunction(35)] public partial InfoModule* GetInfoModule();
    [VirtualFunction(36)] public partial UIModuleHelpers* GetUIModuleHelpers();
    [VirtualFunction(37)] public partial AgentModule* GetAgentModule();
    // [VirtualFunction(37)] public partial UIModule* GetAfterAgentsPtr(); // points to the field right after the last Agent in AgentModule
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
    // [VirtualFunction(51)] public partial StdMap* GetUnkStdMap967C8();
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
    // [VirtualFunction(66)] public partial Vf41Struct* GetVf66Struct(); // new 7.0
    // [VirtualFunction(67)] public partial Vf41Struct* GetVf67Struct(); // new 7.0
    [VirtualFunction(68)] public partial UIInputData* GetUIInputData();
    [VirtualFunction(69)] public partial UIInputModule* GetUIInputModule();
    // [VirtualFunction(70)] public partial Vf70Struct* GetVf70Struct();
    [VirtualFunction(71)] public partial LogFilterConfig* GetLogFilterConfig();
    // [VirtualFunction(72)] public partial Vf72Struct* GetVf72Struct();
    // [VirtualFunction(73)] public partial void EnableCutsceneInputMode();
    // [VirtualFunction(74)] public partial void DisableCutsceneInputMode();
    [VirtualFunction(79)] public partial bool EnterGPose();
    [VirtualFunction(80)] public partial void ExitGPose();
    [VirtualFunction(81)] public partial bool IsInGPose();
    [VirtualFunction(82)] public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);
    [VirtualFunction(83)] public partial void ExitIdleCam();
    [VirtualFunction(84)] public partial bool IsInIdleCam();
    [VirtualFunction(90)] public partial void ShowDeepDungeonHud();
    [VirtualFunction(91)] public partial void HideDeepDungeonHud();
    [VirtualFunction(93)] public partial void ShowEurekaHud();
    [VirtualFunction(94)] public partial void HideEurekaHud();
    // [VirtualFunction(100)] public partial ??? OpenMycInfo(???);
    // [VirtualFunction(101)] public partial ??? CloseMycInfo(???);
    // [VirtualFunction(102)] public partial ??? CloseMiniMap(???);
    // [VirtualFunction(103)] public partial ??? OpenMiniMap(???);
    // [VirtualFunction(104)] public partial ??? IsGamePadInputActive(???);
    // [VirtualFunction(107)] public partial ??? ToggleInputMode(???);
    // [VirtualFunction(109)] public partial ??? IsUIHidden(???);
    [VirtualFunction(110)] public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);
    [VirtualFunction(111)] public partial void ClearAtkHistory(int historyIdx);
    [VirtualFunction(114)] public partial void HandlePacket(UIModulePacketType type, uint uintParam, void* packet);
    // [VirtualFunction(115)] public partial ??? ShowContentIntroduction(???);
    // [VirtualFunction(116)] public partial ??? IsContentIntroductionInvisible(???);
    // [VirtualFunction(117)] public partial ??? HideContentIntroduction(???);
    // [VirtualFunction(127)] public partial ??? SetCursorVisibility(???);
    // [VirtualFunction(128)] public partial ??? ToggleCursor(???);
    // [VirtualFunction(142)] public partial ??? ShowEventFadeIn(???);
    // [VirtualFunction(143)] public partial ??? ShowEventFadeOut(???);
    [VirtualFunction(147)] public partial void ToggleUi(UIModule.UiFlags flags, bool enable, bool unknown = true);
    // [VirtualFunction(148)] public partial ??? ToggleUi_2(???);
    // [VirtualFunction(150)] public partial ??? LoadScreenHideUi(???);
    // [VirtualFunction(151)] public partial ??? LoadScreenShowUi(???);
    // [VirtualFunction(153)] public partial ??? AnnounceHowTo(???);
    // [VirtualFunction(155)] public partial ??? HideHowTo(???);
    [VirtualFunction(157)] public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);
    [VirtualFunction(158)] public partial void HideGoldSaucerReward();
    [VirtualFunction(159)] public partial void ShowTextRelicAtma(uint itemId);
    // [VirtualFunction(161)] public partial ??? HideGoldSaucerReward_2(???);
    [VirtualFunction(167)] public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);
    // [VirtualFunction(169)] public partial ??? OpenMiniGame(???);
    // [VirtualFunction(170)] public partial ??? HideHousingHarvest(???);
    [VirtualFunction(171)] public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);
    [VirtualFunction(172), GenerateStringOverloads] public partial void ShowText(int position, byte* text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);
    [VirtualFunction(173)] public partial void ShowTextChain(int chain, int hqChain = 0);
    [VirtualFunction(174), GenerateStringOverloads] public partial void ShowWideText(byte* text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);
    [VirtualFunction(175), GenerateStringOverloads] public partial void ShowPoisonText(byte* text, int layer = 0);
    [VirtualFunction(176), GenerateStringOverloads] public partial void ShowErrorText(byte* text, bool forceVisible = true);
    [VirtualFunction(177)] public partial void ShowTextClassChange(uint classJobId);
    [VirtualFunction(178)] public partial void ShowGetAction(ActionType actionType, uint actionId);
    [VirtualFunction(179)] public partial void ShowLocationTitle(uint territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);
    // [VirtualFunction(180)] public partial ??? HideLocationTitle(???);
    [VirtualFunction(183)] public partial void ShowGrandCompany1(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(186)] public partial void ShowStreak(int streak, int streakType);
    [VirtualFunction(187)] public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);
    [VirtualFunction(188)] public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!
    [VirtualFunction(189), GenerateStringOverloads] public partial void ShowBattleTalk(byte* name, byte* text, float duration, byte style);
    [VirtualFunction(190), GenerateStringOverloads] public partial void ShowBattleTalkImage(byte* name, byte* text, float duration, uint image, byte style);
    // [VirtualFunction(191)] public partial ??? ShowBattleTalkUnknown(???);
    [VirtualFunction(192), GenerateStringOverloads] public partial void ShowBattleTalkSound(byte* name, byte* text, float duration, int sound, byte style);
    // [VirtualFunction(194)] public partial ??? OpenInventory(???);
    // [VirtualFunction(195)] public partial ??? CloseInventory(???);
    // [VirtualFunction(196)] public partial ??? IsInventoryOpen(???);
    [VirtualFunction(197)] public partial void ExecuteMainCommand(uint command);
    [VirtualFunction(198)] public partial bool IsMainCommandUnlocked(uint command);
    // [VirtualFunction(201)] public partial ??? ShowRaceCountdownEnd(???);
    // [VirtualFunction(205)] public partial ??? IsDutyRaidFinderOpen(???);
    [VirtualFunction(215)] public partial int RotateLinkshellHistory(int offset);
    [VirtualFunction(217)] public partial int RotateCrossLinkshellHistory(int offset);
    // [VirtualFunction(233)] public partial ??? ShowRaceCountdownStart(???);
    // [VirtualFunction(234)] public partial ??? ShowRaceCountdownEnd_2(???);
}

public enum UIModulePacketType {
    ClassJobChange = 2,
    LevelChange = 3,
    ShowLogMessage = 4,
    Logout = 7,
    CloseLogoutDialog = 8,
    StartLogoutCountdown = 9,
    PrintPlayTime = 11,
}
