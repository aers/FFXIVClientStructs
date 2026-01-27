using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Common.Math;

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

    [FieldOffset(0x180)] public CameraZoomMode ZoomMode;
    [FieldOffset(0x184)] public CameraControlMode ControlMode;

    [FieldOffset(0x18C)] public float InterpDistance;

    [FieldOffset(0x198)] public float SavedDistance;

    [FieldOffset(0x1C0)] public Vector3 LastPosition;
    [FieldOffset(0x1D0)] public Vector3 LastLookAtVector;
    [FieldOffset(0x1E0)] public bool ShouldResetAngles; // Pitch and Yaw

    [FieldOffset(0x1E4)] public float TiltOffset;
    [FieldOffset(0x1E8)] public bool IsEventCameraAutoControl; // also called Lockon => "Look at target when speaking."

    [FieldOffset(0x23C)] public uint SavedModelSkeletonId;

    [FieldOffset(0x290)] public uint ConfigOption_ThirdPersonDefaultYAngle;
    [FieldOffset(0x294)] public uint ConfigOption_ThirdPersonDefaultZoom;
    [FieldOffset(0x298)] public uint ConfigOption_ThirdPersonDefaultDistance;
    [FieldOffset(0x29C)] public uint ConfigOption_FirstPersonDefaultYAngle;
    [FieldOffset(0x2A0)] public uint ConfigOption_FirstPersonDefaultZoom;
    [FieldOffset(0x2A4)] public uint ConfigOption_FirstPersonDefaultDistance;
    [FieldOffset(0x2A8)] public uint ConfigOption_LockonDefaultYAngle;
    [FieldOffset(0x2AC)] public uint ConfigOption_LockonDefaultZoom;
    [FieldOffset(0x2B0)] public uint ConfigOption_LockonDefaultDistance;

    [VirtualFunction(13)]
    public partial bool UpdateTiltOffset();

    [VirtualFunction(16)]
    public partial CameraControlMode DetermineControlMode();

    [VirtualFunction(17)]
    public partial GameObject* GetCameraTargetObject();

    [VirtualFunction(18)]
    public partial float GetTiltOffset();

    [VirtualFunction(20)]
    public partial GameObject* GetTargetObject();

    [VirtualFunction(21)]
    public partial void Load(CameraControlMode controlMode);

    [VirtualFunction(23)]
    public partial void SaveConfigOptions();

    [VirtualFunction(24)]
    public partial void LoadConfigOptions();

    [VirtualFunction(25)]
    public partial void ResetConfigOptions();

    [VirtualFunction(26)]
    public partial void SetTiltOffset(float tiltOffset);

    [VirtualFunction(27)]
    public partial float GetZoomSpeed();

    [VirtualFunction(28)]
    public partial float GetZoomModeToggleSpeedMultiplier();

    [VirtualFunction(29)]
    public partial float GetInputDeltaHMultiplier();

    [VirtualFunction(30)]
    public partial float GetInputDeltaVMultiplier();
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

// Client::Game::SpectatorCamera
//   Client::Game::Camera
//     Client::Game::CameraBase
[GenerateInterop]
[Inherits<Camera>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public partial struct SpectatorCamera;

// TODO: remove (was replaced with SpectatorCamera)
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

// Client::Game::AimingCamera
//   Client::Game::CameraBase
[GenerateInterop]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public partial struct AimingCamera {
    [FieldOffset(0x120)] public Graphics.Scene.Camera SceneCamera0;
    [FieldOffset(0x220)] public Graphics.Scene.Camera SceneCamera1;
}

// TODO: remove (was replaced with AimingCamera)
// Client::Game::Camera4
//   Client::Game::CameraBase
[GenerateInterop]
[Inherits<CameraBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public partial struct Camera4 {
    [FieldOffset(0x120)] public Graphics.Scene.Camera SceneCamera0;
    [FieldOffset(0x220)] public Graphics.Scene.Camera SceneCamera1;
}

public enum CameraZoomMode {
    FirstPerson = 0,
    ThirdPerson = 1,
}

public enum CameraControlMode {
    FirstPerson = 0,
    /// <remarks> Legacy ("the camera will automatically turn based on the direction your character is moving or facing") </remarks>
    ThirdPersonLegacy = 1,
    /// <remarks> Standard and Legacy with "Disable camera pivot" enabled </remarks>
    ThirdPersonFixed = 2,
    LockonFirstPerson = 3,
    FirstPersonUnk = 4,
    LockonThirdPerson = 5,
}
