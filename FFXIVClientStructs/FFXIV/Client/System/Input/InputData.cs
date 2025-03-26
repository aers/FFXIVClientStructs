namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::InputData
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x9D0)]
public unsafe partial struct InputData {
    [FieldOffset(0x8)] public GamepadInputData GamepadInputs;
    [FieldOffset(0x254)] public GamepadInputData GamepadInputs2;
    /*
     * UIFiltered means those are not set if
     * - the game window is focused and
     * - the cursor is hovering any interactable UI elements or windows
     *
     * For mouse buttons, only Left and Right buttons are filtered out, extra buttons are not
     */
    [FieldOffset(0x4A0)] public CursorInputData UIFilteredCursorInputs;
    [FieldOffset(0x4D0)] public CursorInputData CursorInputs;
    /*
     * All the following keyboard keys states are not triggered if the chat input is active
     */
    [FieldOffset(0x500)] public KeyboardInputData KeyboardInputs;
}

[StructLayout(LayoutKind.Explicit, Size = 0x24C)]
public struct GamepadInputData {
    [FieldOffset(0x0)] public int LeftStickX; // from -99 (Right) to 99 (Left)
    [FieldOffset(0x4)] public int LeftStickY; // from -99 (Down) to 99 (Up)
    [FieldOffset(0x8)] public int RightStickX; // from -99 (Right) to 99 (Left)
    [FieldOffset(0xC)] public int RightStickY; // from -99 (Down) to 99 (Up)
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

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct CursorInputData {
    [FieldOffset(0x0)] public int PositionX;
    [FieldOffset(0x4)] public int PositionY;
    [FieldOffset(0x8)] public int MouseWheel; // -1 for scroll down, 1 for scroll up
    [FieldOffset(0xC)] public MouseButtonFlags MouseButtonHeldFlags;
    [FieldOffset(0x10)] public MouseButtonFlags MouseButtonPressedFlags;
    [FieldOffset(0x14)] public MouseButtonFlags MouseButtonReleasedFlags;
    [FieldOffset(0x18)] public MouseButtonFlags MouseButtonHeldThrottledFlags;

    [FieldOffset(0x20)] public int DeltaX; // Delta since last frame
    [FieldOffset(0x24)] public int DeltaY; // Delta since last frame

    // At least this is what it seems to be
    [FieldOffset(0x2C)] public bool IsGameWindowFocused;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x494)]
public partial struct KeyboardInputData {
    /*
     * This one is weird. Seems to fire as long as the last key pressed is still held
     * Except modifiers (ctrl, shift, alt) where it only fires once
     * If fires less often than the "Down" flag in the array below but more often than the "Held" one
     * So Im not sure what to make of this or if this is even useful
     */
    //[FieldOffset(0x0)] public int IsLastKeyboardKeyDownThrottled;

    [FieldOffset(0x4), FixedSizeArray] internal FixedSizeArray159<KeyStateFlags> _keyState;

    //[FieldOffset(0x284)] public byte UnkFlag;
    [FieldOffset(0x285)] public byte KeyHeldKeycode;

    /*
     * Those two seem unreliable in how they're set. They work well on keypress
     * but one or the other will get nulled after a few ms when the key is held
     * or won't have their value changed on release.
     */
    [FieldOffset(0x288)] public byte LastKeyCharKeyCode; // (key code of the character just below, ie `97` for a lowercase `a`)
    [FieldOffset(0x290)] public char LastKeyChar; // (actual character made by key combination, ie `a` or `A`)
}

[Flags]
public enum GamepadButtonsFlags : ushort {
    None = 0,
    DPadUp = 1,
    DPadDown = 2,
    DPadLeft = 4,
    DPadRight = 8,
    Triangle = 16,
    Cross = 32,
    Square = 64,
    Circle = 128,
    L1 = 256,
    L2 = 512,
    L3 = 1024,
    R1 = 2048,
    R2 = 4096,
    R3 = 8192,
    Select = 16384,
    Start = 32768,
}

[Flags]
public enum MouseButtonFlags {
    LBUTTON = 1,
    MBUTTON = 2,
    RBUTTON = 4,
    XBUTTON1 = 8,
    XBUTTON2 = 16,
}

/*
 * Pressed and Held will always be accompanied by Down,
 * so actual possible values returned by GetKeyState will be 1, 3, 4 or 9
 */
[Flags]
public enum KeyStateFlags {
    Down = 1,
    Pressed = 2,
    Released = 4,
    Held = 8, // like Down but fires first after about 250ms and then only about every 50 ms
}
