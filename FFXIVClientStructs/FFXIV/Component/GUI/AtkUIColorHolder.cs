using FFXIVClientStructs.FFXIV.Client.System.String;
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
        [FieldOffset(0x0)] public uint RowId;
        // the names of these fields are based on the column names in EXDSchema
        [FieldOffset(0x4)] public uint Unknown0; // this field is used by GetColor() when useThemeColor is false or ActiveColorThemeType == 0
        [FieldOffset(0x8)] public uint Unknown1; // this field is used by GetColor() when useThemeColor is true and ActiveColorThemeType != 0
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct UIColorGroup {
        [FieldOffset(0x0)] public uint StartId;
        [FieldOffset(0x4)] public uint EndId;
        [FieldOffset(0x8)] public uint AccumulatedOffset; // used in the index calculation for the UIColors vector
    }

    [MemberFunction("E8 ?? ?? ?? ?? 8B C8 88 43 2C")]
    public partial uint GetColor(bool useThemeColor, uint id);
}
