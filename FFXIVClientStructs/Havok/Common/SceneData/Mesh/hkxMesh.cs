namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkxMesh {
    [FieldOffset(0x00)] hkReferencedObject hkReferencedObject;
    // hkArray<hkRefPtr<hkxMeshSection>> m_sections;
    // hkArray<hkRefPtr<hkxMesh::UserChannelInfo>> m_userChannelInfos;
}
