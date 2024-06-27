namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRowDescriptor
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRowDescriptor {
    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 89 57 20")]
    public partial void Assign0xFFFF();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 89 11 49 8B F0")]
    public partial void AssignIndividual(int nRowId, short* pSubRowIds, short nSubRowCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 20 48 89 43 30")]
    public partial void AssignByRowId(int nRowId);

    [MemberFunction("0F B7 41 06 B9")]
    public partial int GetSubRowCount();
}
