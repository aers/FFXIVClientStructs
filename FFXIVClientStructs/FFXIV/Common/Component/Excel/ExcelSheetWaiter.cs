using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheetWaiter
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct ExcelSheetWaiter {
    [FieldOffset(0x08)] public uint RowDescriptorCount;
    [FieldOffset(0x0C)] private uint UnkC; // row counter?

    [FieldOffset(0x18)] public long SheetIndex;
    [FieldOffset(0x20)] public DescriptorRowWrapperEntry* RowDescriptors;
    [FieldOffset(0x28)] public ExcelRow** Rows;

    [VirtualFunction(0)]
    public partial ExcelSheetWaiter* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? C0 E3")]
    public partial void Reset();

    [MemberFunction("E8 ?? ?? ?? ?? 48 39 6B")]
    public partial void Prepare(uint a2, uint rowDescriptorCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 74 24 ?? BF")]
    public partial void SetSheetIndex(long sheetIndex);

    [MemberFunction("E8 ?? ?? ?? ?? FF C7 4D 8D B6")]
    public partial void SetRowDescriptor(uint index, ExcelRowDescriptor* descriptor);

    /// <summary> Sets a <see cref="ExcelRowDescriptor"/> with the given <paramref name="rowId"/> at given <paramref name="index"/>. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 94 EE")]
    public partial void EnqueueRowLookup(uint index, uint rowId);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct DescriptorRowWrapperEntry {
        [FieldOffset(0x00)] public ExcelRowDescriptor Descriptor;
        [FieldOffset(0x10)] public IExcelRowWrapper* RowWrapper;
    }
}
