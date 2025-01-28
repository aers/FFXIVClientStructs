using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Completion;

// Component::Completion::CategoryData
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public struct CategoryData {
    [FieldOffset(0x08)] public StdVector<CString> CompletionTexts;
    [FieldOffset(0x20)] public StdVector<CompletionDataStruct> CompletionData;
    // [FieldOffset(0x38)] private StdVector<{ 4 bytes }> Unk38;
    [FieldOffset(0x50)] private Utf8String Unk50;
    /// <remarks> Zero-indexed (Group - 1) </remarks>
    [FieldOffset(0xB8)] public byte Group;
    [FieldOffset(0xB9)] private byte UnkB9;
    [FieldOffset(0xBA)] private short UnkBA;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct CompletionDataStruct {
        [FieldOffset(0x00)] public ushort Group;
        [FieldOffset(0x02)] public ushort Key;
        [FieldOffset(0x04)] public byte RowId;
    }
}
