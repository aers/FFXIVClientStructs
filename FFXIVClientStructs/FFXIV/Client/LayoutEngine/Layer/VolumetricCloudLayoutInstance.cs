using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::VolumetricCloudLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct VolumetricCloudLayoutInstance {
    [FieldOffset(0x38)] public Vector4 Color;
    [FieldOffset(0x50)] public Transform Transform;
}
