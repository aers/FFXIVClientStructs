namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size=0x10)]
public unsafe partial struct hkBuiltinTypeRegistry
{
    [FieldOffset(0x0)] public hkReferencedObject hkReferencedObject;

    [StaticAddress("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 28", 8, isPointer: true)]
    public static partial hkBuiltinTypeRegistry* GetSingleton();

    [VirtualFunction(4)]
    public partial hkTypeInfoRegistry* GetTypeInfoRegistry();

    [VirtualFunction(5)]
    public partial hkClassNameRegistry* GetClassNameRegistry();
}