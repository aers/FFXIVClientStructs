using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SGTransformActionController
//   Client::LayoutEngine::Group::SGActionController
// applies some basic transformation that repeats infinitely with a fixed period, i.e. rotating aetherytes, hovering objects that oscillate up and down, etc.
[GenerateInterop]
[Inherits<SGActionController>]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct SGTransformActionController {
    [FieldOffset(0x29)] public bool Inverted;
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray16<Object> _objects;
    [FieldOffset(0x130)] public int NumObjects;

    [FieldOffset(0x140)] public Timer TranslationTimer;
    [FieldOffset(0x180)] public Timer RotationTimer;
    [FieldOffset(0x1C0)] public Timer ScaleTimer;
    [FieldOffset(0x200)] public Transform CurrentTransform;

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 95 ?? ?? ?? ?? 45 33 C0 C1 EA 02")]
    public partial void LoadFromFile(byte* data);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe partial struct Object {
        [FieldOffset(0)] public ILayoutInstance* Instance;
        [FieldOffset(8)] public Transform* Transform;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct Timer {
        [FieldOffset(0x00)] public uint Flags1;
        [FieldOffset(0x04)] public uint Flags2;

        [FieldOffset(0x08)] public float Elapsed;
        [FieldOffset(0x0C)] public float Period1;
        [FieldOffset(0x10)] public float Period2;

        // W component is only used in RotationTimer
        [FieldOffset(0x20)] public Vector4 Start;
        [FieldOffset(0x30)] public Vector4 End;
    }
}
