namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkLocalFrame {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
}
