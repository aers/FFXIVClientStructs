using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::ClipBoard
//   Client::System::Input::ClipBoardInterface
[GenerateInterop]
[Inherits<ClipBoardInterface>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 83 C1 08 E8 ?? ?? ?? ?? 48 8D 4B 70 E8 ?? ?? ?? ?? 48 8B C3", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct ClipBoard {
    [FieldOffset(0x08)] public Utf8String SystemClipboardText;
    [FieldOffset(0x70)] public Utf8String CopyStagingText;
}
