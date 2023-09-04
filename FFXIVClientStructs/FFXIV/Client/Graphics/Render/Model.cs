using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe struct Model {
    [FieldOffset(0x00)] public ReferencedClassBase ReferencedClassBase;
    [FieldOffset(0x18)] public Model* Previous;
    [FieldOffset(0x20)] public Model* Next;

    [FieldOffset(0x30)] public ModelResourceHandle* ModelResourceHandle;

    [FieldOffset(0x40)] public Skeleton* Skeleton;

    [FieldOffset(0x98)] public Material** Materials;
    [FieldOffset(0xA0)] public int MaterialCount;
}
