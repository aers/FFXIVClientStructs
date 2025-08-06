namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRow
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRow {
    [FieldOffset(0)] public void* Data;

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 08")]
    public partial void* GetColumnPtr(uint columnIndex);

    [Obsolete("Incorrect signature")]
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D 70 0F B6 D8")]
    public partial bool IsColumnRsv(uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 81 FB")]
    public static partial void* ResolveStringColumnIndirection(void* columnPtr);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 33 C9")]
    public partial CStringPointer GetFirstColumnAsString();
}
