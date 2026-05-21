using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRow
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRow {
    [FieldOffset(0x00)] public void* Data;
    [FieldOffset(0x08)] public ExcelSheet* Sheet;

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 08")]
    public partial void* GetColumnPtr(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D 70 0F B6 D8")]
    public partial bool IsColumnRsv(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 81 FB")]
    public static partial void* ResolveStringColumnIndirection(void* columnPtr);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 33 C9")]
    public partial CStringPointer GetColumnString(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 33 C9"), Obsolete("Use GetColumnString with columnIndex 0", true)]
    public partial CStringPointer GetFirstColumnAsString();
}
