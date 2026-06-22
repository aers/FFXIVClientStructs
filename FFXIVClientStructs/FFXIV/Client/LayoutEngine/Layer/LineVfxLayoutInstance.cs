namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::LineVfxLayoutInstance
//   Client::LayoutEngine::Layer::RangeLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<RangeLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct LineVfxLayoutInstance {
    [FieldOffset(0x70)] public LineVfxStyle LineStyle;
}

public enum LineVfxStyle {
    Red = 1,
    Blue = 2,
    RedFar = 3, // sets LayoutWorld.StreamingRadiusPerType[InstanceType.LineVfx] to 40.0f
}
