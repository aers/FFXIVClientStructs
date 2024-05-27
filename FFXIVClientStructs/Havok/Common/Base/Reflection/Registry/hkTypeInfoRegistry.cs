using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Common.Base.Reflection.Registry;

[GenerateInterop, Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct hkTypeInfoRegistry {
    // [FieldOffset(0x10)] public hkStringMap<Pointer<hkTypeInfo>, hkContainerHeapAllocator> TypeMap;
    [FieldOffset(0x28)] public int FinishFlag;
    [FieldOffset(0x2C)] public int InformMemoryTracker;
}
