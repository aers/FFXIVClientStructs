using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::Camera
//   Client::Game::CameraBase
// ctor "40 53 48 83 EC ?? 48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 83 C1 ?? E8 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 33 C9 24"
[GenerateInterop(isInherited: true)]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct Camera {
    [FieldOffset(0x124)] public float Distance;
    [FieldOffset(0x128)] public float MinDistance;
    [FieldOffset(0x12C)] public float MaxDistance;
    [FieldOffset(0x130)] public float FoV;
    [FieldOffset(0x134)] public float MinFoV;
    [FieldOffset(0x138)] public float MaxFoV;
    [FieldOffset(0x140)] public float DirH; // 0 is north, increases CW
    [FieldOffset(0x144)] public float DirV; // 0 is horizontal, positive is looking up, negative looking down
    [FieldOffset(0x148)] public float InputDeltaHAdjusted;
    [FieldOffset(0x14C)] public float InputDeltaVAdjusted;
    [FieldOffset(0x150)] public float InputDeltaH;
    [FieldOffset(0x154)] public float InputDeltaV;
    [FieldOffset(0x158)] public float DirVMin; // -85deg by default
    [FieldOffset(0x15C)] public float DirVMax; // +45deg by default
    [FieldOffset(0x18C)] public float InterpDistance;
    [FieldOffset(0x198)] public float SavedDistance;
}

// Client::Game::LobbyCamera
//   Client::Game::Camera
//     Client::Game::CameraBase
[GenerateInterop]
[Inherits<Camera>]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct LobbyCamera {
    [FieldOffset(0x308)] public ExcelSheet* LobbyExcelSheet;
}

// Client::Game::Camera3
//   Client::Game::Camera
//     Client::Game::CameraBase
[GenerateInterop]
[Inherits<Camera>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public partial struct Camera3;

// Client::Game::LowCutCamera
//   Client::Game::CameraBase
[GenerateInterop]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public partial struct LowCutCamera;

// Client::Game::Camera4
//   Client::Game::CameraBase
[GenerateInterop]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public partial struct Camera4 {
    [FieldOffset(0x120)] public Graphics.Scene.Camera SceneCamera0;
    [FieldOffset(0x220)] public Graphics.Scene.Camera SceneCamera1;
}
