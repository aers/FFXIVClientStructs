namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct hkTypeInfoRegistry {
    [FieldOffset(0x0)] public hkReferencedObject hkReferencedObject;
    // [FieldOffset(0x10)] public hkStringMap<Pointer<hkTypeInfo>, hkContainerHeapAllocator> TypeMap;
    [FieldOffset(0x28)] public int FinishFlag;
    [FieldOffset(0x2C)] public int InformMemoryTracker;
}
