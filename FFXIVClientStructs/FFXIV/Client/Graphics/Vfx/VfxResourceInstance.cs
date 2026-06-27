namespace FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

// best guess at namespace, VfxResourceInstanceListenner is related and belongs in ::Graphics::Vfx
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe struct VfxResourceInstance {
    [FieldOffset(0x08)] public VfxResourceObject* VfxResourceObject;
}
