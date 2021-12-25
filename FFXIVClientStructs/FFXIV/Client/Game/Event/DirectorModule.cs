using System.Runtime.InteropServices;
using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event {
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public unsafe struct DirectorModule {
        [FieldOffset(0x00)] public ModuleBase ModuleBase;
        [FieldOffset(0x40)] public StdVector<Pointer<Director>> DirectorList;
        [FieldOffset(0x98)] public Director* ActiveInstanceDirector;
    }
}
