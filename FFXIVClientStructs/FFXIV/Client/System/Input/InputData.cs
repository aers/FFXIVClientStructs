using FFXIVClientStructs.FFXIV.Client.UI;

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
    [FieldOffset(0x994)] public GamepadModifierFlag CurrentGamepadModifier;
    [FieldOffset(0x995)] public KeyModifierFlag CurrentKeyModifier;

    [FieldOffset(0x9AE)] public bool GamepadInputs2ButtonsChanged;
    [FieldOffset(0x9AF)] public bool CursorPositionsChanged;
    [FieldOffset(0x9B0)] public bool KeyboardInputsChanged;
    [FieldOffset(0x9B1)] public bool UIFilteredCursorInputsButtonsChanged;
    [FieldOffset(0x9B2)] public bool GamepadInputsButtonsChanged;

    [FieldOffset(0x9B4)] public int NumKeybinds; // amount of InputIds
    [FieldOffset(0x9B8)] public Keybind* Keybinds; // index is InputId

    [FieldOffset(0x9C8)] public InputCodeModifiedInterface* InputCodeModifiedCallback;

    public Span<Keybind> GetKeybindSpan() => new(Keybinds, NumKeybinds);

    [VirtualFunction(2)]
    public partial void SetKeybind(InputId inputId, Keybind* keybind);

    [MemberFunction("E9 ?? ?? ?? ?? 83 7F 44 02")]
    public partial bool IsInputIdPressed(InputId inputId);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8D 76 06")]
    public partial bool IsInputIdDown(InputId inputId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 37 EB 06")]
    public partial bool IsInputIdHeld(InputId inputId);

    [MemberFunction("E8 ?? ?? ?? ?? 88 43 0F")]
    public partial bool IsInputIdReleased(InputId inputId);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 0F B6 DB")]
    public partial Keybind* GetKeybind(InputId inputId);

    public Keybind* GetKeybind(int index) => GetKeybind((InputId)index);

    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public partial struct InputCodeModifiedInterface {
        /// <remarks> Called in <see cref="SetKeybind"/>. </remarks>
        [VirtualFunction(0)]
        public partial void OnInputCodeModified(InputId inputId, Keybind* keybind);
    }
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

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x0B)]
public partial struct Keybind {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray2<KeySetting> _keySettings;
    [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray2<KeySetting> _gamepadSettings;
    [FieldOffset(0x08)] private ushort Unk8;
    [FieldOffset(0x0A)] private byte UnkA;
}

[StructLayout(LayoutKind.Explicit, Size = 0x02)]
public struct KeySetting {
    [FieldOffset(0x00)] public SeVirtualKey Key;
    [FieldOffset(0x01), CExporterUnion("Modifier")] public KeyModifierFlag KeyModifier;
    [FieldOffset(0x01), CExporterUnion("Modifier")] public GamepadModifierFlag GamepadModifier;
}

[Flags]
public enum GamepadModifierFlag : byte {
    None = 0,
    L1 = 1 << 0,
    R1 = 1 << 1,
    L2 = 1 << 2,
    R2 = 1 << 3,
    Start = 1 << 6,
    Select = 1 << 7,
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

[Flags]
public enum MouseButtonFlags {
    None = 0,
    LBUTTON = 1 << 0,
    MBUTTON = 1 << 1,
    RBUTTON = 1 << 2,
    XBUTTON1 = 1 << 3,
    XBUTTON2 = 1 << 4,
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

[Flags]
public enum KeyModifierFlag : byte {
    None = 0,
    Shift = 1 << 0,
    Ctrl = 1 << 1,
    Alt = 1 << 2,
}

/// From pointer found in <see cref="UIInputData.GetKeybindByName"/>
public enum InputId {
    NotFound = -1,
    CTRL = 0,
    OK = 1,
    CANCEL = 2,
    ESC = 3,
    MENU = 4,
    MENU_OPTION = 5,
    MENU_SCALE = 6,
    MENU_PAD_SCALE = 7,
    LEFT = 8,
    RIGHT = 9,
    UP = 10,
    DOWN = 11,
    PAGEUP = 12,
    PAGEDOWN = 13,
    TOP = 14,
    BOTTOM = 15,
    TAB_NEXT = 16,
    TAB_PREV = 17,
    TAB_BOTH_NEXT = 18,
    TAB_BOTH_PREV = 19,
    DELETE = 20,
    HIDE = 21,
    COPY = 22,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_0 = 23,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_1 = 24,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_2 = 25,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_3 = 26,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_4 = 27,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_5 = 28,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_6 = 29,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_7 = 30,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_8 = 31,
    /// <remarks>NUM_ prefix was added for C# enum compatibility</remarks>
    NUM_9 = 32,
    PAD_OK = 33,
    PAD_CANCEL = 34,
    PAD_ENTER = 35,
    MOUSE_OK = 36,
    MOUSE_CANCEL = 37,
    PAD_MOD = 38,
    PAD_MOUSE_L = 39,
    PAD_MOUSE_R = 40,
    PAD_HIDE = 41,
    OPTION = 42,
    OPTION_PAD = 43,
    HIDE_GUI = 44,
    HOTBAR_UP = 45,
    HOTBAR_DOWN = 46,
    HOTBAR_SET_1 = 47,
    HOTBAR_SET_2 = 48,
    HOTBAR_SET_3 = 49,
    HOTBAR_SET_4 = 50,
    HOTBAR_SET_5 = 51,
    HOTBAR_SET_6 = 52,
    HOTBAR_SET_7 = 53,
    HOTBAR_SET_8 = 54,
    HOTBAR_SET_9 = 55,
    HOTBAR_SET_10 = 56,
    HOTBAR_1_1 = 57,
    HOTBAR_1_2 = 58,
    HOTBAR_1_3 = 59,
    HOTBAR_1_4 = 60,
    HOTBAR_1_5 = 61,
    HOTBAR_1_6 = 62,
    HOTBAR_1_7 = 63,
    HOTBAR_1_8 = 64,
    HOTBAR_1_9 = 65,
    HOTBAR_1_0 = 66,
    HOTBAR_1_A = 67,
    HOTBAR_1_B = 68,
    HOTBAR_2_1 = 69,
    HOTBAR_2_2 = 70,
    HOTBAR_2_3 = 71,
    HOTBAR_2_4 = 72,
    HOTBAR_2_5 = 73,
    HOTBAR_2_6 = 74,
    HOTBAR_2_7 = 75,
    HOTBAR_2_8 = 76,
    HOTBAR_2_9 = 77,
    HOTBAR_2_0 = 78,
    HOTBAR_2_A = 79,
    HOTBAR_2_B = 80,
    HOTBAR_3_1 = 81,
    HOTBAR_3_2 = 82,
    HOTBAR_3_3 = 83,
    HOTBAR_3_4 = 84,
    HOTBAR_3_5 = 85,
    HOTBAR_3_6 = 86,
    HOTBAR_3_7 = 87,
    HOTBAR_3_8 = 88,
    HOTBAR_3_9 = 89,
    HOTBAR_3_0 = 90,
    HOTBAR_3_A = 91,
    HOTBAR_3_B = 92,
    HOTBAR_4_1 = 93,
    HOTBAR_4_2 = 94,
    HOTBAR_4_3 = 95,
    HOTBAR_4_4 = 96,
    HOTBAR_4_5 = 97,
    HOTBAR_4_6 = 98,
    HOTBAR_4_7 = 99,
    HOTBAR_4_8 = 100,
    HOTBAR_4_9 = 101,
    HOTBAR_4_0 = 102,
    HOTBAR_4_A = 103,
    HOTBAR_4_B = 104,
    HOTBAR_5_1 = 105,
    HOTBAR_5_2 = 106,
    HOTBAR_5_3 = 107,
    HOTBAR_5_4 = 108,
    HOTBAR_5_5 = 109,
    HOTBAR_5_6 = 110,
    HOTBAR_5_7 = 111,
    HOTBAR_5_8 = 112,
    HOTBAR_5_9 = 113,
    HOTBAR_5_0 = 114,
    HOTBAR_5_A = 115,
    HOTBAR_5_B = 116,
    HOTBAR_6_1 = 117,
    HOTBAR_6_2 = 118,
    HOTBAR_6_3 = 119,
    HOTBAR_6_4 = 120,
    HOTBAR_6_5 = 121,
    HOTBAR_6_6 = 122,
    HOTBAR_6_7 = 123,
    HOTBAR_6_8 = 124,
    HOTBAR_6_9 = 125,
    HOTBAR_6_0 = 126,
    HOTBAR_6_A = 127,
    HOTBAR_6_B = 128,
    HOTBAR_7_1 = 129,
    HOTBAR_7_2 = 130,
    HOTBAR_7_3 = 131,
    HOTBAR_7_4 = 132,
    HOTBAR_7_5 = 133,
    HOTBAR_7_6 = 134,
    HOTBAR_7_7 = 135,
    HOTBAR_7_8 = 136,
    HOTBAR_7_9 = 137,
    HOTBAR_7_0 = 138,
    HOTBAR_7_A = 139,
    HOTBAR_7_B = 140,
    HOTBAR_8_1 = 141,
    HOTBAR_8_2 = 142,
    HOTBAR_8_3 = 143,
    HOTBAR_8_4 = 144,
    HOTBAR_8_5 = 145,
    HOTBAR_8_6 = 146,
    HOTBAR_8_7 = 147,
    HOTBAR_8_8 = 148,
    HOTBAR_8_9 = 149,
    HOTBAR_8_0 = 150,
    HOTBAR_8_A = 151,
    HOTBAR_8_B = 152,
    HOTBAR_9_1 = 153,
    HOTBAR_9_2 = 154,
    HOTBAR_9_3 = 155,
    HOTBAR_9_4 = 156,
    HOTBAR_9_5 = 157,
    HOTBAR_9_6 = 158,
    HOTBAR_9_7 = 159,
    HOTBAR_9_8 = 160,
    HOTBAR_9_9 = 161,
    HOTBAR_9_0 = 162,
    HOTBAR_9_A = 163,
    HOTBAR_9_B = 164,
    HOTBAR_10_1 = 165,
    HOTBAR_10_2 = 166,
    HOTBAR_10_3 = 167,
    HOTBAR_10_4 = 168,
    HOTBAR_10_5 = 169,
    HOTBAR_10_6 = 170,
    HOTBAR_10_7 = 171,
    HOTBAR_10_8 = 172,
    HOTBAR_10_9 = 173,
    HOTBAR_10_0 = 174,
    HOTBAR_10_A = 175,
    HOTBAR_10_B = 176,
    HOTBAR_EX_1 = 177,
    HOTBAR_EX_2 = 178,
    HOTBAR_EX_3 = 179,
    HOTBAR_EX_4 = 180,
    HOTBAR_EX_5 = 181,
    HOTBAR_EX_6 = 182,
    HOTBAR_EX_7 = 183,
    HOTBAR_EX_8 = 184,
    HOTBAR_EX_9 = 185,
    HOTBAR_EX_0 = 186,
    HOTBAR_EX_A = 187,
    HOTBAR_EX_B = 188,
    HOTBAR_CONTENTS_ACT_L = 189,
    HOTBAR_CONTENTS_ACT_R = 190,
    HOT_PAD_LEFT_TRG = 191,
    HOT_PAD_RIGHT_TRG = 192,
    HOT_PAD_CHANGE = 193,
    HOT_PAD_LL = 194,
    HOT_PAD_LU = 195,
    HOT_PAD_LR = 196,
    HOT_PAD_LD = 197,
    HOT_PAD_RL = 198,
    HOT_PAD_RU = 199,
    HOT_PAD_RR = 200,
    HOT_PAD_RD = 201,
    HOT_PAD_LL_L = 202,
    HOT_PAD_LU_L = 203,
    HOT_PAD_LR_L = 204,
    HOT_PAD_LD_L = 205,
    HOT_PAD_RL_L = 206,
    HOT_PAD_RU_L = 207,
    HOT_PAD_RR_L = 208,
    HOT_PAD_RD_L = 209,
    HOT_PAD_CONTENT = 210,
    HOT_PAD_LL_R = 211,
    HOT_PAD_LU_R = 212,
    HOT_PAD_LR_R = 213,
    HOT_PAD_LD_R = 214,
    HOT_PAD_RL_R = 215,
    HOT_PAD_RU_R = 216,
    HOT_PAD_RR_R = 217,
    HOT_PAD_RD_R = 218,
    HOT_PAD_TOPAGE1 = 219,
    HOT_PAD_TOPAGE2 = 220,
    HOT_PAD_TOPAGE3 = 221,
    HOT_PAD_TOPAGE4 = 222,
    HOT_PAD_TOPAGE5 = 223,
    HOT_PAD_TOPAGE6 = 224,
    HOT_PAD_TOPAGE7 = 225,
    HOT_PAD_TOPAGE8 = 226,

    MENU_MAIN = 237,
    MENU_SYSTEM = 238,
    MENU_FISH = 239,
    MENU_SYSCONFIG = 240,
    MENU_CONFIG = 241,
    MENU_CONTENT = 242,
    MENU_SOCIAL = 243,
    MENU_ACTION = 244,
    MENU_FREECOM = 245,
    MENU_ACHIVE = 246,
    MENU_JOURNAL = 247,
    MENU_GATHER = 248,
    MENU_LINKSHELL = 249,
    MENU_STATUS = 250,
    MENU_BAG = 251,
    MENU_CRAFT = 252,
    MENU_MAP = 253,
    MENU_EMOTE = 254,
    MENU_RETURN = 255,
    MENU_TELEPO = 256,
    MENU_MARK = 257,
    MENU_LAYOUT = 258,
    MENU_MACRO = 259,
    MENU_MONSTER = 260,
    MENU_ARMORY = 261,
    MENU_SUPPORT = 262,
    MENU_HOWTO = 263,
    MENU_KEYBIND = 264,
    MENU_LOGCOLOR = 265,
    MENU_CONTENT_INFO = 266,
    MENU_BUDDY = 267,
    MENU_PADCUSTOMIZE = 268,
    MENU_FISH_GUIDE = 269,
    MENU_RECOMMEND_LIST = 270,
    MENU_PARTY_MEMBER = 271,
    MENU_PC_SEARCH = 272,
    MENU_FRIEND_LIST = 273,
    MENU_BLACK_LIST = 274,
    MENU_EVENT_BAG = 275,
    MENU_LFG = 276,
    MENU_CIRCLE_LIST = 277,
    MENU_CIRCLE_RECRUIT = 278,
    MENU_MCGUFFIN = 279,
    MENU_QUEST_REPLAY = 280,
    CMD_CHAT = 281,
    CMD_COMMAND = 282,
    CMD_REPLY = 283,
    CMD_REPLY_REV = 284,
    CMD_SAY = 285,
    CMD_PARTY = 286,
    CMD_LINKSHELL = 287,
    CMD_LINKSHELL_REV = 288,
    CMD_LINKSHELL_1 = 289,
    CMD_LINKSHELL_2 = 290,
    CMD_LINKSHELL_3 = 291,
    CMD_LINKSHELL_4 = 292,
    CMD_LINKSHELL_5 = 293,
    CMD_LINKSHELL_6 = 294,
    CMD_LINKSHELL_7 = 295,
    CMD_LINKSHELL_8 = 296,
    CMD_SHOUT = 297,
    CMD_YELL = 298,
    CMD_FREECOM = 299,
    CMD_ALLIANCE = 300,
    CMD_BEGINNER = 301,
    CMD_REPLY_ALWAYS = 302,
    CMD_REPLY_REV_ALWAYS = 303,
    CMD_SAY_ALWAYS = 304,
    CMD_PARTY_ALWAYS = 305,
    CMD_LINKSHELL_ALWAYS = 306,
    CMD_LINKSHELL_REV_ALWAYS = 307,
    CMD_LINKSHELL_1_ALWAYS = 308,
    CMD_LINKSHELL_2_ALWAYS = 309,
    CMD_LINKSHELL_3_ALWAYS = 310,
    CMD_LINKSHELL_4_ALWAYS = 311,
    CMD_LINKSHELL_5_ALWAYS = 312,
    CMD_LINKSHELL_6_ALWAYS = 313,
    CMD_LINKSHELL_7_ALWAYS = 314,
    CMD_LINKSHELL_8_ALWAYS = 315,
    CMD_SHOUT_ALWAYS = 316,
    CMD_YELL_ALWAYS = 317,
    CMD_FREECOM_ALWAYS = 318,
    CMD_ALLIANCE_ALWAYS = 319,
    CMD_BEGINNER_ALWAYS = 320,
    MOVE_FORE = 321,
    MOVE_BACK = 322,
    MOVE_LEFT = 323,
    MOVE_RIGHT = 324,
    MOVE_STRIFE_L = 325,
    MOVE_STRIFE_R = 326,
    MOVE_AND_STEER = 327,
    CAMERA_UP = 328,
    CAMERA_DOWN = 329,
    CAMERA_LEFT = 330,
    CAMERA_RIGHT = 331,
    CAMERA_ZOOMIN = 332,
    CAMERA_ZOOMOUT = 333,
    CAMERA_ZOOMMODE = 334,
    CAMERA_MODE = 335,
    CAMERA_RESET = 336,
    CAMERA_SAVE = 337,
    CAMERA_LOAD = 338,
    CAMERA_MOUSE_OK = 339,
    CAMERA_MOUSE_CANCEL = 340,
    CAMERA_FOCUS = 341,
    CAMERA_FORWARD = 342,
    CAMERA_BACKWARD = 343,
    FACE = 344,
    SWARD = 345,
    NOTARGET_SWORD = 346,
    ATTACK = 347,
    JUMP = 348,
    AUTORUN_KEY = 349,
    AUTORUN_PAD = 350,
    WALK = 351,
    REST = 352,
    CIRCLE_ALL = 353,
    CIRCLE_PC = 354,
    CIRCLE_PARTY = 355,
    CIRCLE_ENEMY = 356,
    CIRCLE_1 = 357,
    CIRCLE_2 = 358,
    CIRCLE_3 = 359,
    CIRCLE_4 = 360,
    TARGET = 361,
    TARGET_LOCK = 362,
    TARGET_FOCUS = 363,
    TARGET_LEFT = 364,
    TARGET_RIGHT = 365,
    TARGET_NEXT = 366,
    TARGET_PREV = 367,
    TARGET_LIST_UP = 368,
    TARGET_LIST_DOWN = 369,
    TARGET_P1 = 370,
    TARGET_P2 = 371,
    TARGET_P3 = 372,
    TARGET_P4 = 373,
    TARGET_P5 = 374,
    TARGET_P6 = 375,
    TARGET_P7 = 376,
    TARGET_P8 = 377,
    TARGET_PID1 = 378,
    TARGET_PID2 = 379,
    TARGET_PID3 = 380,
    TARGET_PID4 = 381,
    TARGET_PID5 = 382,
    TARGET_PID6 = 383,
    TARGET_PID7 = 384,
    TARGET_PID8 = 385,
    TARGET_TTOT = 386,
    TARGET_LASTTARGET = 387,
    TARGET_LASTENEMY = 388,
    TARGET_LASTATTACKER = 389,
    TARGET_PET = 390,
    TARGET_SELECT = 391,
    TARGET_CLOSEST_ENEMY = 392,
    TARGET_CLOSEST_PC = 393,
    TARGET_CLOSEST_NPC = 394,
    TARGET_CLICK_FILTER = 395,
    TARGET_GROUND_POINT_RESET = 396,
    TARGET_ALLIANCE1_1 = 397,
    TARGET_ALLIANCE1_2 = 398,
    TARGET_ALLIANCE1_3 = 399,
    TARGET_ALLIANCE1_4 = 400,
    TARGET_ALLIANCE1_5 = 401,
    TARGET_ALLIANCE1_6 = 402,
    TARGET_ALLIANCE1_7 = 403,
    TARGET_ALLIANCE1_8 = 404,
    TARGET_ALLIANCE2_1 = 405,
    TARGET_ALLIANCE2_2 = 406,
    TARGET_ALLIANCE2_3 = 407,
    TARGET_ALLIANCE2_4 = 408,
    TARGET_ALLIANCE2_5 = 409,
    TARGET_ALLIANCE2_6 = 410,
    TARGET_ALLIANCE2_7 = 411,
    TARGET_ALLIANCE2_8 = 412,
    TARGET_ALLIANCE1_NEXT = 413,
    TARGET_ALLIANCE1_PREV = 414,
    TARGET_ALLIANCE2_NEXT = 415,
    TARGET_ALLIANCE2_PREV = 416,
    TARGET_ALLIANCE_NEXT_KEY = 417,
    TARGET_ALLIANCE_PREV_KEY = 418,
    TARGET_ALLIANCE_NEXT_PAD = 419,
    TARGET_ALLIANCE_PREV_PAD = 420,
    TARGET_PVP_OPP_P1 = 421,
    TARGET_PVP_OPP_P2 = 422,
    TARGET_PVP_OPP_P3 = 423,
    TARGET_PVP_OPP_P4 = 424,
    TARGET_PVP_OPP_P5 = 425,
    TARGET_ENEMY_LIST_UP_PAD = 426,
    TARGET_ENEMY_LIST_DOWN_PAD = 427,
    TARGET_ENEMY_LIST_UP_KEY = 428,
    TARGET_ENEMY_LIST_DOWN_KEY = 429,
    CAM_TILT_UP = 430,
    CAM_TILT_DOWN = 431,
    MENU_HOUSING = 432,
    MENU_PVP_PROFILE = 433,
    CAMERA_LOOKING = 434,
    MENU_FIELD_MARK = 435,
    PAD_HUDFOCUS_PREV = 436,
    MENU_CONTENTS_NOTEBOOK = 437,
    PAD_HUDFOCUS_CHANGE = 438,
    MENU_READY_CHECK = 439,
    MENU_MOUNT_NOTEBOOK = 440,
    MENU_MINION_NOTEBOOK = 441,
    MENU_ADVENTURE_NOTEBOOK = 442,
    MENU_WEAPON_NOTEBOOK = 443,
    MENU_ACCESSIBILITY_FILTER = 444,
    MACRO_FORCED_OUTAGE = 445,
    MENU_RAID_FINDER = 446,
    HOTBAR_SET_EX = 447,
    MOVE_DESCENT = 448,
    MOVE_RETENTION = 449,
    MOVE_ANGLE_RISING = 450,
    MOVE_ANGLE_DESCENT = 451,
    MOUSE_CURSOR_SONAR = 452,
    MENU_GOLD_SAUCER = 453,
    MENU_AETHER_CURRENT = 454,
    MENU_CURRENCY = 455,
    GROUP_POSE = 456,
    IDLING_CAMERA = 457,
    MENU_GEAR_SET = 458,
    MASTER_VOLUME_MUTE = 459,
    MENU_PLAY_GUIDE = 460,
    MENU_CONTENTS_GENERAL = 461,
    MENU_SUBCOMMAND_CUSTOMIZE = 462,
    MENU_ORCHESTRION = 463,
    MENU_BEGINNERS_MANSION = 464,
    MENU_BEGINNER_CHANNEL_LIST = 465,
    HUDLAYOUT_SET1 = 466,
    HUDLAYOUT_SET2 = 467,
    HUDLAYOUT_SET3 = 468,
    HUDLAYOUT_SET4 = 469,
    CHATLOG_VIEWERMODE = 470,
    MENU_COUNTDOWN = 471,
    MENU_CONTACTLIST = 472,
    BUDDY_TARGET = 473,

    MENU_GROUND_MOUNT_SPEED = 477,
    MENU_SCENARIO_TREE = 478,
    MENU_SCENARIO_TREE_SUB = 479,
    MENU_BUDDY_BAG = 480,
    MENU_CONTENTS_REPLAY = 481,
    PVPTEAM_CHAT = 482,
    PVPTEAM_CHAT_ALWAYS = 483,
    MENU_REPLAY_READY_CHECK = 484,
    MENU_PVPTEAM_UI = 485,
    ACCESSIBILITY_COLORBLIND = 486,
    CMD_CWLINKSHELL = 487,
    CMD_CWLINKSHELL_ALWAYS = 488,
    MENU_CWLINKSHELL = 489,
    MENU_ALERM = 490,
    MENU_AOZ = 491,

    CMD_CWLINKSHELL_REV = 493,
    CMD_CWLINKSHELL_1 = 494,
    CMD_CWLINKSHELL_2 = 495,
    CMD_CWLINKSHELL_3 = 496,
    CMD_CWLINKSHELL_4 = 497,
    CMD_CWLINKSHELL_5 = 498,
    CMD_CWLINKSHELL_6 = 499,
    CMD_CWLINKSHELL_7 = 500,
    CMD_CWLINKSHELL_8 = 501,
    CMD_CWLINKSHELL_ALWAYS_REV = 502,
    CMD_CWLINKSHELL_1_ALWAYS = 503,
    CMD_CWLINKSHELL_2_ALWAYS = 504,
    CMD_CWLINKSHELL_3_ALWAYS = 505,
    CMD_CWLINKSHELL_4_ALWAYS = 506,
    CMD_CWLINKSHELL_5_ALWAYS = 507,
    CMD_CWLINKSHELL_6_ALWAYS = 508,
    CMD_CWLINKSHELL_7_ALWAYS = 509,
    CMD_CWLINKSHELL_8_ALWAYS = 510,
    MENU_FAITH = 511,
    MENU_FATE_PROGRESS = 512,
    MENU_ORNAMENT_NOTEBOOK = 513,
    WEBLINK = 514,
    MENU_BANNER_LIST = 515,
    MENU_SDS = 516,
    MENU_CHARA_CARD = 517,
    MENU_VVD = 518,
    MENU_FACE_ACCESSORY = 519,
    MENU_MUTE_LIST = 520,
    TERM_FILTER = 521,
    MENU_TOFU = 522,
    QUICK_PANEL = 523,
    PAD_MAP = 524,
    PAD_JUMPANDCANCELCAST = 525,
    PAD_LOCKANDSWARD = 526,
    PAD_SWARD = 527,
    PAD_LOCKANDSIT = 528,
    PAD_MAINMENUFOCUS = 529,
    PAD_HUDFOCUS = 530,
    PAD_MODECHANGE = 531,
    PAD_CROSSEDITMODE = 532,
    PAD_DRAWN_SWORD = 533,
    PAD_CAMERA_LOCK_ON_ONLY = 534,
    PAD_QUICKPANEL = 535,
    PAD_MACRO_98 = 536,
    PAD_MACRO_99 = 537,
    PAD_DISMOUNT = 538,

    PAD_MAP_ZOOM = 549,
    PAD_MAP_RESET = 550,
    PAD_MAP_MENU = 551,

    KEY_SCREENSHOT = 554,
    PAD_SCREENSHOT = 555,

    PERFORMANCE_MODE_OCTAVE_HIGHER = 567,
    PERFORMANCE_MODE_OCTAVE_LOWER = 568,
    PERFORMANCE_MODE_SHARP = 569,
    PERFORMANCE_MODE_FLAT = 570,
    PERFORMANCE_MODE_C4 = 571,
    PERFORMANCE_MODE_C4_SHARP = 572,
    PERFORMANCE_MODE_D4 = 573,
    PERFORMANCE_MODE_D4_SHARP = 574,
    PERFORMANCE_MODE_E4 = 575,
    PERFORMANCE_MODE_F4 = 576,
    PERFORMANCE_MODE_F4_SHARP = 577,
    PERFORMANCE_MODE_G4 = 578,
    PERFORMANCE_MODE_G4_SHARP = 579,
    PERFORMANCE_MODE_A4 = 580,
    PERFORMANCE_MODE_A4_SHARP = 581,
    PERFORMANCE_MODE_B4 = 582,
    PERFORMANCE_MODE_C5 = 583,
    PERFORMANCE_MODE_TONE_NEXT = 584,
    PERFORMANCE_MODE_TONE_PREV = 585,
    PERFORMANCE_MODE_TONE0 = 586,
    PERFORMANCE_MODE_TONE1 = 587,
    PERFORMANCE_MODE_TONE2 = 588,
    PERFORMANCE_MODE_TONE3 = 589,
    PERFORMANCE_MODE_TONE4 = 590,
    PERFORMANCE_MODE_EX_OCTAVE_HIGHER = 591,
    PERFORMANCE_MODE_EX_OCTAVE_LOWER = 592,
    PERFORMANCE_MODE_EX_SHARP = 593,
    PERFORMANCE_MODE_EX_FLAT = 594,
    PERFORMANCE_MODE_EX_C3 = 595,
    PERFORMANCE_MODE_EX_C3_SHARP = 596,
    PERFORMANCE_MODE_EX_D3 = 597,
    PERFORMANCE_MODE_EX_D3_SHARP = 598,
    PERFORMANCE_MODE_EX_E3 = 599,
    PERFORMANCE_MODE_EX_F3 = 600,
    PERFORMANCE_MODE_EX_F3_SHARP = 601,
    PERFORMANCE_MODE_EX_G3 = 602,
    PERFORMANCE_MODE_EX_G3_SHARP = 603,
    PERFORMANCE_MODE_EX_A3 = 604,
    PERFORMANCE_MODE_EX_A3_SHARP = 605,
    PERFORMANCE_MODE_EX_B3 = 606,
    PERFORMANCE_MODE_EX_C4 = 607,
    PERFORMANCE_MODE_EX_C4_SHARP = 608,
    PERFORMANCE_MODE_EX_D4 = 609,
    PERFORMANCE_MODE_EX_D4_SHARP = 610,
    PERFORMANCE_MODE_EX_E4 = 611,
    PERFORMANCE_MODE_EX_F4 = 612,
    PERFORMANCE_MODE_EX_F4_SHARP = 613,
    PERFORMANCE_MODE_EX_G4 = 614,
    PERFORMANCE_MODE_EX_G4_SHARP = 615,
    PERFORMANCE_MODE_EX_A4 = 616,
    PERFORMANCE_MODE_EX_A4_SHARP = 617,
    PERFORMANCE_MODE_EX_B4 = 618,
    PERFORMANCE_MODE_EX_C5 = 619,
    PERFORMANCE_MODE_EX_C5_SHARP = 620,
    PERFORMANCE_MODE_EX_D5 = 621,
    PERFORMANCE_MODE_EX_D5_SHARP = 622,
    PERFORMANCE_MODE_EX_E5 = 623,
    PERFORMANCE_MODE_EX_F5 = 624,
    PERFORMANCE_MODE_EX_F5_SHARP = 625,
    PERFORMANCE_MODE_EX_G5 = 626,
    PERFORMANCE_MODE_EX_G5_SHARP = 627,
    PERFORMANCE_MODE_EX_A5 = 628,
    PERFORMANCE_MODE_EX_A5_SHARP = 629,
    PERFORMANCE_MODE_EX_B5 = 630,
    PERFORMANCE_MODE_EX_C6 = 631,
    PERFORMANCE_MODE_EX_TONE_NEXT = 632,
    PERFORMANCE_MODE_EX_TONE_PREV = 633,
    PERFORMANCE_MODE_EX_TONE0 = 634,
    PERFORMANCE_MODE_EX_TONE1 = 635,
    PERFORMANCE_MODE_EX_TONE2 = 636,
    PERFORMANCE_MODE_EX_TONE3 = 637,
    PERFORMANCE_MODE_EX_TONE4 = 638,

    VIRTUAL_PAD_L1 = 654,
    VIRTUAL_PAD_L2 = 655,
    VIRTUAL_PAD_L3 = 656,
    VIRTUAL_PAD_R1 = 657,
    VIRTUAL_PAD_R2 = 658,
    VIRTUAL_PAD_R3 = 659,
    VIRTUAL_PAD_UP = 660,
    VIRTUAL_PAD_DOWN = 661,
    VIRTUAL_PAD_LEFT = 662,
    VIRTUAL_PAD_RIGHT = 663,
    VIRTUAL_PAD_TRIANGLE = 664,
    VIRTUAL_PAD_CROSS = 665,
    VIRTUAL_PAD_SQUARE = 666,
    VIRTUAL_PAD_CIRCLE = 667,
    VIRTUAL_PAD_START = 668,
    VIRTUAL_PAD_SELECT = 669,
    VIRTUAL_PAD_LSTICK_UP = 670,
    VIRTUAL_PAD_LSTICK_DOWN = 671,
    VIRTUAL_PAD_LSTICK_LEFT = 672,
    VIRTUAL_PAD_LSTICK_RIGHT = 673,
    VIRTUAL_PAD_RSTICK_UP = 674,
    VIRTUAL_PAD_RSTICK_DOWN = 675,
    VIRTUAL_PAD_RSTICK_LEFT = 676,
    VIRTUAL_PAD_RSTICK_RIGHT = 677,
}

public enum SeVirtualKey : byte {
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
    F24 = 135,

    PAD_LMB = 160,
    PAD_MMB = 161,
    PAD_RMB = 162,
    PAD_MB4 = 163,
    PAD_MB5 = 164,
    PAD_MB6 = 165,
    PAD_MB7 = 166,
    PAD_UP = 167,
    PAD_DOWN = 168,
    PAD_LEFT = 169,
    PAD_RIGHT = 170,
    PAD_Y = 171,
    PAD_A = 172,
    PAD_X = 173,
    PAD_B = 174,
    PAD_LB = 175,
    PAD_LT = 176,
    PAD_LS = 177,
    PAD_RB = 178,
    PAD_RT = 179,
    PAD_RS = 180,
    PAD_Select = 181,
    PAD_Start = 182,
}
