using System.Text;

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

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B CD 48 89 44 24 ?? 41 B8 ?? ?? ?? ??")]
    public unsafe partial CStringPointer GetMaterialFileNameBySlot(uint slot);
}
