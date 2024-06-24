using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::Camera
//   Client::Game::CameraBase
// ctor "40 53 48 83 EC ?? 48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 83 C1 ?? E8 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 33 C9 24"
[GenerateInterop(isInherited: true)]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public partial struct Camera {
    [FieldOffset(0x114)] public float Distance;
    [FieldOffset(0x118)] public float MinDistance;
    [FieldOffset(0x11C)] public float MaxDistance;
    [FieldOffset(0x120)] public float FoV;
    [FieldOffset(0x124)] public float MinFoV;
    [FieldOffset(0x128)] public float MaxFoV;
    [FieldOffset(0x17C)] public float InterpDistance;
    [FieldOffset(0x188)] public float SavedDistance;
}

// Client::Game::LobbyCamera
//   Client::Game::Camera
//     Client::Game::CameraBase
[GenerateInterop]
[Inherits<Camera>]
[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe partial struct LobbyCamera {
    [FieldOffset(0x2F8)] public ExcelSheet* LobbyExcelSheet;
}

// Client::Game::Camera3
//   Client::Game::Camera
//     Client::Game::CameraBase
[GenerateInterop]
[Inherits<Camera>]
[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public partial struct Camera3;

// Client::Game::LowCutCamera
//   Client::Game::CameraBase
[GenerateInterop]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public partial struct LowCutCamera;

// Client::Game::Camera4
//   Client::Game::CameraBase
[GenerateInterop]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x350)]
public partial struct Camera4 {
    [FieldOffset(0x110)] public Graphics.Scene.Camera SceneCamera0;
    [FieldOffset(0x200)] public Graphics.Scene.Camera SceneCamera1;
}
