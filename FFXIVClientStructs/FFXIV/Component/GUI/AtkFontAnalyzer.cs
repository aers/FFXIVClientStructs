namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x980)]
public unsafe struct AtkFontAnalyzer {
    [FieldOffset(0x008)] public AtkFontAnalyzerCount AtkFontAnalyzerCount;
    [FieldOffset(0x078)] public AtkFontAnalyzerDrawSize AtkFontAnalyzerDrawSize;
    [FieldOffset(0x638)] public AtkFontAnalyzerSearchPosition AtkFontAnalyzerSearchPosition;
    [FieldOffset(0x6F0)] public AtkFontAnalyzerCRLFCount AtkFontAnalyzerCRLFCount;
    [FieldOffset(0x758)] public AtkFontAnalyzerCRLFSearch AtkFontAnalyzerCRLFSearch;
    [FieldOffset(0x7C8)] public AtkFontAnalyzerBuildLink AtkFontAnalyzerBuildLink;
    [FieldOffset(0x880)] public AtkFontAnalyzerCreateCache AtkFontAnalyzerCreateCache;
    [FieldOffset(0x8F0)] public AtkFontAnalyzerCheckStringOnlyNumSymbol AtkFontAnalyzerCheckStringOnlyNumSymbol;
    [FieldOffset(0x958)] public AtkFontAnalyzerFunctor AtkFontAnalyzerFunctor;
    [FieldOffset(0x960)] public AtkFontAnalyzerFunctorSelect AtkFontAnalyzerFunctorSelect;
}
