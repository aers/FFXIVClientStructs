using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;
using FFXIVClientStructs.FFXIV.Component.Completion;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using ChangeEventInterface = FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase.ChangeEventInterface;
using ExcelModuleInterface = FFXIVClientStructs.FFXIV.Component.Excel.ExcelModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIModule
//   Client::UI::UIModuleInterface
//   Component::GUI::AtkModuleEvent
//   Component::Excel::ExcelLanguageEvent
//   Common::Configuration::ConfigBase::ChangeEventInterface
[GenerateInterop]
[Inherits<UIModuleInterface>, Inherits<AtkModuleEvent>, Inherits<ExcelLanguageEvent>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xF4610)]
[VirtualTable("4C 89 79 28 48 8D 0D", 7)]
public unsafe partial struct UIModule {
    public static UIModule* Instance() {
        var framework = Framework.Instance();
        return framework == null ? null : framework->GetUIModule();
    }

    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray57<UIModuleHandler> _uIModuleHandlers;
    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray19<RaptureAtkHistory> _atkHistory;
    [FieldOffset(0x7E8)] public int LinkshellCycle;
    [FieldOffset(0x7EC)] public int CrossWorldLinkshellCycle;

    [FieldOffset(0x7F4)] public uint FrameCount;
    [FieldOffset(0x7F8)] internal ExcelModuleInterface* ExcelModuleInterface; // this is Component::Excel::ExcelModuleInterface, not Common::Component::Excel::ExcelModuleInterface!
    [FieldOffset(0x800)] internal RaptureTextModule RaptureTextModule;
    [FieldOffset(0x1660)] internal CompletionModule CompletionModule;
    [FieldOffset(0x19D8)] internal RaptureLogModule RaptureLogModule;
    [FieldOffset(0x60A8)] internal UserFileManager UserFileManager;
    [FieldOffset(0x60C8)] internal RaptureMacroModule RaptureMacroModule;
    [FieldOffset(0x57B78)] internal RaptureHotbarModule RaptureHotbarModule;
    [FieldOffset(0x80908)] internal RaptureGearsetModule RaptureGearsetModule;
    [FieldOffset(0x8C118)] internal AcquaintanceModule AcquaintanceModule;
    [FieldOffset(0x8D2B0)] internal ItemOrderModule ItemOrderModule;
    [FieldOffset(0x8D390)] internal ItemFinderModule ItemFinderModule;
    [FieldOffset(0x8E568)] internal AddonConfig AddonConfig;
    [FieldOffset(0x8E5D8)] internal LogFilterConfig LogFilterConfig;
    [FieldOffset(0x8EB08)] internal UiSavePackModule UiSavePackModule;
    [FieldOffset(0x8EB60)] internal LetterDataModule LetterDataModule;
    [FieldOffset(0x8F5B0)] internal RetainerTaskDataModule RetainerTaskDataModule;
    [FieldOffset(0x8F668)] internal FlagStatusModule FlagStatusModule;
    [FieldOffset(0x8F918)] internal RecipeFavoriteModule RecipeFavoriteModule;
    // [FieldOffset(0x8FAA8)] internal CraftModule CraftModule;
    [FieldOffset(0x8FB08)] internal RaptureUiDataModule RaptureUiDataModule;
    [FieldOffset(0x933E0)] internal DataCenterHelper DataCenterHelper;
    [FieldOffset(0x93400)] internal WorldHelper WorldHelper;
    [FieldOffset(0x93440)] internal GoldSaucerModule GoldSaucerModule;
    [FieldOffset(0x93710)] internal RaptureTeleportHistory RaptureTeleportHistory;
    [FieldOffset(0x937D8)] internal ItemContextCustomizeModule ItemContextCustomizeModule;
    [FieldOffset(0x93970)] internal RecommendEquipModule RecommendEquipModule;
    [FieldOffset(0x939F0)] internal PvpSetModule PvpSetModule;
    // [FieldOffset(0x93A90)] internal Vf40Struct;
    // [FieldOffset(0x93AA0)] internal Vf41Struct;
    [FieldOffset(0x93AB0)] internal EmoteHistoryModule EmoteHistoryModule;
    [FieldOffset(0x93C30)] internal MinionListModule MinionListModule;
    [FieldOffset(0x93CD0)] internal MountListModule MountListModule;
    // [FieldOffset(0x93D70)] internal EmjModule EmjModule;
    [FieldOffset(0x93E40)] internal AozNoteModule AozNoteModule;
    // [FieldOffset(0x94B70)] internal CrossworldLinkShellModule CrossworldLinkShellModule;
    [FieldOffset(0x95168)] internal AchievementListModule AchievementListModule;
    [FieldOffset(0x95200)] internal GroupPoseModule GroupPoseModule;
    [FieldOffset(0x95340)] internal FieldMarkerModule FieldMarkerModule;
    // [FieldOffset(0x95FC0)] UnkStdMap?
    // [FieldOffset(0x95FD0)] internal MycNoteModule MycNoteModule;
    // [FieldOffset(0x96088)] internal OrnamentListModule OrnamentListModule;
    // [FieldOffset(0x960E8)] internal MycItemModule MycItemModule;
    // [FieldOffset(0x96208)] internal GroupPoseStampModule GroupPoseStampModule;
    [FieldOffset(0x9F508)] internal InputTimerModule InputTimerModule;
    // [FieldOffset(0x9FA00)] internal McAggreModule McAggreModule;
    [FieldOffset(0x9FCC8)] internal RetainerCommentModule RetainerCommentModule;
    [FieldOffset(0xA0270)] internal BannerModule BannerModule;
    // [FieldOffset(0xA02C0)] internal AdventureNoteModule AdventureNoteModule;
    // [FieldOffset(0xA0320)] internal AkatsukiNoteModule AkatsukiNoteModule;
    // [FieldOffset(0xA0408)] internal VVDNoteModule VVDNoteModule;
    [FieldOffset(0xA0478)] internal VVDActionModule VVDActionModule;
    // [FieldOffset(0xA04C8)] internal TOFU;
    // [FieldOffset(0xA0518)] internal FISHING;
    // [FieldOffset(0xA05D8)] internal ACTION;
    // [FieldOffset(0xA0640)] internal TFILTER;
    // [FieldOffset(0xA07D0)] internal READYC;
    // [FieldOffset(0xA0820)] internal PTRLST;
    // [FieldOffset(0xA08C8)] internal CATSBM;
    // [FieldOffset(0xA0AA8)] internal DESCRI;
    // [FieldOffset(0xA0B00)] internal MJICWSP;
    // [FieldOffset(0xA0C38)] internal PERFORM;
    [FieldOffset(0xA0D20)] internal ConfigModule ConfigModule;
    [FieldOffset(0xAF850)] internal RaptureShellModule RaptureShellModule;
    [FieldOffset(0xB0AA0)] internal PronounModule PronounModule;

    [FieldOffset(0xB0E50)] internal UI3DModule UI3DModule;
    [FieldOffset(0xC8390)] internal RaptureAtkModule RaptureAtkModule;
    [FieldOffset(0xF1AB0)] internal InfoModule InfoModule;
    [FieldOffset(0xF3728)] internal UIModuleHelpers UIModuleHelpers;
    [FieldOffset(0xF3748)] internal Utf8String AddonSheetName;

    [FieldOffset(0xF37B8)] internal Utf8String UIColorSheetName;

    [FieldOffset(0xF3830)] internal Utf8String CompletionSheetName;
    [FieldOffset(0xF3898)] internal Utf8String UnkECF58;
    [FieldOffset(0xF3900)] internal Utf8String UnkECFC0;
    [FieldOffset(0xF3968)] internal Utf8String UnkED028;
    [FieldOffset(0xF39D0)] public Utf8String LastTalkName;
    [FieldOffset(0xF3A38)] public Utf8String LastTalkText;
    [FieldOffset(0xF3AA0)] internal UIInputData UIInputData;
    [FieldOffset(0xF44D0)] internal UIInputModule UIInputModule;
    // [FieldOffset(??)] internal Vf70Struct;

    [Obsolete("Moved to UIGlobals.PlaySoundEffect")]
    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B7 C5")]
    public static partial bool PlaySound(uint effectId, long a2 = 0, long a3 = 0, byte a4 = 0);

    [Obsolete("Moved to UIGlobals.IsValidPlayerCharacterName")]
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 C7 4C 8B CB"), GenerateStringOverloads]
    public static partial bool IsPlayerCharacterName(byte* name);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F2 48 8B F9 45 84 C9")]
    public partial void ProcessChatBoxEntry(Utf8String* message, nint a4 = 0, bool saveToHistory = false);

    [Obsolete("Moved to UIGlobals.PlayChatSoundEffect")]
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

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct UIModuleHandler {
        // called via AtkModuleEvent.CallHandler()
        [FieldOffset(0x0)] public delegate* unmanaged<void*, AtkValue*, AtkValue*, uint, AtkValue*> FunctionPtr; // (mostLikelyUIModule, result, values, valueCount) -> result
        [FieldOffset(0x8)] public uint UIModuleOffset;
    }
}
