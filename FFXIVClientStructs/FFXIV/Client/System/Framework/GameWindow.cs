namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x282)]
public unsafe struct GameWindow {
    [FieldOffset(0x00)] public ulong ArgumentCount;
    [FieldOffset(0x08)] public byte** Arguments; //Points to an array that points to CStr
    [FieldOffset(0x10)] public float FrameDeltaTime;
    [FieldOffset(0x18)] public nint WindowHandle;
    [FieldOffset(0x20)] public int WindowWidth; //Only used and correct if in Windowed Mode
    [FieldOffset(0x24)] public int WindowHeight; //Only used and correct if in Windowed Mode
    [FieldOffset(0x28)] public int LastWindowPosX;
    [FieldOffset(0x2C)] public int LastWindowPosY;

    [FieldOffset(0x58)] public int MinWidth;
    [FieldOffset(0x5C)] public int MinHeight;
    [FieldOffset(0x80)] public fixed char Username[257]; //UNLEN+1

    public string GetArgument(ulong idx) => Marshal.PtrToStringUTF8(idx >= ArgumentCount ? nint.Zero : (nint)Arguments[idx]) ?? string.Empty;
}
