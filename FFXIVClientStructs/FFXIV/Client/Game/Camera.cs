namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public struct Camera
{
    [FieldOffset(0x00)] public CameraBase CameraBase;
    [FieldOffset(0x114)] public float Distance;
    [FieldOffset(0x118)] public float MinDistance;
    [FieldOffset(0x11C)] public float MaxDistance;
    [FieldOffset(0x120)] public float FoV;
    [FieldOffset(0x124)] public float MinFoV;
    [FieldOffset(0x128)] public float MaxFoV;
    [FieldOffset(0x17C)] public float InterpDistance;
    [FieldOffset(0x188)] public float SavedDistance;
}

[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe struct LobbyCamera
{
    [FieldOffset(0x00)] public Camera Camera;
    [FieldOffset(0x2F8)] public void* LobbyExcelSheet;
}

[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public struct Camera3
{
    [FieldOffset(0x00)] public Camera Camera;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public struct LowCutCamera
{
    [FieldOffset(0x00)] public CameraBase CameraBase;
}

[StructLayout(LayoutKind.Explicit, Size = 0x350)]
public struct Camera4
{
    [FieldOffset(0x00)] public CameraBase CameraBase;

    [FieldOffset(0x110)] public Graphics.Scene.Camera SceneCamera0;
    [FieldOffset(0x200)] public Graphics.Scene.Camera SceneCamera1;
}
