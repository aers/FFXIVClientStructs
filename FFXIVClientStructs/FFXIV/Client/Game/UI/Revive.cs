using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI {
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct Revive {
        [FieldOffset(0x00)] public void* vtbl;
    }
}
