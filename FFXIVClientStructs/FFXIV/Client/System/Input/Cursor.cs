using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::Cursor
//ctor "E8 ?? ?? ?? ?? 48 8B C8 EB ?? 48 8B CE 48 89 8F"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public unsafe partial struct Cursor {
    [StaticAddress("75 36 48 8B 15 ?? ?? ?? ??", 5, isPointer: true)]
    public static partial Cursor* Instance();

    [FieldOffset(0x009)] public bool UseSoftwareCursor;
    [FieldOffset(0x00A)] public byte SoftwareCursorScale;
    [FieldOffset(0x00B)] public bool IsCursorVisible;
    [FieldOffset(0x00C)] public bool MouseNotCpatured;
    [FieldOffset(0x00D)] public bool IsCursorOutsideViewPort;

    [FieldOffset(0x010)] public uint ActiveCursorType; //Hand,Cursor, Cross, etc

    [FieldOffset(0x1B0), FixedSizeArray] internal FixedSizeArray16<ulong> _cursorHandles; //HCURSOR (winuser.h)

    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray16<CStringPointer> _cursorNames;
    [FieldOffset(0x2C0)] public int HardwareCursorSize;
    [FieldOffset(0x2C8)] public TextureResourceHandle* SoftwareCursorTexture;

    [FieldOffset(0x368)] public bool ShowSoftwareCursorTrajectory;

    [FieldOffset(0x370)] public bool UseOsHardwareCursor;
}
