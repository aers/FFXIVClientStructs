namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::PositionMarkerLayoutInstance
//   Client::LayoutEngine::Layer::MarkerLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<MarkerLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct PositionMarkerLayoutInstance {
    [FieldOffset(0x70)] private uint Unk70;
}
