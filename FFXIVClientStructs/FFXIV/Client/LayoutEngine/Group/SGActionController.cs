using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct SGActionController {
    [FieldOffset(0x08)] public SharedGroupLayoutInstance* Owner;
    // SGDoorActionController: 1-3
    // SGRotationActionController? 4-5
    // SGMovePathActionController: 8-9
    // SGClockActionController: 10
    // SGTransformActionController: 12-13
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

[GenerateInterop]
[Inherits<SGActionController>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct SGDoorActionController {
    [FieldOffset(0x28)] public DoorState State; // 0 = opening; 1 = open; 2 = closing; 3 = closed
    // 0: majority of door-type doors (e.g. Limsa)
    // 1: unknown, but only sets translation, like 2
    // 2: sliding doors (e.g. Southern Thanalan)
    [FieldOffset(0x2C)] public int DoorType;
    [FieldOffset(0x40)] public float MaxRotation; // radians
    [FieldOffset(0x44)] public float MaxTranslation;
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray4<Pointer<BgPartsLayoutInstance>> _doorObjects;
    [FieldOffset(0x68)] public DoorRangeLayoutInstance* Range;
    [FieldOffset(0x70)] public SoundLayoutInstance* Sound1;
    [FieldOffset(0x78)] public SoundLayoutInstance* Sound2;
    [FieldOffset(0x80)] public SoundLayoutInstance* Sound3;
    [FieldOffset(0x88)] public CollisionBoxLayoutInstance* Collision;

    [FieldOffset(0xB0), FixedSizeArray] internal FixedSizeArray4<Transform> _baseTransforms;

    [FieldOffset(0x170), FixedSizeArray] internal FixedSizeArray4<Common.Math.Vector3> _translationsArray;
    [FieldOffset(0x1B0), FixedSizeArray] internal FixedSizeArray4<Quaternion> _rotationsArray;

    public enum DoorState : int {
        Opening = 0,
        Open = 1,
        Closing = 2,
        Closed = 3
    }
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

[GenerateInterop]
[Inherits<SGActionController>]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public partial struct SGMovePathActionController {
    [FieldOffset(0x30)] public float Progress; // fractional representation
    [FieldOffset(0x34)] public float DurationSeconds;
    [FieldOffset(0x40)] public float ProgressSeconds;
    [FieldOffset(0x50)] public Transform TransformBase;
}
