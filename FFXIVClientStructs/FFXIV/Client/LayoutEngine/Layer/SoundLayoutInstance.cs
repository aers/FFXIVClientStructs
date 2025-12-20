using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Node;
using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using static FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group.SharedGroupLayoutInstance;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct SoundLayoutInstance {
    [FieldOffset(0x40)] public uint PathCrc;
    [FieldOffset(0x48)] public ResourceHandle* Handle;
    [FieldOffset(0x50)] public Vector3 Translation;
    [FieldOffset(0x60)] public Quaternion Rotation;
    [FieldOffset(0x70)] public Vector3 Scale;
    [FieldOffset(0xB0)] public ChildNodeContainer Instances;
}
