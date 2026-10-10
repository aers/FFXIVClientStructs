using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::CullingBoxLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct CullingBoxLayoutInstance {
    [FieldOffset(0x30)] private uint Unk30;
    [FieldOffset(0x38)] public CullingBox* GraphicsObject;
}
