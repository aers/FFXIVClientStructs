namespace FFXIVClientStructs.Havok;

// NOTE: this is actually a hkStaticClassNameRegistry : hkClassNameRegistry, which the game uses
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct hkClassNameRegistry {
    [FieldOffset(0x0)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public byte* Name;
    [FieldOffset(0x18)] public hkClass* Classes;
    [FieldOffset(0x20)] public int ClassVersion;
    [FieldOffset(0x24)] public int Ready;

    [VirtualFunction(5)]
    [GenerateCStrOverloads]
    public partial hkClass* GetClassByName(byte* name);
}
