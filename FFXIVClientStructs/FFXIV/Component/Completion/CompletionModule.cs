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

    [FieldOffset(0x30)] public StdVector<Pointer<CategoryData>> CategoryData;
    [FieldOffset(0x48)] public StdVector<CString> CategoryNames;
    // [FieldOffset(0x60)] public StdVector<{ 8 bytes }> Unk60;
    [FieldOffset(0x78)] private StdVector<byte> Unk78;

    [FieldOffset(0xD0)] private Utf8String UnkD0;
    [FieldOffset(0x138)] private Utf8String Unk138;
    [FieldOffset(0x1A0)] private Utf8String Unk1A0;
    [FieldOffset(0x208)] private Utf8String Unk208;

    [FieldOffset(0x278)] public StdVector<Utf8String> CompanionNames;
    [FieldOffset(0x290)] public StdVector<SheetName> SheetNames;
    [FieldOffset(0x2A8)] private Utf8String Unk2A8;
    [FieldOffset(0x310)] private Utf8String Unk310;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct SheetName {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public bool IsNoun;
    }
}
