using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SGActionController
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
