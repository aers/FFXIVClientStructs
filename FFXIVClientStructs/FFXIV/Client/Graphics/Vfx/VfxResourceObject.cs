using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct VfxResourceObject {
    [FieldOffset(0x18)] public ApricotResourceHandle* ApricotResourceHandle;
}
