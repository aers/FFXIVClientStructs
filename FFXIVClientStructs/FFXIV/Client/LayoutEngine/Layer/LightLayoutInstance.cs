using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::LightLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct LightLayoutInstance {
    [FieldOffset(0x30)] public Light* GraphicsObject;
    [FieldOffset(0x38)] public LightType LightType;
    [FieldOffset(0x3C)] public Vector4 Color;
}

public enum LightType {
    None = 0,
    Directional = 1,
    Point = 2,
    Spot = 3,
    Plane = 4,
    Line = 5,
    Specular = 6,
}
