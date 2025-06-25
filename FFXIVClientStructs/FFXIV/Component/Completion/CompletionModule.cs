using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FixedSheetInterface = FFXIVClientStructs.FFXIV.Component.Text.TextModuleInterface.FixedSheetInterface;

namespace FFXIVClientStructs.FFXIV.Component.Completion;

// Component::Completion::CompletionModule
//   Component::Completion::CompletionModuleInterface
//   Component::Text::TextModuleInterface::FixedSheetInterface
//   Component::Excel::ExcelLanguageEvent
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<CompletionModuleInterface>, Inherits<FixedSheetInterface>, Inherits<ExcelLanguageEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public unsafe partial struct CompletionModule {
    [FieldOffset(0x18)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x20)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x28)] private bool Unk28;
    [FieldOffset(0x29)] private byte Unk29;

    [FieldOffset(0x30)] public StdVector<Pointer<CategoryData>> CategoryData;
    [FieldOffset(0x48)] public StdVector<CStringPointer> CategoryNames;
    [FieldOffset(0x60)] private StdVector<CategoryData.CompletionDataStruct> Unk60;
    [FieldOffset(0x78)] private StdVector<byte> Unk78;

    [FieldOffset(0xD0)] private Utf8String UnkD0;
    [FieldOffset(0x138)] private Utf8String Unk138;
    [FieldOffset(0x1A0)] private Utf8String Unk1A0;
    [FieldOffset(0x208)] private Utf8String Unk208;

    [FieldOffset(0x278)] public StdVector<Utf8String> CompanionNames;
    [FieldOffset(0x290)] public StdVector<SheetName> SheetNames;
    [FieldOffset(0x2A8)] public Utf8String OpenIconMacro;
    [FieldOffset(0x310)] public Utf8String CloseIconMacro;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 1B 41 FF C7"), GenerateStringOverloads]
    public partial void AddCompletionEntry(long groupIndex, uint rowId, CStringPointer itemText, CStringPointer groupTitle, ushort itemKey);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 3C 23"), GenerateStringOverloads]
    public partial CategoryData* AddCategoryData(long groupIndex, CStringPointer itemText, CStringPointer groupTitle, CategoryData* categoryData);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B 6C 24 ??")]
    public partial void ClearCompletionData();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 8E ?? ?? ?? ?? 0F 28 CE")]
    public partial void Update(Utf8String* completionSheetName, Utf8String* openIconMacro, Utf8String* closeIconMacro, nint a5);

    [VirtualFunction(5)]
    public partial int GetSelection(CategoryData.CompletionDataStruct* dataStructs, int index, Utf8String* outputString, Utf8String* outputDisplayString);

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct SheetName {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public bool IsNoun;
    }
}
