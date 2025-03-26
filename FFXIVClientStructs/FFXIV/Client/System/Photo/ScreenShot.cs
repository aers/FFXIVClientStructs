using FFXIVClientStructs.FFXIV.Client.System.File;

namespace FFXIVClientStructs.FFXIV.Client.System.Photo;

[GenerateInterop]
[Inherits<Client.System.Framework.Task>]
[StructLayout(LayoutKind.Explicit, Size = 0x288)]
public unsafe partial struct ScreenShot {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 41 B0", 3, isPointer: true)]
    public static partial ScreenShot* Instance();

    [FieldOffset(0x38)] public ScreenShotThread* ThreadPtr;

    /// <summary>
    /// Controls whether the game will let the player take a screenshot.
    /// </summary>
    [FieldOffset(0x40)] public bool CanTakeScreenShot;

    /// <summary>
    /// Set to true when a screenshot has been enqueued.
    /// </summary>
    [FieldOffset(0x41)] public bool ScreenShotRequested;

    [FieldOffset(0x48)] private void* CallbackParam;
    [FieldOffset(0x50)] private nint EventHandle; // CreateEventA(0LL, 0, 0, 0LL)

    [FieldOffset(0x5C)] public ScreenShotResultCode ScreenShotResult;

    /// <summary>
    /// The timestamp of the last screenshot.
    /// </summary>
    [FieldOffset(0x60)] public long ScreenShotTimestamp;

    /// <summary>
    /// The function to be called when a screenshot is completed.
    /// Set to null after being called.
    /// </summary>
    [FieldOffset(0x68)] public delegate* unmanaged<void*, int, void> ScreenShotCallbackFunc;

    /// <summary>
    /// The file format that screenshots should be taken in.
    /// Set by config key ScreenShotImageType on scheduling.
    /// </summary>
    [FieldOffset(0x70)] public TargetFileFormat ScreenShotFileFormat;

    /// <summary>
    /// The location that the last screenshot was written to.
    /// </summary>
    [FieldOffset(0x78)] private FileAccessPath ScreenShotLocation;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 15 C6 05")]
    public partial bool ScheduleScreenShot(delegate* unmanaged<void*, int, void> callback, void* callbackParam);

    public enum TargetFileFormat {
        Bmp = 0,
        Jpg = 1,
        Png = 3,
        Dds = 4
    }

    public enum ScreenShotResultCode {
        Success = 0,
        NoDiskSpace = 1,
        // 2+ are errors
    }
}
