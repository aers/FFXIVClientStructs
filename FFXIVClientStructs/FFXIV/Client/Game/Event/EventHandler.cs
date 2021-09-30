using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event {
    [StructLayout(LayoutKind.Explicit, Size = 0x210)]
    public unsafe struct EventHandler {
        [FieldOffset(0xC8)] public Utf8String Unk_C8_String;
        [FieldOffset(0x168)] public Utf8String Unk_168_String;
    }
}