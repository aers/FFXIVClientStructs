using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 72 * 8)]
public unsafe partial struct HudStringArray {
    public static HudStringArray* Instance() => (HudStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.Hud)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray72<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer LocalPlayerName;
    [FieldOffset(1 * 8)] public CStringPointer MpIndicator;
    [FieldOffset(2 * 8)] public CStringPointer HpIndicator;
    [FieldOffset(3 * 8)] public CStringPointer GpIndicator;
    [FieldOffset(4 * 8)] public CStringPointer TpIndicator;
    [FieldOffset(5 * 8)] public CStringPointer CpIndicator;
    [FieldOffset(6 * 8)] public CStringPointer Unk6;
    [FieldOffset(7 * 8), FixedSizeArray] internal FixedSizeArray30<CStringPointer> _statusTimesRemaining;
    [FieldOffset(37 * 8), FixedSizeArray] internal FixedSizeArray30<CStringPointer> _statusTooltips;
    [FieldOffset(67 * 8)] public CStringPointer JobName;
    [FieldOffset(68 * 8)] public CStringPointer Unk68;
    [FieldOffset(69 * 8)] public CStringPointer ExpBarText;
    [FieldOffset(70 * 8)] public CStringPointer Unk70;
    [FieldOffset(71 * 8)] public CStringPointer CombatTypeIndicator;
}
