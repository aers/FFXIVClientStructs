using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Node;
using FFXIVClientStructs.FFXIV.Client.Sound;
using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::SoundLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
//   Client::System::Resource::ResourceEventListener
[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct SoundLayoutInstance {
    [FieldOffset(0x38)] public SoundData* SoundData;
    [FieldOffset(0x40)] public uint PathCrc;
    [FieldOffset(0x48)] public SoundResourceHandle* ResourceHandle;
    [FieldOffset(0x48), Obsolete("Use ResourceHandle")] public ResourceHandle* Handle;
    [FieldOffset(0x50)] public Transform Transform;
    [FieldOffset(0x50), Obsolete("Use Transform.Translation")] public global::System.Numerics.Vector3 Translation;
    [FieldOffset(0x60), Obsolete("Use Transform.Rotation")] public global::System.Numerics.Quaternion Rotation;
    [FieldOffset(0x70), Obsolete("Use Transform.Scale")] public global::System.Numerics.Vector3 Scale;
    [FieldOffset(0x80)] public QuantizedTransform QuantizedTransform;

    [FieldOffset(0x98)] public SoundLayoutOptions* SoundLayoutOptions;
    [FieldOffset(0xA0)] public ushort SoundDataSize;

    [FieldOffset(0xB0)] public ChildNodeContainer Instances;
}
