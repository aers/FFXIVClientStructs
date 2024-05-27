using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe struct Model {
    [FieldOffset(0x00)] public ReferencedClassBase ReferencedClassBase;
    [FieldOffset(0x18)] public Model* Previous;
    [FieldOffset(0x20)] public Model* Next;

    [FieldOffset(0x30)] public ModelResourceHandle* ModelResourceHandle;

    [FieldOffset(0x40)] public Skeleton* Skeleton;

    [FieldOffset(0x48)] public ModelRenderer.Callback* RenderModelCallback;
    [FieldOffset(0x50)] public ModelRenderer.Callback* RenderMaterialCallback;

    [FieldOffset(0x58)] public void** BoneList;
    [FieldOffset(0x60)] public int BoneCount;

    [FieldOffset(0x98)] public Material** Materials;
    [FieldOffset(0xA0)] public int MaterialCount;

    [FieldOffset(0xE8)] public uint SlotIndex;

    public readonly ReadOnlySpan<Pointer<Material>> MaterialsSpan
        => new(Materials, MaterialCount);
}
