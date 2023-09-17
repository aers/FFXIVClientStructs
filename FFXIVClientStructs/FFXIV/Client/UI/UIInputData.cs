using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0xA20)]
public unsafe partial struct UIInputData {
    public static UIInputData* Instance() => Framework.Instance()->UIModule->GetUIInputData();

    [FieldOffset(0x8)] public int GamepadLeftStickX; // from -99 (Right) to 99 (Left)
    [FieldOffset(0xC)] public int GamepadLeftStickY; // from -99 (Down) to 99 (Up)
    [FieldOffset(0x10)] public int GamepadRightStickX; // from -99 (Right) to 99 (Left)
    [FieldOffset(0x14)] public int GamepadRightStickY; // from -99 (Down) to 99 (Up)
    [FieldOffset(0x18)] public GamepadButtonsFlags GamepadButtons; // Not always set if UI is focused

    [FieldOffset(0x2C)] public float Start;
    [FieldOffset(0x30)] public float Select;
    [FieldOffset(0x34)] public float L3;
    [FieldOffset(0x38)] public float R3;
    [FieldOffset(0x3C)] public float L1;
    [FieldOffset(0x40)] public float R1;
    [FieldOffset(0x44)] public float Cross;
    [FieldOffset(0x48)] public float Circle;
    [FieldOffset(0x4C)] public float Square;
    [FieldOffset(0x50)] public float Triangle;
    [FieldOffset(0xAC)] public float DPadLeft;
    [FieldOffset(0xB0)] public float DPadRight;
    [FieldOffset(0xB4)] public float DPadUp;
    [FieldOffset(0xB8)] public float DPadDown;
    [FieldOffset(0xBC)] public float GamepadLeftStickLeft;
    [FieldOffset(0xC0)] public float GamepadLeftStickRight;
    [FieldOffset(0xC4)] public float GamepadLeftStickUp;
    [FieldOffset(0xC8)] public float GamepadLeftStickDown;
    [FieldOffset(0xCC)] public float GamepadRightStickLeft;
    [FieldOffset(0xD0)] public float GamepadRightStickRight;
    [FieldOffset(0xD4)] public float GamepadRightStickUp;
    [FieldOffset(0xD8)] public float GamepadRightStickDown;
    [FieldOffset(0xE0)] public float L2;
    [FieldOffset(0xE8)] public float R2;

    /*
     * UIFiltered means those are not set if 
     * - the game window is focused and
     * - the cursor is hovering any interactable UI elements or windows
     * 
     * For mouse buttons, only Left and Right buttons are filtered out, extra buttons are not
     */
    [FieldOffset(0x498)] public int UIFilteredCursorXPosition;
    [FieldOffset(0x49C)] public int UIFilteredCursorYPosition;
    [FieldOffset(0x4A0)] public int UIFilteredMouseWheel; // -1 for scroll down, 1 for scroll up
    [FieldOffset(0x4A4)] public MouseButtonFlags UIFilteredMouseButtonHeldFlags;
    [FieldOffset(0x4A8)] public MouseButtonFlags UIFilteredMouseButtonPressedFlags;
    [FieldOffset(0x4B0)] public MouseButtonFlags UIFilteredMouseButtonReleasedFlags;
    [FieldOffset(0x4B4)] public MouseButtonFlags UIFilteredMouseButtonHeldThrottledFlags;
    [FieldOffset(0x4B8)] public int UIFilteredCursorXDelta; // Delta since last frame
    [FieldOffset(0x4BC)] public int UIFilteredCursorYDelta; // Delta since last frame

    // Same as 0x4F4 ?
    // [FieldOffset(0x4C4)] public byte IsGameWindowFocused;

    [FieldOffset(0x4C8)] public int CursorXPosition;
    [FieldOffset(0x4CC)] public int CursorYPosition;
    [FieldOffset(0x4D0)] public int MouseWheel; // -1 for scroll down, 1 for scroll up
    [FieldOffset(0x4D4)] public MouseButtonFlags MouseButtonHeldFlags;
    [FieldOffset(0x4D8)] public MouseButtonFlags MouseButtonPressedFlags;
    [FieldOffset(0x4E0)] public MouseButtonFlags MouseButtonReleasedFlags;
    [FieldOffset(0x4E4)] public MouseButtonFlags MouseButtonHeldThrottledFlags;
    [FieldOffset(0x4E8)] public int CursorXDelta; // Delta since last frame
    [FieldOffset(0x4EC)] public int CursorYDelta; // Delta since last frame

    // At least this is what it seems to be
    [FieldOffset(0x4F4)] public bool IsGameWindowFocused;

    /*
     * All the following keyboard keys states are not triggered if the chat input is active
     */

    /*
     * This one is weird. Seems to fire as long as the last key pressed is still held
     * Except modifiers (ctrl, shift, alt) where it only fires once
     * If fires less often than the "Down" flag in the array below but more often than the "Held" one
     * So Im not sure what to make of this or if this is even useful
     */
    //[FieldOffset(0x4F8)] public int IsLastKeyboardKeyDownThrottled;

    [FixedSizeArray<KeyStateFlags>(133)]
    [FieldOffset(0x51C)] public fixed byte KeyState[0x4 * 133];

    //[FieldOffset(0x77C)] public byte UnkFlag;
    [FieldOffset(0x77D)] public byte KeyHeldKeycode;

    /*
     * Those two seem unreliable in how they're set. They work well on keypress
     * but one or the other will get nulled after a few ms when the key is held
     * or won't have their value changed on release.
     */
    [FieldOffset(0x780)] public byte LastKeyCharKeyCode; // (key code of the character just below, ie `97` for a lowercase `a`)
    [FieldOffset(0x788)] public char LastKeyChar; // (actual character made by key combination, ie `a` or `A`)

    public KeyStateFlags GetKeyState(int key) {
        int offset;
        if (key == 144) // VirtualKey.NUMLOCK
            offset = 0x1E0;
        else if (key == 145) // VirtualKey.SCROLL
            offset = 0x1E4;
        else
            offset = key - 8;

        if (offset < 0 || offset > 133)
            throw new ArgumentOutOfRangeException();

        return KeyStateSpan[offset];
    }
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
