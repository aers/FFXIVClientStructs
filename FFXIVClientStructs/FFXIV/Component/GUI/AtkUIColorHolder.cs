using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct AtkUIColorHolder {
    [FieldOffset(0x00)] public ExdModule* ExdModule;
    [FieldOffset(0x08)] public Utf8String UIColorSheetName;
    [FieldOffset(0x70)] public uint SetupState;
    [FieldOffset(0x74)] public byte ActiveColorThemeType; // there is a config option called ColorThemeType
    [FieldOffset(0x78)] public StdVector<UIColor> UIColors;
    [FieldOffset(0x90)] public StdList<UIColorGroup> UIColorGroups; // 0-73, 500-580, 700-710

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct UIColor {
        [FieldOffset(0x00)] public uint RowId;
        /// <remarks> Used by <see cref="GetColor"/> when the <c>useThemeColor</c> parameter is <see langword="false"/> or <see cref="ActiveColorThemeType"/> is <c>0</c>. </remarks>
        [FieldOffset(0x04)] public uint Color;
        /// <remarks> Used by <see cref="GetColor"/> when the <c>useThemeColor</c> parameter is <see langword="true"/> and <see cref="ActiveColorThemeType"/> is not <c>0</c>. </remarks>
        [FieldOffset(0x08)] public uint ThemedColor;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct UIColorGroup {
        [FieldOffset(0x00)] public uint StartId;
        [FieldOffset(0x04)] public uint EndId;
        [FieldOffset(0x08)] public uint AccumulatedOffset; // used in the index calculation for the UIColors vector
    }

    /// <summary>
    /// Sets <see cref="ActiveColorThemeType"/> and reloads the UIColor sheet.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? B0 ?? C6 83 ?? ?? ?? ?? ?? 48 8B 5C 24 ?? 48 8B 74 24 ?? 48 83 C4 ?? 5F C3 80 BB")]
    public partial void SetActiveColorThemeType(byte themeType);

    [MemberFunction("E8 ?? ?? ?? ?? 8B C8 88 43 2C")]
    public partial uint GetColor(bool useThemeColor, uint id);
}
