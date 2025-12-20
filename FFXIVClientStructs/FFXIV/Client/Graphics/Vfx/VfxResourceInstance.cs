using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

// best guess at namespace, VfxResourceInstanceListenner is related and belongs in ::Graphics::Vfx
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe struct VfxResourceInstance {
    [FieldOffset(0x08)] internal VfxResourceUnk* VfxResourceUnk;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
internal unsafe struct VfxResourceUnk {
    [FieldOffset(0x18)] public ApricotResourceHandle* ApricotResourceHandle;
}
