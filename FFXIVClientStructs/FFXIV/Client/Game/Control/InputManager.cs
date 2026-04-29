namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::InputManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct InputManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F 28 F0 45 0F 57 C0", 3)]
    public static partial InputManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 44 8B C3")]
    public partial bool GetInputStatus(InputCode code);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 C8 4C 8B C7")]
    public static partial bool IsAutoRunning();

    [StaticAddress("8B 05 ?? ?? ?? ?? 41 8B DF", 2)]
    public static partial MouseButtonHoldState* GetMouseButtonHoldState();

    public static bool IsLeftMouseDown() => GetMouseButtonHoldState()->HasFlag(MouseButtonHoldState.Left);
    public static bool IsRightMouseDown() => GetMouseButtonHoldState()->HasFlag(MouseButtonHoldState.Right);
    public static bool IsAnyMouseDown() => *GetMouseButtonHoldState() != 0;

    [Flags]
    public enum MouseButtonHoldState : byte {
        None = 0,
        Left = 1,
        Right = 2,
    }
}

public enum InputCode {
    MOUSE_OK = 11,
    OK = 12,
    CANCEL = 13,
    LEFT = 14,
    RIGHT = 15,
    TARGET_NEXT = 16,
    TARGET_PREV = 17,

    TARGET_ALLIANCE1_NEXT = 24,
    TARGET_ALLIANCE1_PREV = 25,
    TARGET_ALLIANCE2_NEXT = 26,
    TARGET_ALLIANCE2_PREV = 27,

    TARGET_ALLIANCE1_1 = 30,
    TARGET_ALLIANCE1_2 = 31,
    TARGET_ALLIANCE1_3 = 32,
    TARGET_ALLIANCE1_4 = 33,
    TARGET_ALLIANCE1_5 = 34,
    TARGET_ALLIANCE1_6 = 35,
    TARGET_ALLIANCE1_7 = 36,
    TARGET_ALLIANCE1_8 = 37,
    TARGET_ALLIANCE2_1 = 38,
    TARGET_ALLIANCE2_2 = 39,
    TARGET_ALLIANCE2_3 = 40,
    TARGET_ALLIANCE2_4 = 41,
    TARGET_ALLIANCE2_5 = 42,
    TARGET_ALLIANCE2_6 = 43,
    TARGET_ALLIANCE2_7 = 44,
    TARGET_ALLIANCE2_8 = 45,

    CAMERA_BACKWARD = 47,

    CAMERA_SAVE = 49,
    CAMERA_RESET = 50,
    CAMERA_MOUSE_OK = 51,
    CAMERA_MOUSE_CANCEL = 52,
    CAMERA_UP = 53,
    CAMERA_DOWN = 54,
    CAMERA_LEFT = 55,
    CAMERA_RIGHT = 56,

    CAMERA_ZOOMIN = 58,
    CAMERA_ZOOMOUT = 59,

    CAM_TILT_UP = 64,
    CAM_TILT_DOWN = 65,

    TARGET_P1 = 68,
    TARGET_P2 = 69,
    TARGET_P3 = 70,
    TARGET_P4 = 71,
    TARGET_P5 = 72,
    TARGET_P6 = 73,
    TARGET_P7 = 74,
    TARGET_P8 = 75,

    TARGET_CLOSEST_ENEMY = 77,
    TARGET_CLOSEST_PC = 78,
    TARGET_CLOSEST_NPC = 79,
    TARGET_FOCUS = 80,
    TARGET_SELECT = 81,
    TARGET_PET = 82,
    BUDDY_TARGET = 83,

    CIRCLE_1 = 86,
    CIRCLE_2 = 87,
    CIRCLE_3 = 88,
    CIRCLE_4 = 89,
    CIRCLE_ALL = 90,
    CIRCLE_PC = 91,
    CIRCLE_ENEMY = 92,
    CIRCLE_PARTY = 93,

    TARGET_LOCK = 95,

    TARGET_CLICK_FILTER = 105,
    MOUSE_CANCEL = 106,
    MOVE_DESCENT = 107,
    MOVE_RETENTION = 108,
    MOVE_ANGLE_RISING = 109,
    MOVE_ANGLE_DESCENT = 110,

    MOVE_FORE = 112,
    MOVE_BACK = 113,
    MOVE_LEFT = 114,
    MOVE_STRIFE_L = 115,
    MOVE_RIGHT = 116,
    MOVE_STRIFE_R = 117,
}
