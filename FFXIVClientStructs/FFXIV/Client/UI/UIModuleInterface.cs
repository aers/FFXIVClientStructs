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
    [Obsolete("Use GetExcelModuleInterface(). The interface is different from the actual ExcelModule class, so we're renaming it to avoid confusion.", true)]
    [VirtualFunction(5)] public partial ExcelModuleInterface* GetExcelModule();
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
    [VirtualFunction(38)] public partial AgentModule.UIModuleAgentModulePtrStruct* GetUIModuleAgentModulePtr();
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
    [VirtualFunction(74)] public partial UIInputData* GetUIInputData();
    [VirtualFunction(75)] public partial UIInputModule* GetUIInputModule();
    // [VirtualFunction(76)] public partial Vf70Struct* GetVf70Struct();
    [VirtualFunction(77)] public partial LogFilterConfig* GetLogFilterConfig();
    // [VirtualFunction(78)] public partial Vf72Struct* GetVf72Struct(); // ConfigModule
    // [VirtualFunction(79)] public partial void EnableCutsceneInputMode();
    // [VirtualFunction(80)] public partial void DisableCutsceneInputMode();

    [VirtualFunction(85)] public partial bool EnterGPose();
    [VirtualFunction(86)] public partial void ExitGPose();
    [VirtualFunction(87)] public partial bool IsInGPose();
    [VirtualFunction(88)] public partial void EnterIdleCam(byte a1 = 0, ulong focusObject = 0xE0000000);
    [VirtualFunction(89)] public partial void ExitIdleCam();
    [VirtualFunction(90)] public partial bool IsInIdleCam();
    [VirtualFunction(96)] public partial void ShowDeepDungeonHud();
    [VirtualFunction(97)] public partial void HideDeepDungeonHud();
    [VirtualFunction(99)] public partial void ShowEurekaHud();
    [VirtualFunction(100)] public partial void HideEurekaHud();
    // [VirtualFunction(106)] public partial ??? OpenMycInfo(???);
    // [VirtualFunction(107)] public partial ??? CloseMycInfo(???);
    // [VirtualFunction(108)] public partial ??? CloseMiniMap(???);
    // [VirtualFunction(109)] public partial ??? OpenMiniMap(???);
    // [VirtualFunction(110)] public partial ??? IsGamePadInputActive(???);
    // [VirtualFunction(113)] public partial ??? ToggleInputMode(???);
    // [VirtualFunction(115)] public partial ??? IsUIHidden(???);
    [VirtualFunction(116)] public partial void AddAtkHistoryEntry(Utf8String* text, int historyIdx);
    [VirtualFunction(117)] public partial void ClearAtkHistory(int historyIdx);
    [VirtualFunction(120)] public partial void HandlePacket(UIModulePacketType type, uint uintParam, void* packet);
    // [VirtualFunction(121)] public partial ??? ShowContentIntroduction(???);
    // [VirtualFunction(122)] public partial ??? IsContentIntroductionInvisible(???);
    // [VirtualFunction(123)] public partial ??? HideContentIntroduction(???);
    // [VirtualFunction(134)] public partial ??? SetCursorVisibility(???);
    // [VirtualFunction(135)] public partial ??? ToggleCursor(???);
    // [VirtualFunction(149)] public partial ??? ShowEventFadeIn(???);
    // [VirtualFunction(150)] public partial ??? ShowEventFadeOut(???);
    [VirtualFunction(154)] public partial void ToggleUi(UIModule.UiFlags flags, bool enable, bool unknown = true);
    // [VirtualFunction(155)] public partial ??? ToggleUi_2(???);
    // [VirtualFunction(157)] public partial ??? LoadScreenHideUi(???);
    // [VirtualFunction(158)] public partial ??? LoadScreenShowUi(???);
    // [VirtualFunction(160)] public partial ??? AnnounceHowTo(???);
    // [VirtualFunction(162)] public partial ??? HideHowTo(???);
    [VirtualFunction(164)] public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);
    [VirtualFunction(165)] public partial void HideGoldSaucerReward();
    [VirtualFunction(166)] public partial void ShowTextRelicAtma(uint itemId);
    // [VirtualFunction(168)] public partial ??? HideGoldSaucerReward_2(???);
    [VirtualFunction(174)] public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);
    // [VirtualFunction(176)] public partial ??? OpenMiniGame(???);
    // [VirtualFunction(177)] public partial ??? HideHousingHarvest(???);
    [VirtualFunction(178)] public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);
    [VirtualFunction(179), GenerateStringOverloads] public partial void ShowText(int position, byte* text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);
    [VirtualFunction(180)] public partial void ShowTextChain(int chain, int hqChain = 0);
    [VirtualFunction(181), GenerateStringOverloads] public partial void ShowWideText(byte* text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);
    [VirtualFunction(182), GenerateStringOverloads] public partial void ShowPoisonText(byte* text, int layer = 0);
    [VirtualFunction(183), GenerateStringOverloads] public partial void ShowErrorText(byte* text, bool forceVisible = true);
    [VirtualFunction(184)] public partial void ShowTextClassChange(uint classJobId);
    [VirtualFunction(185)] public partial void ShowGetAction(ActionType actionType, uint actionId);
    [VirtualFunction(186)] public partial void ShowLocationTitle(uint territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);
    // [VirtualFunction(187)] public partial ??? HideLocationTitle(???);
    [Obsolete("Renamed to ShowGrandCompanyRankUp", true)]
    [VirtualFunction(190)] public partial void ShowGrandCompany1(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(190)] public partial void ShowGrandCompanyRankUp(uint gc, uint gcRank, bool playSound = true);
    [VirtualFunction(193)] public partial void ShowStreak(int streak, int streakType);
    [VirtualFunction(194)] public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);
    [VirtualFunction(195)] public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!
    [VirtualFunction(196), GenerateStringOverloads] public partial void ShowBattleTalk(byte* name, byte* text, float duration, byte style);
    [VirtualFunction(197), GenerateStringOverloads] public partial void ShowBattleTalkImage(byte* name, byte* text, float duration, uint image, byte style, int sound = -1, uint entityId = 0xE0000000);
    // [VirtualFunction(198)] public partial ??? ShowBattleTalkUnknown(???);
    [VirtualFunction(199), GenerateStringOverloads] public partial void ShowBattleTalkSound(byte* name, byte* text, float duration, int sound, byte style);
    /// <param name="type">0 = Inventory, 1 = Key Items</param>
    [VirtualFunction(201)] public partial void OpenInventory(byte type = 0);
    [VirtualFunction(202)] public partial void CloseInventory();
    [VirtualFunction(203)] public partial bool IsInventoryOpen();
    [VirtualFunction(204)] public partial void ExecuteMainCommand(uint command);
    [VirtualFunction(205)] public partial bool IsMainCommandUnlocked(uint command);
    // [VirtualFunction(208)] public partial ??? ShowRaceCountdownEnd(???);
    // [VirtualFunction(212)] public partial ??? IsDutyRaidFinderOpen(???);
    [VirtualFunction(218)] public partial void ShowAdventureNotice(int index);
    [VirtualFunction(222)] public partial int RotateLinkshellHistory(int offset);
    [VirtualFunction(223)] public partial void SetLinkshellCycle(int linkshellCycle);
    [VirtualFunction(224)] public partial int RotateCrossLinkshellHistory(int offset);
    // [VirtualFunction(240)] public partial ??? ShowRaceCountdownStart(???);
    // [VirtualFunction(241)] public partial ??? ShowRaceCountdownEnd_2(???);
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
