using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Completion;

// Component::Completion::CategoryData
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public struct CategoryData {
    [FieldOffset(0x08)] public StdVector<CStringPointer> CompletionTexts;
    [FieldOffset(0x20)] public StdVector<CompletionDataStruct> CompletionData;
    // [FieldOffset(0x38)] private StdVector<{ 4 bytes }> Unk38;
    [FieldOffset(0x50)] private Utf8String Unk50;
    /// <remarks> Zero-indexed (Group - 1) </remarks>
    [FieldOffset(0xB8)] public byte Group;
    /// <remarks> Index of <see cref="CompletionModule.SheetNames"/> </remarks>
    [FieldOffset(0xB9)] public byte SheetNameIndex;
    [FieldOffset(0xBA)] private short UnkBA;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct CompletionDataStruct {
        [FieldOffset(0x00)] public ushort Group;
        [FieldOffset(0x02)] public ushort Key;
        [FieldOffset(0x04)] public byte RowId;
    }
}
