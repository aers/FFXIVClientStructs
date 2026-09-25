namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheetWaiter
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct ExcelSheetWaiter {
    [VirtualFunction(0)]
    public partial ExcelSheetWaiter* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 94 EE")]
    public partial void EnqueueRowLookup(uint index, uint rowId);
}
