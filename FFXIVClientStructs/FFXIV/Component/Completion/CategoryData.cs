using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Completion;

// Component::Completion::CategoryData
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public partial struct CategoryData {
    [FieldOffset(0x08)] public StdVector<CStringPointer> CompletionTexts;
    [FieldOffset(0x20)] public StdVector<CompletionDataStruct> CompletionData;
    // [FieldOffset(0x38)] private StdVector<{ 4 bytes }> Unk38;
    [FieldOffset(0x50)] private Utf8String Unk50;
    /// <remarks> Zero-indexed (Group - 1) </remarks>
    [FieldOffset(0xB8)] public byte Group;
    /// <remarks> Index of <see cref="CompletionModule.SheetNames"/> </remarks>
    [FieldOffset(0xB9)] public byte SheetNameIndex;
    [FieldOffset(0xBA)] private short UnkBA;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8D 05 ?? ?? ?? ?? 48 8B F1 48 89 01 41 0F B6 F8")]
    public partial void Ctor(byte group, byte sheetNameIndex);

    [MemberFunction("40 57 48 8B 79 28")]
    public partial void SortEntries();

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct CompletionDataStruct {
        [FieldOffset(0x00)] public ushort Group;
        [FieldOffset(0x02)] public ushort Key;
        [FieldOffset(0x04)] public uint RowId;
    }
}
