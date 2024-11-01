using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkMessageBoxManager
//   Common::Component::Excel::ExcelSheetWaiter
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AtkMessageBoxManager {
    [FieldOffset(0x60)] public ExcelSheet* ErrorSheet;
    [FieldOffset(0x68)] public byte* OkText;
    [FieldOffset(0x70)] public byte* CancelText;
    [FieldOffset(0x78)] public byte* YesText;
    [FieldOffset(0x80)] public byte* NoText;
    [FieldOffset(0x88)] public byte Unk88;
    [FieldOffset(0x89)] public byte Unk89;
    [FieldOffset(0x8A)] public byte Unk8A;
}
