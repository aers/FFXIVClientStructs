using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::PopRangeLayoutInstance
//   Client::LayoutEngine::Layer::RangeLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
/// <summary>
/// Represents a place to spawn players and can contain several points within.
/// </summary>
[GenerateInterop]
[Inherits<RangeLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct PopRangeLayoutInstance {
    [FieldOffset(0x70)] public uint PopType;
    [FieldOffset(0x74)] public uint PositionCount;
    [FieldOffset(0x78)] public float InnerRadiusRatio;
    [FieldOffset(0x80)] public StdVector<Vector3> Positions;
}
