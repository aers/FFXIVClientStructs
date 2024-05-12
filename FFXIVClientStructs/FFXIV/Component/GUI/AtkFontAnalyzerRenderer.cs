namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkFontAnalyzerRenderer
//   Component::GUI::AtkFontAnalyzerBase
//   Component::GUI::AtkFontAnalyzerRenderCount
[StructLayout(LayoutKind.Explicit, Size = 0x520)]
public struct AtkFontAnalyzerRenderer {
    [FieldOffset(0x0)] public AtkFontAnalyzerBase AtkFontAnalyzerBase;
    [FieldOffset(0x130)] public AtkFontAnalyzerRenderCount AtkFontAnalyzerRenderCount;
}
