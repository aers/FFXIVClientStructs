namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRow
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRow {
    [FieldOffset(0)] public void* Data;

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 08")]
    public partial void* GetColumnPtr(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 49 8D B5")]
    public partial bool IsColumnRsv(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7F 04")]
    public static partial void* ResolveStringColumnIndirection(void* columnPtr);
}
