using FFXIVClientStructs.FFXIV.Client.System.File;

namespace FFXIVClientStructs.FFXIV.Client.System.Photo;

public unsafe partial struct ScreenShot {
    [StructLayout(LayoutKind.Explicit, Size = 0x288)]
    [Inherits<FFXIV.Client.System.Threading.Thread>]
    public struct ScreenShotThread {
        [FieldOffset(0x28)] public TargetFileFormat TargetFileFormat;
        [FieldOffset(0x38)] public ScreenShot* Parent;
        [FieldOffset(0x48)] private nint EventHandle; // CreateEventA(0LL, 0, 0, 0LL)
        [FieldOffset(0x50)] private fixed byte CriticalSection[40];
        [FieldOffset(0x78)] public FileAccessPath ScreenShotStorageDirectory;
    }
}
