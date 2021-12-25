using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event {
    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public unsafe struct EventHandlerModule {
        [FieldOffset(0x00)] public ModuleBase ModuleBase;
    }
}
