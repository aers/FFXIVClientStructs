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

    // CExporterIgnore so it only exports the VTable from source generation
    [FieldOffset(0x0), CExportIgnore] public void* vtbl;
    [FieldOffset(0x0), CExportIgnore] public void** vfunc;
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

    [VirtualFunction(26)]
    public partial RaptureUiDataModule* GetRaptureUiDataModule();

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

    [VirtualFunction(36)]
    public partial AgentModule* GetAgentModule();

    [VirtualFunction(38)]
    public partial UI3DModule* GetUI3DModule();

    [VirtualFunction(49)]
    public partial FieldMarkerModule* GetFieldMarkerModule();

    [VirtualFunction(55)]
    public partial InputTimerModule* GetInputTimerModule();

    [VirtualFunction(57)]
    public partial RetainerCommentModule* GetRetainerCommentModule();

    [VirtualFunction(58)]
    public partial BannerModule* GetBannerModule();

    [VirtualFunction(65)]
    public partial UIInputData* GetUIInputData();

    [VirtualFunction(66)]
    public partial UIInputModule* GetUIInputModule();

    [VirtualFunction(68)]
    public partial LogFilterConfig* GetLogFilterConfig();

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
