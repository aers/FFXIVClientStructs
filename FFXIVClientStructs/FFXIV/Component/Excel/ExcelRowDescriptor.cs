namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelRowDescriptor
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelRowDescriptor {
    [FieldOffset(0x00)] public uint RowId;
    [FieldOffset(0x04)] public ushort LowerRowIdPart; // found to be assigned with = (ushort)RowId in a few calls
    [FieldOffset(0x06)] public ushort SubRowCount; // TODO: change to short (seen as -1 and -2)
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray4<ushort> _subRowIds; // TODO: change ushort to short

    // [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8B DF 48 8D 4E")]
    // public partial void Assign0xFFFF();

    [MemberFunction("48 89 5C 24 ?? 66 44 89 49")]
    public partial void AssignIndividual(int nRowId, short* pSubRowIds, short nSubRowCount);

    // [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 20 48 89 43 30")]
    // public partial void AssignByRowId(int nRowId);
}
