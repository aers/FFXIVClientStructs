namespace FFXIVClientStructs.Interop.XInput;

/// <summary>
/// XINPUT_GAMEPAD_BUTTONS
/// </summary>
[Flags]
public enum XInputGamepadButtons : ushort {
    DPAD_UP = 0x0001,
    DPAD_DOWN = 0x0002,
    DPAD_LEFT = 0x0004,
    DPAD_RIGHT = 0x0008,
    START = 0x0010,
    BACK = 0x0020,
    LEFT_THUMB = 0x0040,
    RIGHT_THUMB = 0x0080,
    LEFT_SHOULDER = 0x0100,
    RIGHT_SHOULDER = 0x0200,
    A = 0x1000,
    B = 0x2000,
    X = 0x4000,
    Y = 0x8000,
}
