using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct SGActionController {
    [FieldOffset(0x08)] public SharedGroupLayoutInstance* Owner;
    // SGRotationActionController? 4/5
    // SGClockActionController: 10
    // SGTransformActionController: 12/13
    [FieldOffset(0x18)] public uint AnimationType;
    [FieldOffset(0x20)] public float SpeedFactor; // not sure

    [MemberFunction("E8 ?? ?? ?? ?? FF C7 3B BB ?? ?? ?? ?? 72 9A")]
    public partial void SetTranslation(ILayoutInstance* instance, Vector3* translation);
    [MemberFunction("E8 ?? ?? ?? ?? 80 7F 42 00")]
    public partial void SetRotation(ILayoutInstance* instance, Quaternion* rotation);
    [MemberFunction("48 81 EC ?? ?? ?? ?? 4C 8B CA 48 85 D2 0F 84 ?? ?? ?? ?? 48 8B 51 08 48 85 D2 0F 84 ?? ?? ?? ?? 48 8B 82 ?? ?? ?? ?? 41 0F B6 49 ?? 48 89 9C 24 ?? ?? ?? ?? 48 8B 1C C8 48 8B CA F3 0F 10 43 ?? F3 0F 11 44 24 ?? F3 0F 10 4B ?? F3 0F 11 4C 24 ?? F3 0F 10 43 ?? F3 0F 11 44 24 ?? 0F 10 4B 30")]
    public partial void SetScale(ILayoutInstance* instance, Vector3* scale);
    [MemberFunction("48 85 D2 74 5D 57")]
    public partial void SetTransform(ILayoutInstance* instance, Transform* transform);

    [VirtualFunction(11)]
    public partial void Tick(float dt);
}

// applies a rotation
[GenerateInterop]
[Inherits<SGActionController>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct SGRotationActionController {
    [FieldOffset(0x41)] public bool HasChild1;
    [FieldOffset(0x42)] public bool HasChild2;

    [FieldOffset(0x48)] public SharedGroupLayoutInstance* ChildGroup;
    [FieldOffset(0x50)] public ILayoutInstance* Child1;
    [FieldOffset(0x58)] public ILayoutInstance* Child2;
    [FieldOffset(0x80)] public Quaternion GroupRotation;
    [FieldOffset(0x90)] public Quaternion ChildRotation1;
    [FieldOffset(0xA0)] public Quaternion ChildRotation2;
}

// sets rotation of objects based on ingame time of day
[GenerateInterop]
[Inherits<SGActionController>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct SGClockActionController {
    [FieldOffset(0x28)] public ILayoutInstance* Instance1;
    [FieldOffset(0x30)] public ILayoutInstance* Instance2;
    [FieldOffset(0x40)] public Quaternion RotationBase1;
    [FieldOffset(0x50)] public Quaternion RotationBase2;
    [FieldOffset(0x60)] public Quaternion Rotation1;
    [FieldOffset(0x70)] public Quaternion Rotation2;
}

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
