namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::FateRangeLayoutInstance
//   Client::LayoutEngine::Layer::RangeLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<RangeLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct FateRangeLayoutInstance {
    [FieldOffset(0x70)] public uint FateLayoutLabelId;
}
