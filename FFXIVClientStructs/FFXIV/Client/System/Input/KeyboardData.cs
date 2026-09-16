namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::KeyboardData
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x494)]
public partial struct KeyboardInputData { // TODO: rename struct to KeyboardData
    /*
     * This one is weird. Seems to fire as long as the last key pressed is still held
     * Except modifiers (ctrl, shift, alt) where it only fires once
     * If fires less often than the "Down" flag in the array below but more often than the "Held" one
     * So Im not sure what to make of this or if this is even useful
     */
    //[FieldOffset(0x00)] public int IsLastKeyboardKeyDownThrottled;

    [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray159<KeyStateFlags> _keyState;

    //[FieldOffset(0x284)] private byte UnkFlag;
    [FieldOffset(0x285)] public byte KeyHeldKeycode;

    /*
     * Those two seem unreliable in how they're set. They work well on keypress
     * but one or the other will get nulled after a few ms when the key is held
     * or won't have their value changed on release.
     */
    [FieldOffset(0x288)] public byte LastKeyCharKeyCode; // (key code of the character just below, ie `97` for a lowercase `a`)
    [FieldOffset(0x290)] public char LastKeyChar; // (actual character made by key combination, ie `a` or `A`)
}

/*
 * Pressed and Held will always be accompanied by Down,
 * so actual possible values returned by GetKeyState will be 1, 3, 4 or 9
 */
[Flags]
public enum KeyStateFlags {
    None = 0,
    Down = 1 << 0,
    Pressed = 1 << 1,
    Released = 1 << 2,
    Held = 1 << 3, // like Down but fires first after about 250ms and then only about every 50 ms
}
