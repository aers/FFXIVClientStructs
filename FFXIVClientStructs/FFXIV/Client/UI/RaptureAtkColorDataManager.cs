namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::RaptureAtkColorDataManager
// Used by the ColorPicker addon
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct RaptureAtkColorDataManager {
    [FieldOffset(0x08)] public ColorSet* ColorSets;
    [FieldOffset(0x10)] public int NumColorSets;
    [FieldOffset(0x14)] public bool IsLoaded;

    public Span<ColorSet> ColorSetsSpan => new(ColorSets, NumColorSets);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ColorSet {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public short NumColors;
        [FieldOffset(0x06)] public bool UnkBool;
        [FieldOffset(0x08)] public uint* Colors;

        public Span<ColorSet> ColorSpan => new(Colors, NumColors);
    }
}
