namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::MouseData
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct CursorInputData { // TODO: rename struct to MouseData
    [FieldOffset(0x00)] public int PositionX;
    [FieldOffset(0x04)] public int PositionY;
    [FieldOffset(0x08)] public int MouseWheel; // -1 for scroll down, 1 for scroll up
    [FieldOffset(0x0C)] public MouseButtonFlags MouseButtonHeldFlags;
    [FieldOffset(0x10)] public MouseButtonFlags MouseButtonPressedFlags;
    [FieldOffset(0x14)] public MouseButtonFlags MouseButtonReleasedFlags;
    [FieldOffset(0x18)] public MouseButtonFlags MouseButtonHeldThrottledFlags;

    [FieldOffset(0x20)] public int DeltaX; // Delta since last frame
    [FieldOffset(0x24)] public int DeltaY; // Delta since last frame

    /// <remarks> The definition of this field overlaps with whether the cursor device was acquired using IDirectInputDevice8::Acquire/Unacquire. </remarks>
    [FieldOffset(0x2C)] public bool IsGameWindowFocused;

    [MemberFunction("84 D2 74 0F 33 C0")]
    public partial void Clear(bool clearPositionAndWheel, MouseButtonFlags buttonsToClear);
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
