using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::BoneKineDriver - tentative name
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
[GenerateInterop]
public unsafe partial struct BoneKineDriverModule {
    [FieldOffset(0x08)] public Skeleton* Skeleton;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<PartialSkeletonEntry> _partialSkeletonEntries;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct PartialSkeletonEntry {
        [FieldOffset(0x00)] public ResourceHandle* KineDriverResourceHandle;
    }
}
