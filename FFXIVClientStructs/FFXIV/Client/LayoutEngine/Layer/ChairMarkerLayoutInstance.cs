namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::ChairMarkerLayoutInstance
//   Client::LayoutEngine::Layer::MarkerLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[Inherits<MarkerLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct ChairMarkerLayoutInstance {
    [FieldOffset(0x70)] public ChairMarkerEnableFlags EnableFlags;
    [FieldOffset(0x74)] public ChairMarkerObjectType ObjectType;
}

[Flags]
public enum ChairMarkerEnableFlags : byte {
    Front = 1 << 0,
    Right = 1 << 1,
    Back = 1 << 2,
    Left = 1 << 3,
}

public enum ChairMarkerObjectType : byte {
    Chair = 0,
    Bed = 1,
}
