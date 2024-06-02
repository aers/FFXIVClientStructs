using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Common.SceneData.Mesh;

[GenerateInterop]
[Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct hkxMesh {
    // hkArray<hkRefPtr<hkxMeshSection>> m_sections;
    // hkArray<hkRefPtr<hkxMesh::UserChannelInfo>> m_userChannelInfos;
}
