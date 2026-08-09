using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::VfxLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct VfxLayoutInstance {
    [FieldOffset(0x30)] public VfxObject* GraphicsObject;
    [FieldOffset(0x40)] public Transform Transform;
    [FieldOffset(0x70)] public uint PathCrc;
    [FieldOffset(0x74)] public float FadeNearStart;
    [FieldOffset(0x78)] public float FadeNearEnd;
    [FieldOffset(0x7C)] public float FadeFarStart;
    [FieldOffset(0x80)] private float Unk80;
    [FieldOffset(0x84)] public float FadeFarEnd;
    [FieldOffset(0x88)] public float ZCorrect;
    [FieldOffset(0x8C)] public float SoftParticleFadeRange;
    [FieldOffset(0x90)] public ByteColor Color;
    [FieldOffset(0x94)] private float Unk94;
    [FieldOffset(0x98)] private float Unk98;
    [FieldOffset(0x9C)] public byte Flags;
}
