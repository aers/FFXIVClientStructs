namespace FFXIVClientStructs.Interop.DirectInput;

/// <summary>
/// DIDEVICEINSTANCEA
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x244)]
public partial struct DIDeviceInstance {
    [FieldOffset(0x00)] public uint Size;
    [FieldOffset(0x04)] public Guid Instance;
    [FieldOffset(0x14)] public Guid Product;
    [FieldOffset(0x24)] public uint DevType;
    [FieldOffset(0x28), FixedSizeArray(isString: true)] internal FixedSizeArray260<byte> _InstanceName;
    [FieldOffset(0x12C), FixedSizeArray(isString: true)] internal FixedSizeArray260<byte> _ProductName;
    [FieldOffset(0x230)] public Guid FFDriver;
    [FieldOffset(0x240)] public ushort UsagePage;
    [FieldOffset(0x242)] public ushort Usage;
}
