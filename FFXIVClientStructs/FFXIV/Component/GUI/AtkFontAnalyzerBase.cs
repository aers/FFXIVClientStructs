namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkFontAnalyzerBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AtkFontAnalyzerBase {
    [FieldOffset(0x38)] public AtkFontManager.FontSet* FontSet;
    [FieldOffset(0x40)] public AtkFontManager.Font* Font;

    /// <summary>Lays out a character or a macro at <paramref name="text"/> and steps past it.</summary>
    [MemberFunction("40 53 55 56 57 41 54 41 55 41 56 48 83 EC 70 4C 8B 0A 49 8B F8 48 8B 69 40")]
    public partial byte* LayOutCharacter(byte** text, AtkFontAnalyzerState* state);
}

[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public struct AtkFontAnalyzerState {
    /// <summary>A copy of <see cref="AtkFontManager.FontSet.DrawFlags"/>. Affected by italicizing macro.</summary>
    [FieldOffset(0x38)] public AtkFontManager.DrawFlags Flags;
}
