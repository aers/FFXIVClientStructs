using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 72 * 8)]
public unsafe partial struct HudStringArray {
    public static HudStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.Hud);
        return stringArray == null ? null : (HudStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray72<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer LocalPlayerName;
    [FieldOffset(1 * 8)] public CStringPointer MpIndicator;
    [FieldOffset(2 * 8)] public CStringPointer HpIndicator;
    [FieldOffset(3 * 8)] public CStringPointer GpIndicator;
    [FieldOffset(4 * 8)] public CStringPointer TpIndicator;
    [FieldOffset(5 * 8)] public CStringPointer CpIndicator;
    [FieldOffset(6 * 8)] private CStringPointer Unk6;
    [FieldOffset(7 * 8), FixedSizeArray] internal FixedSizeArray30<CStringPointer> _statusTimesRemaining;
    [FieldOffset(37 * 8), FixedSizeArray] internal FixedSizeArray30<CStringPointer> _statusTooltips;
    [FieldOffset(67 * 8)] public CStringPointer JobName;
    [FieldOffset(68 * 8)] private CStringPointer Unk68;
    [FieldOffset(69 * 8)] public CStringPointer ExpBarText;
    [FieldOffset(70 * 8)] private CStringPointer Unk70;
    [FieldOffset(71 * 8)] public CStringPointer CombatTypeIndicator;
}
