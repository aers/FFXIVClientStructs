using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Model
//   Client::Graphics::Render::RenderObject
//     Client::Graphics::ReferencedClassBase
[GenerateInterop]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct Model {
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

    [FieldOffset(0xAC)] public uint EnabledAttributeIndexMask;
    [FieldOffset(0xC8)] public uint EnabledShapeKeyIndexMask;

    [FieldOffset(0xE8)] public uint SlotIndex;

    public ReadOnlySpan<Pointer<Material>> MaterialsSpan
        => new(Materials, MaterialCount);


    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 8B 07 48 8B CF FF 50 ?? 32 C0")]
    public partial bool ModelDrawInit(ModelResourceHandle* mdlHandle, ModelRenderer.Callback* renderModelCallback, ModelRenderer.Callback* renderMaterialCallback);
}
