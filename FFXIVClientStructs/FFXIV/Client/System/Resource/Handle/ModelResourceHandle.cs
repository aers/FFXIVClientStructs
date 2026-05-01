namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ModelResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct ModelResourceHandle {

    [FieldOffset(0xC8)] public byte* ModelData; // StringTable, ModelHeader ...

    [FieldOffset(0x228)] public MaterialResourceHandle** MaterialResourceHandles;

    [FieldOffset(0x248)] public StdMap<CStringPointer, short> Attributes;
    [FieldOffset(0x268)] public StdMap<CStringPointer, short> Shapes;

    [MemberFunction("E8 ?? ?? ?? ?? 45 8B CE 48 89 44 24 ?? 41 B8 ?? ?? ?? ?? 48 8D 54 24")]
    public unsafe partial CStringPointer GetMaterialFileNameBySlot(uint slot);

    /// <summary>
    /// Synchronosly loads each of the materials and stores them in <see cref="MaterialResourceHandles"/>.
    /// </summary>
    /// <remarks>
    /// Not called when <see cref="Type"/> is <see cref="ResourceHandleType.HandleCategory.Chara"/>
    /// as character materials are loaded by the character itself.
    /// </remarks>
    /// <returns>Success or failure, with zero materials counting as a success.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 12 B0 F6")]
    public partial bool LoadMaterials();
}
