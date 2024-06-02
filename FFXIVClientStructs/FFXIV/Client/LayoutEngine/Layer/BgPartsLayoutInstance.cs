using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::BgPartsLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
/// <summary>
/// A simple static model with an optional collider.
/// </summary>
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct BgPartsLayoutInstance {
    [FieldOffset(0x30)] public void* GraphicsObject; // Client::Graphics::Scene::BGObject*
    [FieldOffset(0x38)] public Collider* Collider;
    [FieldOffset(0x40)] public uint CollisionMeshPathCrc;
    [FieldOffset(0x44)] public uint AnalyticShapeDataCrc;
    [FieldOffset(0x48)] public uint CollisionMaterialIdLow;
    [FieldOffset(0x4C)] public uint CollisionMaterialMaskLow;
    [FieldOffset(0x50)] public uint CollisionMaterialIdHigh;
    [FieldOffset(0x54)] public uint CollisionMaterialMaskHigh;
    //[FieldOffset(0x58)] public float u58;
    //[FieldOffset(0x5C)] public int u5C;
    [FieldOffset(0x60)] public void* CollisionUpdateListener;
}
