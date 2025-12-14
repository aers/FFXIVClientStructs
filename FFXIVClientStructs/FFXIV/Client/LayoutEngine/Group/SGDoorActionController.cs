using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SGDoorActionController
//   Client::LayoutEngine::Group::SGActionController
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
