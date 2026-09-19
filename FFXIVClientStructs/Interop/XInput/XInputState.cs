namespace FFXIVClientStructs.Interop.XInput;

/// <summary>
/// XINPUT_STATE
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct XInputState {
    [FieldOffset(0x00)] public uint PacketNumber;
    [FieldOffset(0x04)] public XInputGamepad Gamepad;
}
