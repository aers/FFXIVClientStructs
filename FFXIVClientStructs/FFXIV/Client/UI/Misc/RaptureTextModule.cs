using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureTextModule
// ctor "E8 ?? ?? ?? ?? 48 8D 9F ?? ?? ?? ?? 4D 8B C5"
[StructLayout(LayoutKind.Explicit, Size = 0xE60)]
public unsafe partial struct RaptureTextModule {
    public static RaptureTextModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureTextModule();

    [FieldOffset(0x00)] public TextModule TextModule;
    [FieldOffset(0x510)] public void** ExecNonMacroFunc; // only a vtable
    [FieldOffset(0x518)] public void** ExcelLanguageEvent; // only a vtable
    [FieldOffset(0x520)] public UIModule* UiModule;
    [FieldOffset(0x528)] public TextChecker TextChecker;
    [FieldOffset(0x620)] public ExcelSheet* AddonSheet;

    [MemberFunction("E9 ?? ?? ?? ?? 80 EA 20")]
    public partial byte* GetAddonText(uint addonId);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 7D D7")]
    public partial byte* FormatAddonText2(uint addonId, int intParam1, int intParam2);

    [MemberFunction("E8 ?? ?? ?? ?? EB 55 FF 50 30")]
    public partial byte* FormatAddonText3(uint addonId, int intParam1, int intParam2, int intParam3);

    /// <summary>
    /// Display a timespan as hours, minutes or seconds with only the largest non zero unit.
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="alternativeMinutesGlyph">Use U+E028 for minutes</param>
    /// <returns>string containing one of 23h, 59m, 59s</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 48 8B 4D 88")]
    public partial byte* FormatTimeSpan(uint seconds, bool alternativeMinutesGlyph = false);

    /// <remarks> Singular only. The usage of intParam2 is unknown. </remarks>
    /// <returns>
    /// A pointer to a null terminated string containing the formatted name.<br/>
    /// It was observed, that it can return a nullptr when the excel page was not loaded. Try calling it again in subsequent frames.
    /// </returns>
    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 47 30")]
    public static partial byte* FormatName(NameFormatterPlaceholder placeholder, uint id, NameFormatterIdConverter idConverter, int intParam2 = 1);

    public static byte* GetItemName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.Item, id, NameFormatterIdConverter.None, intParam2);

    public static byte* GetBNpcName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.BNpcName, intParam2);

    public static byte* GetENpcResidentName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.ENpcResident, intParam2);

    public static byte* GetTreasureName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.Treasure, intParam2);

    public static byte* GetAetheryteName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.Aetheryte, intParam2);

    public static byte* GetGatheringPointName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.GatheringPointName, intParam2);

    public static byte* GetEObjName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.EObjName, intParam2);

    public static byte* GetCompanionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ObjStr, id, NameFormatterIdConverter.Companion, intParam2);

    public static byte* GetTraitName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.Trait, intParam2);

    public static byte* GetActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.Action, intParam2);

    public static byte* GetEventActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.EventAction, intParam2);

    public static byte* GetGeneralActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.GeneralAction, intParam2);

    public static byte* GetBuddyActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.BuddyAction, intParam2);

    public static byte* GetMainCommandName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.MainCommand, intParam2);

    public static byte* GetCraftActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.CraftAction, intParam2);

    public static byte* GetPetActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.PetAction, intParam2);

    public static byte* GetCompanyActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.CompanyAction, intParam2);

    public static byte* GetMountName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.Mount, intParam2);

    public static byte* GetBgcArmyActionName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.BgcArmyAction, intParam2);

    public static byte* GetOrnamentName(uint id, int intParam2 = 1)
        => FormatName(NameFormatterPlaceholder.ActStr, id, NameFormatterIdConverter.Ornament, intParam2);
}

public enum NameFormatterPlaceholder : int {
    ObjStr = 0,
    Item = 1,   // bypasses IdConverter
    ActStr = 2,
}

public enum NameFormatterIdConverter : uint {
    None = 0,

    // ObjStr
    BNpcName = 2,
    ENpcResident = 3,
    Treasure = 4,
    Aetheryte = 5,
    GatheringPointName = 6,
    EObjName = 7,
    // Mount = 8, // does not work?
    Companion = 9,
    // 10-11 unused
    // Item = 12, // does not work?

    // ActStr
    Trait = 0,
    Action = 1,
    // Item = 2, // does not work?
    // EventItem = 3, // does not work?
    EventAction = 4,
    // EObjName = 5, // does not work?
    GeneralAction = 5,
    BuddyAction = 6,
    MainCommand = 7,
    // Companion = 8, // unresolved, use Companion
    CraftAction = 9,
    Action2 = 10,
    PetAction = 11,
    CompanyAction = 12,
    Mount = 13,
    // 14-18 unused
    BgcArmyAction = 19,
    Ornament = 20,
}
