namespace FFXIVClientStructs.Interop.DirectInput;

/// <summary>
/// DIDEVCAPS
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x2C)]
public struct DIDeviceCapabilities {
    [FieldOffset(0x00)] public uint Size;
    [FieldOffset(0x04)] public uint Flags;
    [FieldOffset(0x08)] public uint DevType;
    [FieldOffset(0x0C)] public uint Axes;
    [FieldOffset(0x10)] public uint Buttons;
    [FieldOffset(0x14)] public uint POVs;
    [FieldOffset(0x18)] public uint FFSamplePeriod;
    [FieldOffset(0x1C)] public uint FFMinTimeResolution;
    [FieldOffset(0x20)] public uint FirmwareRevision;
    [FieldOffset(0x24)] public uint HardwareRevision;
    [FieldOffset(0x28)] public uint FFDriverVersion;
}
