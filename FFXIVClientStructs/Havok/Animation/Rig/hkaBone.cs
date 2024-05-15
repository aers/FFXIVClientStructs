namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkaBone {
    [FieldOffset(0x00)] public hkStringPtr Name;
    [FieldOffset(0x08)] public byte LockTranslation;
}
