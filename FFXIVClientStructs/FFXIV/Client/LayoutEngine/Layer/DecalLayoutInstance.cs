using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::DecalLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct DecalLayoutInstance {
    [FieldOffset(0x30)] public Decal* GraphicsObject;
}
