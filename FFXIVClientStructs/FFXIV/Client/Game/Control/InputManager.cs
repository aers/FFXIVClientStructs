namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::InputManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct InputManager {

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 C8 4C 8B C7")]
    public static partial bool IsAutoRunning();

    [StaticAddress("75 09 83 3D ?? ?? ?? ?? ?? 75 12", 4)]
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
