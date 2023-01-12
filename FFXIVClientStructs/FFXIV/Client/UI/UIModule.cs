using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIModule
//   Client::UI::UIModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0xEB180)]
public unsafe partial struct UIModule
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x0)] public void** vfunc;
    [FieldOffset(0x8)] public Unk1 UnkObj1;
    [FieldOffset(0x10)] public Unk2 UnkObj2;
    [FieldOffset(0x18)] public Unk3 UnkObj3;
    [FieldOffset(0x20)] public void* unk;
    [FieldOffset(0x28)] public void* SystemConfig;

    public static void PlayChatSoundEffect(uint effectId)
    {
        if (effectId is < 1 or > 16)
            throw new ArgumentException("Valid chat sfx values are 1 through 16.");

        PlaySound(effectId + 0x24u, 0, 0, 0);
    }

    [Obsolete("Use GetRaptureAtkModule", true)] [FieldOffset(0xB9AB0)]
    public RaptureAtkModule RaptureAtkModule; // note: NOT a pointer, the module's a member

    /*
        dq 0                                    ; +0x30
        dq 23000000000h                         ; +0x38
        dq 0                                    ; +0x40
        dq 23000000000h                         ; +0x48
        dq 0                                    ; +0x50
        and so on...
     */

    [VirtualFunction(5)]
    public partial ExcelModuleInterface* GetExcelModule();

    [VirtualFunction(6)]
    public partial RaptureTextModule* GetRaptureTextModule();

    [VirtualFunction(7)]
    public partial RaptureAtkModule* GetRaptureAtkModule();

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
    public partial void* GetAcquaintanceModule();

    [VirtualFunction(16)]
    public partial void* GetItemOrderModule();

    [VirtualFunction(17)]
    public partial void* GetItemFinderModule();

    [VirtualFunction(18)]
    public partial ConfigModule* GetConfigModule();

    [VirtualFunction(19)]
    public partial void* GetAddonConfig();

    [VirtualFunction(20)]
    public partial void* GetUiSavePackModule();

    [VirtualFunction(21)]
    public partial void* GetLetterDataModule();

    [VirtualFunction(22)]
    public partial void* GetRetainerTaskDataModule();

    [VirtualFunction(23)]
    public partial void* GetFlagStatusModule();

    [VirtualFunction(26)] 
    public partial RaptureUiDataModule* GetRaptureUiDataModule();

    [VirtualFunction(30)]
    public partial void* GetRaptureTeleportHistory();
    
    [VirtualFunction(32)]
    public partial RecommendEquipModule* GetRecommendEquipModule();

    [VirtualFunction(36)]
    public partial AgentModule* GetAgentModule();

    [VirtualFunction(38)]
    public partial UI3DModule* GetUI3DModule();

    [VirtualFunction(57)]
    public partial RetainerCommentModule* GetRetainerCommentModule();

    [VirtualFunction(63)]
    public partial void* GetUIInputData();

    [VirtualFunction(64)]
    public partial void* GetUIInputModule();

    [VirtualFunction(66)]
    public partial void* GetLogFilterConfig();

    [VirtualFunction(140)]
    public partial void ToggleUi(UiFlags flags, bool enable, bool unknown = true);
    
    [VirtualFunction(150)]
    public partial void ShowGoldSaucerReward(byte type, uint mgp, uint rewardItemId, uint rewardItemCount);

    [VirtualFunction(151)]
    public partial void HideGoldSaucerReward();

    [VirtualFunction(152)]
    public partial void ShowTextRelicAtma(uint itemId);

    [VirtualFunction(159)]
    public partial void ShowHousingHarvest(uint itemId, int amount, uint image = 0);

    [VirtualFunction(163)]
    public partial void ShowImage(uint imageId, bool useLocalePath = false, int displayType = 0, bool playSound = false);

    [VirtualFunction(164)]
    [GenerateCStrOverloads]
    public partial void ShowText(int position, byte* text, uint iconOrCheck1 = 0, bool playSound = true, uint iconOrCheck2 = 0, bool alsoPlaySound = true);

    [VirtualFunction(165)]
    public partial void ShowTextChain(int chain, int hqChain = 0);

    [VirtualFunction(166)]
    [GenerateCStrOverloads]
    public partial void ShowAreaText(byte* text, int layer = 0, bool isTop = true, bool isFast = false, uint logMessageId = 0);

    [VirtualFunction(167)]
    [GenerateCStrOverloads]
    public partial void ShowPoisonText(byte* text, int layer = 0);

    [VirtualFunction(168)]
    [GenerateCStrOverloads]
    public partial void ShowErrorText(byte* text, bool forceVisible = true);

    [VirtualFunction(169)]
    public partial void ShowTextClassChange(uint classJobId);

    [VirtualFunction(170)]
    public partial void ShowGetAction(ActionType actionType, uint actionId);

    [VirtualFunction(171)]
    public partial void ShowLocationTitle(int territoryId, bool zoomAnim, bool restartAnim, int* language /*-1 = client lang*/);

    [VirtualFunction(175)]
    public partial void ShowGrandCompany1(uint gc, uint gcRank, bool playSound = true);

    [VirtualFunction(178)]
    public partial void ShowStreak(int streak, int streakType);

    [VirtualFunction(179)]
    public partial void ShowAddonKillStreakForManeuvers(int streak, int streakType);

    [VirtualFunction(180)]
    public partial void ShowBalloonMessage(float* worldPosition, byte pz, uint textImage); //121501 -> Nice Shot!

    [VirtualFunction(181)]
    [GenerateCStrOverloads]
    public partial void ShowBattleTalk(byte* name, byte* text, float duration, byte style);

    [VirtualFunction(182)]
    [GenerateCStrOverloads]
    public partial void ShowBattleTalkImage(byte* name, byte* text, float duration, uint image, byte style);

    [VirtualFunction(184)]
    [GenerateCStrOverloads]
    public partial void ShowBattleTalkSound(byte* name, byte* text, float duration, int sound, byte style);

    [VirtualFunction(190)]
    public partial void ExecuteMainCommand(uint command);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 39 BE")]
    public static partial bool PlaySound(uint effectId, long a2, long a3, byte a4);

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Unk1
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x0)] public void** vfunc;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Unk2
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x0)] public void** vfunc;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)] // size?
    public struct Unk3
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x0)] public void** vfunc;
    }

    [Flags]
    public enum UiFlags
    {
        Shortcuts = 1, //disable ui shortcuts
        Hud = 2,
        Nameplates = 4,
        Chat = 8,
        ActionBars = 16,
        Unk32 = 32, //same as 1 ?
        TargetInfo = 64 //+disable system menu / ESC key
    }
}