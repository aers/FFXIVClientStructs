using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using FFXIVClientStructs.FFXIV.Component.Completion;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIModule
//   Client::UI::UIModuleInterface
[GenerateInterop]
[Inherits<UIModuleInterface>, Inherits<AtkModuleEvent>, Inherits<ExcelLanguageEvent>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xEE030)]
[VirtualTable("48 8D 0D ?? ?? ?? ?? 49 89 46 10", 3)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() => Framework.Instance()->GetUIModule();

    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray19<RaptureAtkHistory> _atkHistory;
    [FieldOffset(0x7E8)] public int LinkshellCycle;
    [FieldOffset(0x7EC)] public int CrossWorldLinkshellCycle;

    [FieldOffset(0x7F4)] public uint FrameCount;
    [FieldOffset(0x7F8)] internal ExcelModule* ExcelModule;
    [FieldOffset(0x800)] internal RaptureTextModule RaptureTextModule;
    [FieldOffset(0x1660)] internal CompletionModule CompletionModule;
    [FieldOffset(0x19D8)] internal RaptureLogModule RaptureLogModule;
    // [FieldOffset(0x50E8)] internal UserFileManager UserFileManager;
    [FieldOffset(0x5108)] internal RaptureMacroModule RaptureMacroModule;
    [FieldOffset(0x56BB0)] internal RaptureHotbarModule RaptureHotbarModule;
    [FieldOffset(0x7F4A8)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8ACB0)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8BE40)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8BF18)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x8D0E8)] internal AddonConfig AddonConfig;
    [FieldOffset(0x8D150)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x8D678)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x8D6C8)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x8E110)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x8E1C0)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x8E468)] internal RecipeFavoriteModule RecipeFavoriteModule;
    // [FieldOffset(0x8E5F0)] internal CraftModule CraftModule;
    [FieldOffset(0x8E648)] internal RaptureUiDataModule RaptureUiDataModule;
    [FieldOffset(0x92218)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x92238)] internal WorldHelper WorldHelper;
    [FieldOffset(0x92278)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x92540)] internal RaptureTeleportHistory RaptureTeleportHistory;
    [FieldOffset(0x92600)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x92790)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x92810)] internal PvpSetModule PvpSetModule;
    // [FieldOffset(0x928A8)] internal Vf40Struct;
    // [FieldOffset(0x928B8)] internal Vf41Struct;
    [FieldOffset(0x928C8)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x92A40)] internal MinionListModule MinionListModule;
    [FieldOffset(0x92AD8)] internal MountListModule MountListModule;
    // [FieldOffset(0x92B70)] internal EmjModule EmjModule;
    [FieldOffset(0x92C30)] internal AozNoteModule AozNoteModule;
    // [FieldOffset(0x93958)] internal CrossworldLinkShellModule CrossworldLinkShellModule;
    [FieldOffset(0x93F48)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x93FD0)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x94100)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x94D78)] UnkStdMap?
    // [FieldOffset(0x94D88)] internal MycNoteModule MycNoteModule;
    // [FieldOffset(0x94E38)] internal OrnamentListModule OrnamentListModule;
    // [FieldOffset(0x94E90)] internal MycItemModule MycItemModule;
    // [FieldOffset(0x94FA8)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0x9E2A0)] internal InputTimerModule InputTimerModule;
    // [FieldOffset(0x9E798)] internal McAggreModule McAggreModule;
    [FieldOffset(0x9EA58)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0x9EFF8)] internal BannerModule BannerModule;
    // [FieldOffset(0x9F040)] internal AdventureNoteModule AdventureNoteModule;
    // [FieldOffset(0x9F098)] internal AkatsukiNoteModule AkatsukiNoteModule;
    // [FieldOffset(0x9F178)] internal VVDNoteModule VVDNoteModule;
    [FieldOffset(0x9F1E0)] internal VVDActionModule VVDActionModule;
    // [FieldOffset(0x9F228)] internal TofuModule TofuModule;
    // [FieldOffset(0x9F270)] internal FishingModule FishingModule;
    // [FieldOffset(0x9F328)] internal UnkStruct;
    // [FieldOffset(0x9F388)] internal UnkStruct;
    // [FieldOffset(0x9F510)] internal UnkStruct;
    [FieldOffset(0x9F5A8)] internal ConfigModule ConfigModule;
    [FieldOffset(0xADF20)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xAF138)] internal PronounModule PronounModule;

    [FieldOffset(0xAF4F0)] internal UI3DModule UI3DModule;
    [FieldOffset(0xC1D00)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xEB178)] internal InfoModule InfoModule;
    [FieldOffset(0xECDF0)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xECE08)] internal Utf8String AddonSheetName;

    [FieldOffset(0xECE78)] internal Utf8String UIColorSheetName;

    [FieldOffset(0xECEF0)] internal Utf8String CompletionSheetName;
    [FieldOffset(0xECF58)] internal Utf8String UnkECF58;
    [FieldOffset(0xECFC0)] internal Utf8String UnkECFC0;
    [FieldOffset(0xED028)] internal Utf8String UnkED028;
    [FieldOffset(0xED090)] public Utf8String LastTalkName;
    [FieldOffset(0xED0F8)] public Utf8String LastTalkText;
    [FieldOffset(0xED160)] internal UIInputData UIInputData;
    [FieldOffset(0xEDB88)] internal UIInputModule UIInputModule;
    // [FieldOffset(0xEDFE0)] internal Vf70Struct;

    [MemberFunction("E8 ?? ?? ?? ?? 48 63 45 80")]
    public static partial bool PlaySound(uint effectId, long a2 = 0, long a3 = 0, byte a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 B4 4C 8B CB"), GenerateStringOverloads]
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
