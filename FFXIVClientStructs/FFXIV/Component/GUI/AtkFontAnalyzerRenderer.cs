namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkFontAnalyzerRenderer
//   Component::GUI::AtkFontAnalyzerBase
//   Component::GUI::AtkFontAnalyzerRenderCount
[GenerateInterop]
[Inherits<AtkFontAnalyzerBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x520)]
public partial struct AtkFontAnalyzerRenderer {
    [FieldOffset(0x130)] public AtkFontAnalyzerRenderCount AtkFontAnalyzerRenderCount;
}
