using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event {
    [StructLayout(LayoutKind.Explicit, Size = 0x210)]
    public unsafe struct EventHandler {
        [FieldOffset(0x18)] public void* EventSceneModule;
    }
}
