using System;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Fate
{
    // Size taken from dtor, no vtbl
    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct FateManager
    {
        [FieldOffset(0x60)] public IntPtr Unk60;
        [FieldOffset(0x68)] public IntPtr Unk68;
        [FieldOffset(0x70)] public IntPtr Unk70;
        [FieldOffset(0x78)] public IntPtr Unk78;
        [FieldOffset(0x80)] public IntPtr Unk80;
        [FieldOffset(0x90)] public IntPtr FirstFatePtr;
        [FieldOffset(0x98)] public IntPtr LastFatePtr;
    }
}
