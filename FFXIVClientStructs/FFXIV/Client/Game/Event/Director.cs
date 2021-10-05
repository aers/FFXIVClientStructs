using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event {
    [StructLayout(LayoutKind.Explicit, Size = 0x4B8)]
    public unsafe struct Director {
        [FieldOffset(0x00)] public LuaEventHandler LuaEventHandler;
        [FieldOffset(0x350)] public Utf8String String0;
        [FieldOffset(0x3B8)] public Utf8String String1;
        [FieldOffset(0x420)] public Utf8String String2;
    }
}
