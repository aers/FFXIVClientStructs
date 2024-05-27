using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Common.SceneData.Mesh;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkxMesh {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    // hkArray<hkRefPtr<hkxMeshSection>> m_sections;
    // hkArray<hkRefPtr<hkxMesh::UserChannelInfo>> m_userChannelInfos;
}
