using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::CullingBox
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
/// <summary> Occluder box of a culling box layout instance, added to <see cref="Culling.CullingManager.Occluders"/> on creation. </summary>
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public partial struct CullingBox {
    /// <summary> World space corners, updated with the transform. </summary>
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray8<Vector4> _corners;
}
