using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ModelResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public partial struct ModelResourceHandle {
    [FieldOffset(0x228)] public StdMap<Pointer<byte>, short> Attributes;
    [FieldOffset(0x248)] public StdMap<Pointer<byte>, short> Shapes;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B CD 48 89 44 24 ?? 41 B8 ?? ?? ?? ??")]
    public unsafe partial StringPointer GetMaterialFileNameBySlot(uint slot);
}
