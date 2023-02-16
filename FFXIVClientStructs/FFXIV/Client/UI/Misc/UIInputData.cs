using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0xA20)]
public unsafe partial struct UIInputData
{
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
    [FieldOffset(0x4F4)] public byte IsGameWindowFocused;

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
    [FieldOffset(0x51C)] public fixed int KeyState[0x4 * 133];
    public KeyStateFlags GetKeyState(int key)
    {
        int offset;
        if (key == 144) // VirtualKey.NUMLOCK
            offset = 0x1E0;
        else if (key == 145) // VirtualKey.SCROLL
            offset = 0x1E4;
        else
            offset = key - 8;

        if (offset < 0 || offset > 133)
            throw new ArgumentOutOfRangeException();

        return (KeyStateFlags)KeyState[offset];
    }

    //[FieldOffset(0x77C)] public byte UnkFlag;
    [FieldOffset(0x77D)] public byte KeyHeldKeycode;

    /*
     * Those two seem unreliable in how they're set. They work well on keypress
     * but one or the other will get nulled after a few ms when the key is held
     * or won't have their value changed on release.
     */
    [FieldOffset(0x780)] public byte LastKeyCharKeyCode; // (key code of the character just below, ie `97` for a lowercase `a`)
    [FieldOffset(0x788)] public char LastKeyChar; // (actual character made by key combination, ie `a` or `A`)

}

[Flags]
public enum MouseButtonFlags
{
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
public enum KeyStateFlags
{
    Down = 1,
    Pressed = 2,
    Released = 4,
    Held = 8, // like Down but fires first after about 250ms and then only about every 50 ms
}
