namespace FFXIVClientStructs.Interop.XInput;

/// <summary>
/// XINPUT_GAMEPAD
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x0C)]
public struct XInputGamepad {
    [FieldOffset(0x00)] public XInputGamepadButtons Buttons;
    [FieldOffset(0x02)] public byte LeftTrigger;
    [FieldOffset(0x03)] public byte RightTrigger;
    [FieldOffset(0x04)] public short ThumbLX;
    [FieldOffset(0x06)] public short ThumbLY;
    [FieldOffset(0x08)] public short ThumbRX;
    [FieldOffset(0x0A)] public short ThumbRY;
}
