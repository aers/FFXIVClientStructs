using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureTextModule
// ctor "40 57 48 83 EC 40 48 8B 02"
[StructLayout(LayoutKind.Explicit, Size = 0xE58)]
public unsafe partial struct RaptureTextModule
{
    public static RaptureTextModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureTextModule();

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

    /// <summary>
    /// Returns the name of a GatheringPoint.
    /// </summary>
    /// <param name="gatheringTypeId">RowId of GatheringType sheet (Use ExportedGatheringPoint.GatheringType.Row)</param>
    /// <param name="gatheringPointType">The GatheringPointType (Use ExportedGatheringPoint.GatheringPointType)</param>
    /// <returns>A string with the name</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 05 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ?? 48 8B D0 E8 ?? ?? ?? ?? 8B 4E 08")]
    public partial byte* GetGatheringPointName(byte gatheringTypeId, byte gatheringPointType);
}
