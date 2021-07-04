using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render
{
    // Client::Graphics::Render::Skeleton
    //   Client::Graphics::ReferencedClassBase

    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public unsafe struct Skeleton
    {
        [FieldOffset(0x0)] public ReferencedClassBase ReferencedClassBase;

        // all Skeleton objects are in a global linked list enforced by base class RenderObjectList
        [FieldOffset(0x10)] public Skeleton* LinkedListPrevious;
        [FieldOffset(0x18)] public Skeleton* LinkedListNext;
        [FieldOffset(0x20)] public Transform Transform;
        [FieldOffset(0x50)] public ushort PartialSkeletonCount;

        [FieldOffset(0x58)]
        public void**
            SKLBArray; // Client::System::Resource::Handle::SkeletonResourceHandle pointer array, size = PartialSkeletonCount

        // 60: unk
        [FieldOffset(0x68)]
        public void*
            PartialSkeletonArray; // Client::Graphics::Animation::PartialSkeleton array, size = PartialSkeletonCount

        [FieldOffset(0xB8)] public CharacterBase* Owner;
    }
}