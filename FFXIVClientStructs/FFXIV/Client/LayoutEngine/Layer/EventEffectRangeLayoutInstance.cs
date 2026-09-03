using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::EventEffectRangeLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x1270)]
public unsafe partial struct EventEffectRangeLayoutInstance {
    [FieldOffset(0x90)] public bool Active;
    [FieldOffset(0x94)] public float EffectPointSpacing;
    [FieldOffset(0x98)] public float EffectFarClipBegin;
    [FieldOffset(0x9C)] public float EffectFarClipEnd;
    [FieldOffset(0xA0)] public Vector3 EffectBoundsCenter;
    [FieldOffset(0xAC)] public float EffectBoundsRadius;
    [FieldOffset(0xB0)] public bool EffectsEnabled;
}
