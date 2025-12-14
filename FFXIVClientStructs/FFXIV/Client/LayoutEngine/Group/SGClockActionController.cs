using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SGClockActionController
//   Client::LayoutEngine::Group::SGActionController
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
