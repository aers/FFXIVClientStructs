using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::ClientPathLayoutInstance
//   Client::LayoutEngine::Layer::PathLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<PathLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA30)]
public unsafe partial struct ClientPathLayoutInstance {
    [FieldOffset(0xA00)] private bool UnkA00;
    [FieldOffset(0xA20)] private Vector3 UnkA20;
}
