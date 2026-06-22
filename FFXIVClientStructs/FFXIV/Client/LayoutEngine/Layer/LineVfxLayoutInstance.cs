namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::LineVfxLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
/// <summary>
/// Box that encapsulates the vfx for zone lines.
/// </summary>
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct LineVfxLayoutInstance {
    [FieldOffset(0x30)] public Transform Transform;
}
