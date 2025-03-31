namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::GameWindow
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct GameWindow {
    [StaticAddress("89 15 ?? ?? ?? ?? 48 F7 E1", 2)]
    public static partial GameWindow* Instance();

    [FieldOffset(0x00)] public ulong ArgumentCount; // TODO: (u)int
    [FieldOffset(0x08)] public byte** Arguments; // Points to an array that points to CStr // TODO: use CStringPointer, add Span
    [FieldOffset(0x10)] public float FrameDeltaTime;
    [FieldOffset(0x18)] public nint WindowHandle;
    [FieldOffset(0x20)] public int WindowWidth; // Only used and correct if in Windowed Mode
    [FieldOffset(0x24)] public int WindowHeight; // Only used and correct if in Windowed Mode
    [FieldOffset(0x28)] public int LastWindowPosX;
    [FieldOffset(0x2C)] public int LastWindowPosY;
    [FieldOffset(0x31)] public bool Borderless;

    [FieldOffset(0x58)] public int MinWidth;
    [FieldOffset(0x5C)] public int MinHeight;

    public string GetArgument(ulong idx) => Marshal.PtrToStringUTF8(idx >= ArgumentCount ? nint.Zero : (nint)Arguments[idx]) ?? string.Empty;
}
