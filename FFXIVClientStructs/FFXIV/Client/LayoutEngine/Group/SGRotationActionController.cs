using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SGRotationActionController
//   Client::LayoutEngine::Group::SGActionController
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
