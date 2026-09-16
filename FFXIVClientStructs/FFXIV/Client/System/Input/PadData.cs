namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::PadData
[StructLayout(LayoutKind.Explicit, Size = 0x24C)]
public struct GamepadInputData { // TODO: rename struct to PadData
    [FieldOffset(0x00)] public int LeftStickX; // from -99 (Right) to 99 (Left)
    [FieldOffset(0x04)] public int LeftStickY; // from -99 (Down) to 99 (Up)
    [FieldOffset(0x08)] public int RightStickX; // from -99 (Right) to 99 (Left)
    [FieldOffset(0x0C)] public int RightStickY; // from -99 (Down) to 99 (Up)
    [FieldOffset(0x10)] public GamepadButtonsFlags Buttons; // Not always set if UI is focused
    [FieldOffset(0x14)] public GamepadButtonsFlags ButtonsPressed;
    [FieldOffset(0x18)] public GamepadButtonsFlags ButtonsReleased;
    [FieldOffset(0x20)] public GamepadButtonsFlags ButtonsRepeat;

    // These fields are only correct for actual physical Playstation Controllers
    // Tested with Sony DualSense Controller Model: CFI-ZCT1W
    [FieldOffset(0x24)] public float Square;
    [FieldOffset(0x28)] public float Cross;
    [FieldOffset(0x2C)] public float Circle;
    [FieldOffset(0x30)] public float Triangle;
    [FieldOffset(0x34)] public float L1;
    [FieldOffset(0x38)] public float R1;
    [FieldOffset(0x3C)] public float L2;
    [FieldOffset(0x40)] public float R2;
    [FieldOffset(0x48)] public float Start;
    [FieldOffset(0x4C)] public float L3;
    [FieldOffset(0x50)] public float R3;
    [FieldOffset(0x54)] public float PSButton;
    [FieldOffset(0x58)] public float Select;
    [FieldOffset(0x5C)] public float MuteButton;

    [FieldOffset(0xA4)] public float LeftStickLeft;
    [FieldOffset(0xA8)] public float LeftStickRight;

    [FieldOffset(0xC4)] public float LeftStickUp;
    [FieldOffset(0xC8)] public float LeftStickDown;

    [FieldOffset(0xE4)] public float RightStickLeft;
    [FieldOffset(0xE8)] public float RightStickRight;

    [FieldOffset(0x144)] public float RightStickUp;
    [FieldOffset(0x148)] public float RightStickDown;

    // These values are weird... When DPadLeft is pressed it'll have value 1.0f, but DPadUp will have value 8.74278E-08
    [FieldOffset(0x184)] public float DPadLeft;
    [FieldOffset(0x188)] public float DPadRight;
    [FieldOffset(0x18C)] public float DPadUp;
    [FieldOffset(0x190)] public float DPadDown;
}

[Flags]
public enum GamepadButtonsFlags : ushort {
    None = 0,
    DPadUp = 1 << 0,
    DPadDown = 1 << 1,
    DPadLeft = 1 << 2,
    DPadRight = 1 << 3,
    Triangle = 1 << 4,
    Cross = 1 << 5,
    Square = 1 << 6,
    Circle = 1 << 7,
    L1 = 1 << 8,
    L2 = 1 << 9,
    L3 = 1 << 10,
    R1 = 1 << 11,
    R2 = 1 << 12,
    R3 = 1 << 13,
    Select = 1 << 14,
    Start = 1 << 15,
}
