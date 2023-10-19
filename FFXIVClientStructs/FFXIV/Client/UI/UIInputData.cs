// Suppress Inconsistent Naming due to VirtualKeyCode Names 
// ReSharper disable InconsistentNaming
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

    // These fields are only correct for actual physical Playstation Controllers
    // Tested with Sony DualSense Controller Model: CFI-ZCT1W
    [FieldOffset(0x2C)] public float Square;
    [FieldOffset(0x30)] public float Cross;
    [FieldOffset(0x34)] public float Circle;
    [FieldOffset(0x38)] public float Triangle;
    [FieldOffset(0x3C)] public float L1;
    [FieldOffset(0x40)] public float R1;
    [FieldOffset(0x44)] public float L2;
    [FieldOffset(0x48)] public float R2;
    [FieldOffset(0x50)] public float Start;
    [FieldOffset(0x54)] public float L3;
    [FieldOffset(0x58)] public float R3;
    [FieldOffset(0x5C)] public float PSButton;
    [FieldOffset(0x60)] public float Select;
    [FieldOffset(0x64)] public float MuteButton;

    [FieldOffset(0xAC)] public float GamepadLeftStickLeft;
    [FieldOffset(0xB0)] public float GamepadLeftStickRight;

    [FieldOffset(0xCC)] public float GamepadLeftStickUp;
    [FieldOffset(0xD0)] public float GamepadLeftStickDown;

    [FieldOffset(0xEC)] public float GamepadRightStickLeft;
    [FieldOffset(0xF0)] public float GamepadRightStickRight;

    [FieldOffset(0x14C)] public float GamepadRightStickUp;
    [FieldOffset(0x150)] public float GamepadRightStickDown;

    // These values are weird... When DPadLeft is pressed it'll have value 1.0f, but DPadUp will have value 8.74278E-08
    [FieldOffset(0x18C)] public float DPadLeft;
    [FieldOffset(0x190)] public float DPadRight;
    [FieldOffset(0x194)] public float DPadUp;
    [FieldOffset(0x198)] public float DPadDown;

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

    [FixedSizeArray<KeyStateFlags>(159)]
    [FieldOffset(0x4FC)] public fixed byte KeyState[0x4 * 159];

    //[FieldOffset(0x77C)] public byte UnkFlag;
    [FieldOffset(0x77D)] public byte KeyHeldKeycode;

    /*
     * Those two seem unreliable in how they're set. They work well on keypress
     * but one or the other will get nulled after a few ms when the key is held
     * or won't have their value changed on release.
     */
    [FieldOffset(0x780)] public byte LastKeyCharKeyCode; // (key code of the character just below, ie `97` for a lowercase `a`)
    [FieldOffset(0x788)] public char LastKeyChar; // (actual character made by key combination, ie `a` or `A`)

    public KeyStateFlags GetKeyState(int key) => KeyStateSpan[key];
    public KeyStateFlags GetKeyState(SeVirtualKey key) => GetKeyState((int)key);

    public bool IsKeyPressed(SeVirtualKey key) => IsKeyPressed((int)key);
    public bool IsKeyDown(SeVirtualKey key) => IsKeyDown((int)key);
    public bool IsKeyReleased(SeVirtualKey key) => IsKeyReleased((int)key);
    public bool IsKeyHeld(SeVirtualKey key) => IsKeyHeld((int)key);
    public bool IsKeyPressed(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Pressed);
    public bool IsKeyDown(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Down);
    public bool IsKeyReleased(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Released);
    public bool IsKeyHeld(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Held);
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

public enum SeVirtualKey {
    /// <summary>
    /// This is an addendum to use on functions in which you have to pass a zero value to represent no key code.
    /// </summary>
    NO_KEY = 0,

    /// <summary>
    /// Left mouse button.
    /// </summary>
    LBUTTON = 1,

    /// <summary>
    /// Right mouse button.
    /// </summary>
    RBUTTON = 2,

    /// <summary>
    /// Control-break processing.
    /// </summary>
    CANCEL = 3,

    /// <summary>
    /// Middle mouse button (three-button mouse).
    /// </summary>
    /// <remarks>
    /// NOT contiguous with L and R buttons.
    /// </remarks>
    MBUTTON = 4,

    /// <summary>
    /// X1 mouse button.
    /// </summary>

    /// <remarks>
    /// NOT contiguous with L and R buttons.
    /// </remarks>
    XBUTTON1 = 5,

    /// <summary>
    /// X2 mouse button.
    /// </summary>

    /// <remarks>
    /// NOT contiguous with L and R buttons.
    /// </remarks>
    XBUTTON2 = 6,

    /// <summary>
    /// BACKSPACE key.
    /// </summary>
    BACK = 8,

    /// <summary>
    /// TAB key.
    /// </summary>
    TAB = 9,

    /// <summary>
    /// CLEAR key.
    /// </summary>
    CLEAR = 12,

    /// <summary>
    /// RETURN key.
    /// </summary>
    RETURN = 13,

    /// <summary>
    /// SHIFT key.
    /// </summary>
    SHIFT = 16,

    /// <summary>
    /// CONTROL key.
    /// </summary>
    CONTROL = 17,

    /// <summary>
    /// ALT key.
    /// </summary>
    MENU = 18,

    /// <summary>
    /// PAUSE key.
    /// </summary>
    PAUSE = 19,

    /// <summary>
    /// CAPS LOCK key.
    /// </summary>
    CAPITAL = 20,

    /// <summary>
    /// IME Kana mode.
    /// </summary>
    KANA = 21,

    /// <summary>
    /// IME Hangeul mode (maintained for compatibility; use User32.VirtualKey.HANGUL).
    /// </summary>
    HANGEUL = KANA,

    /// <summary>
    /// IME Hangul mode.
    /// </summary>
    HANGUL = KANA,

    /// <summary>
    /// IME Junja mode.
    /// </summary>
    JUNJA = 23,

    /// <summary>
    /// IME final mode.
    /// </summary>
    FINAL = 24,

    /// <summary>
    /// IME Hanja mode.
    /// </summary>
    HANJA = 25,

    /// <summary>
    /// IME Kanji mode.
    /// </summary>
    KANJI = HANJA,

    /// <summary>
    /// ESC key.
    /// </summary>
    ESCAPE = 27,

    /// <summary>
    /// IME convert.
    /// </summary>
    CONVERT = 28,

    /// <summary>
    /// IME nonconvert.
    /// </summary>
    NONCONVERT = 29,

    /// <summary>
    /// IME accept.
    /// </summary>
    ACCEPT = 30,

    /// <summary>
    /// IME mode change request.
    /// </summary>
    MODECHANGE = 31,

    /// <summary>
    /// SPACEBAR.
    /// </summary>
    SPACE = 32,

    /// <summary>
    /// PAGE UP key.
    /// </summary>
    PRIOR = 33,

    /// <summary>
    /// PAGE DOWN key.
    /// </summary>
    NEXT = 34,

    /// <summary>
    /// END key.
    /// </summary>
    END = 35,

    /// <summary>
    /// HOME key.
    /// </summary>
    HOME = 36,

    /// <summary>
    /// LEFT ARROW key.
    /// </summary>
    LEFT = 37,

    /// <summary>
    /// UP ARROW key.
    /// </summary>
    UP = 38,

    /// <summary>
    /// RIGHT ARROW key.
    /// </summary>
    RIGHT = 39,

    /// <summary>
    /// DOWN ARROW key.
    /// </summary>
    DOWN = 40,

    /// <summary>
    /// SELECT key.
    /// </summary>
    SELECT = 41,

    /// <summary>
    /// PRINT key.
    /// </summary>
    PRINT = 42,

    /// <summary>
    /// EXECUTE key.
    /// </summary>
    EXECUTE = 43,

    /// <summary>
    /// PRINT SCREEN key.
    /// </summary>
    SNAPSHOT = 44,

    /// <summary>
    /// INS key.
    /// </summary>
    INSERT = 45,

    /// <summary>
    /// DEL key.
    /// </summary>
    DELETE = 46,

    /// <summary>
    /// HELP key.
    /// </summary>
    HELP = 47,

    /// <summary>
    /// 0 key.
    /// </summary>
    KEY_0 = 48,

    /// <summary>
    /// 1 key.
    /// </summary>
    KEY_1 = 49,

    /// <summary>
    /// 2 key.
    /// </summary>
    KEY_2 = 50,

    /// <summary>
    /// 3 key.
    /// </summary>
    KEY_3 = 51,

    /// <summary>
    /// 4 key.
    /// </summary>
    KEY_4 = 52,

    /// <summary>
    /// 5 key.
    /// </summary>
    KEY_5 = 53,

    /// <summary>
    /// 6 key.
    /// </summary>
    KEY_6 = 54,

    /// <summary>
    /// 7 key.
    /// </summary>
    KEY_7 = 55,

    /// <summary>
    /// 8 key.
    /// </summary>
    KEY_8 = 56,

    /// <summary>
    /// 9 key.
    /// </summary>
    KEY_9 = 57,

    /// <summary>
    /// A key.
    /// </summary>
    A = 65,

    /// <summary>
    /// B key.
    /// </summary>
    B = 66,

    /// <summary>
    /// C key.
    /// </summary>
    C = 67,

    /// <summary>
    /// D key.
    /// </summary>
    D = 68,

    /// <summary>
    /// E key.
    /// </summary>
    E = 69,

    /// <summary>
    /// F key.
    /// </summary>
    F = 70,

    /// <summary>
    /// G key.
    /// </summary>
    G = 71,

    /// <summary>
    /// H key.
    /// </summary>
    H = 72,

    /// <summary>
    /// I key.
    /// </summary>
    I = 73,

    /// <summary>
    /// J key.
    /// </summary>
    J = 74,

    /// <summary>
    /// K key.
    /// </summary>
    K = 75,

    /// <summary>
    /// L key.
    /// </summary>
    L = 76,

    /// <summary>
    /// M key.
    /// </summary>
    M = 77,

    /// <summary>
    /// N key.
    /// </summary>
    N = 78,

    /// <summary>
    /// O key.
    /// </summary>
    O = 79,

    /// <summary>
    /// P key.
    /// </summary>
    P = 80,

    /// <summary>
    /// Q key.
    /// </summary>
    Q = 81,

    /// <summary>
    /// R key.
    /// </summary>
    R = 82,

    /// <summary>
    /// S key.
    /// </summary>
    S = 83,

    /// <summary>
    /// T key.
    /// </summary>
    T = 84,

    /// <summary>
    /// U key.
    /// </summary>
    U = 85,

    /// <summary>
    /// V key.
    /// </summary>
    V = 86,

    /// <summary>
    /// W key.
    /// </summary>
    W = 87,

    /// <summary>
    /// X key.
    /// </summary>
    X = 88,

    /// <summary>
    /// Y key.
    /// </summary>
    Y = 89,

    /// <summary>
    /// Z key.
    /// </summary>
    Z = 90,

    /// <summary>
    /// Left Windows key (Natural keyboard).
    /// </summary>
    LWIN = 91,

    /// <summary>
    /// Right Windows key (Natural keyboard).
    /// </summary>
    RWIN = 92,

    /// <summary>
    /// Applications key (Natural keyboard).
    /// </summary>
    APPS = 93,

    /// <summary>
    /// Computer Sleep key.
    /// </summary>
    SLEEP = 95,

    /// <summary>
    /// Numeric keypad 0 key.
    /// </summary>
    NUMPAD0 = 96,

    /// <summary>
    /// Numeric keypad 1 key.
    /// </summary>
    NUMPAD1 = 97,

    /// <summary>
    /// Numeric keypad 2 key.
    /// </summary>
    NUMPAD2 = 98,

    /// <summary>
    /// Numeric keypad 3 key.
    /// </summary>
    NUMPAD3 = 99,

    /// <summary>
    /// Numeric keypad 4 key.
    /// </summary>
    NUMPAD4 = 100,

    /// <summary>
    /// Numeric keypad 5 key.
    /// </summary>
    NUMPAD5 = 101,

    /// <summary>
    /// Numeric keypad 6 key.
    /// </summary>
    NUMPAD6 = 102,

    /// <summary>
    /// Numeric keypad 7 key.
    /// </summary>
    NUMPAD7 = 103,

    /// <summary>
    /// Numeric keypad 8 key.
    /// </summary>
    NUMPAD8 = 104,

    /// <summary>
    /// Numeric keypad 9 key.
    /// </summary>
    NUMPAD9 = 105,

    /// <summary>
    /// Multiply key.
    /// </summary>
    MULTIPLY = 106,

    /// <summary>
    /// Add key.
    /// </summary>
    ADD = 107,

    /// <summary>
    /// Separator key.
    /// </summary>
    SEPARATOR = 108,

    /// <summary>
    /// Subtract key.
    /// </summary>
    SUBTRACT = 109,

    /// <summary>
    /// Decimal key.
    /// </summary>
    DECIMAL = 110,

    /// <summary>
    /// Divide key.
    /// </summary>
    DIVIDE = 111,

    /// <summary>
    /// F1 Key.
    /// </summary>
    F1 = 112,

    /// <summary>
    /// F2 Key.
    /// </summary>
    F2 = 113,

    /// <summary>
    /// F3 Key.
    /// </summary>
    F3 = 114,

    /// <summary>
    /// F4 Key.
    /// </summary>
    F4 = 115,

    /// <summary>
    /// F5 Key.
    /// </summary>
    F5 = 116,

    /// <summary>
    /// F6 Key.
    /// </summary>
    F6 = 117,

    /// <summary>
    /// F7 Key.
    /// </summary>
    F7 = 118,

    /// <summary>
    /// F8 Key.
    /// </summary>
    F8 = 119,

    /// <summary>
    /// F9 Key.
    /// </summary>
    F9 = 120,

    /// <summary>
    /// F10 Key.
    /// </summary>
    F10 = 121,

    /// <summary>
    /// F11 Key.
    /// </summary>
    F11 = 122,

    /// <summary>
    /// F12 Key.
    /// </summary>
    F12 = 123,

    /// <summary>
    /// F13 Key.
    /// </summary>
    F13 = 124,

    /// <summary>
    /// F14 Key.
    /// </summary>
    F14 = 125,

    /// <summary>
    /// F15 Key.
    /// </summary>
    F15 = 126,

    /// <summary>
    /// F16 Key.
    /// </summary>
    F16 = 127,

    /// <summary>
    /// NUM LOCK key.
    /// </summary>
    NUMLOCK = 128,

    /// <summary>
    /// SCROLL LOCK key.
    /// </summary>
    SCROLL = 129,

    /// <summary>
    /// F19 Key.
    /// </summary>
    F19 = 130,

    /// <summary>
    /// F20 Key.
    /// </summary>
    F20 = 131,

    /// <summary>
    /// F21 Key.
    /// </summary>
    F21 = 132,

    /// <summary>
    /// F22 Key.
    /// </summary>
    F22 = 133,

    /// <summary>
    /// F23 Key.
    /// </summary>
    F23 = 134,

    /// <summary>
    /// F24 Key.
    /// </summary>
    F24 = 135
}
