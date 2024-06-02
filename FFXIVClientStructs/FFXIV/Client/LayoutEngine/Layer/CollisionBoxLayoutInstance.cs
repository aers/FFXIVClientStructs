namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::CollisionBoxLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct CollisionBoxLayoutInstance {
    [FieldOffset(0x80)] public uint MaterialIdLow;
    [FieldOffset(0x84)] public uint MaterialMaskLow;
    [FieldOffset(0x88)] public uint MaterialIdHigh;
    [FieldOffset(0x8C)] public uint MaterialMaskHigh;
    [FieldOffset(0x90)] public uint PcbPathCrc;
    [FieldOffset(0x94)] public bool LayerMaskIs43h;
    [FieldOffset(0x98)] public void* CollisionUpdateListener;
}
