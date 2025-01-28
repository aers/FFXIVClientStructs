using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Completion;

// Component::Completion::CompletionModule
[GenerateInterop]
[Inherits<ExcelLanguageEvent>(0x10)]
[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public unsafe partial struct CompletionModule {
    [FieldOffset(0x28)] public StdVector<Pointer<CategoryData>> CategoryData;
    [FieldOffset(0x40)] public StdVector<CString> CategoryNames;
    // [FieldOffset(0x58)] public StdVector<{ 8 bytes }> Unk58;
    [FieldOffset(0x70)] private StdVector<byte> Unk70;

    [FieldOffset(0xD0)] private Utf8String UnkC8;
    [FieldOffset(0x138)] private Utf8String Unk138;
    [FieldOffset(0x1A0)] private Utf8String Unk1A0;
    [FieldOffset(0x208)] private Utf8String Unk208;

    [FieldOffset(0x270)] public StdVector<Utf8String> CompanionNames;
    [FieldOffset(0x288)] public StdVector<SheetName> SheetNames;
    [FieldOffset(0x2A0)] private Utf8String Unk2A8;
    [FieldOffset(0x308)] private Utf8String Unk310;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct SheetName {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] private byte IsCompanionSheet; // idk, it's the only entry where this is 1
    }
}
