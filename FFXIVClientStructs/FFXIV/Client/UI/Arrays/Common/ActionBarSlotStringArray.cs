namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 3 * 8)]
public partial struct ActionBarSlotStringArray {
    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray3<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer ActionTooltip;
    [FieldOffset(1 * 8)] public CStringPointer ActionStacksize;
    [FieldOffset(2 * 8)] public CStringPointer ActionKeybind;
}
