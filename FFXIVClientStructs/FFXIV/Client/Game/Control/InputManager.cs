namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::InputManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct InputManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F 28 F0 45 0F 57 C0", 3)]
    public static partial InputManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 3A C3 74 0C")]
    public static partial bool IsAutoRunning();

    [StaticAddress("39 1D ?? ?? ?? ?? 74 14", 2)]
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
