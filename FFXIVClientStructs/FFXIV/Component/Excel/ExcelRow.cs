namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRow
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRow {
    [FieldOffset(0)] public void* Data;

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 08")]
    public partial void* GetColumnPtr(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D 60 0F B6 D8")]
    public partial bool IsColumnRsv(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 2C 5B")]
    public static partial void* ResolveStringColumnIndirection(void* columnPtr);
}
