namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkBuiltinTypeRegistry {
    [FieldOffset(0x0)] public hkReferencedObject hkReferencedObject;

    [StaticAddress("8B DA 48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 28", 5, isPointer: true)]
    public static partial hkBuiltinTypeRegistry* Instance();

    [VirtualFunction(4)]
    public partial hkTypeInfoRegistry* GetTypeInfoRegistry();

    [VirtualFunction(5)]
    public partial hkClassNameRegistry* GetClassNameRegistry();
}
