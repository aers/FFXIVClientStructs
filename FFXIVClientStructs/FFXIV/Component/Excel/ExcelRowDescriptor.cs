namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRowDescriptor
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRowDescriptor {
    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 89 57")]
    public partial void Assign0xFFFF();

    [MemberFunction("48 89 5C 24 ?? 66 44 89 49")]
    public partial void AssignIndividual(int nRowId, short* pSubRowIds, short nSubRowCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 20 48 89 43 30")]
    public partial void AssignByRowId(int nRowId);
}
