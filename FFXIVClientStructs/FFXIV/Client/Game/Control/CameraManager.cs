namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::CameraManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct CameraManager {
    public static CameraManager* Instance() => (CameraManager*)Control.Instance();

    /// <summary>
    /// [0] Camera (normal in-game camera)<br/>
    /// [1] LowCutCamera<br/>
    /// [2] LobbyCamera<br/>
    /// [3] SpectatorCamera<br/>
    /// [4] AimingCamera
    /// </summary>
    [FieldOffset(0x00), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5<Pointer<Camera>> _cameras;
    [FieldOffset(0x00)] public Camera* Camera;
    [FieldOffset(0x08)] public LowCutCamera* LowCutCamera;
    [FieldOffset(0x10)] public LobbyCamera* LobbyCamera;
    [FieldOffset(0x18)] public SpectatorCamera* SpectatorCamera;
    [FieldOffset(0x20)] public AimingCamera* AimingCamera;

    [FieldOffset(0x48)] public int ActiveCameraIndex;
    [FieldOffset(0x4C)] public int PreviousCameraIndex;

    [FieldOffset(0x60)] private CameraBase UnkCamera; //not a pointer

    [FieldOffset(0x10), Obsolete("Renamed to LobbyCamera")] public LobbyCamera* LobbCamera;
    [FieldOffset(0x18), Obsolete("Renamed to SpectatorCamera")] public Camera3* Camera3;
    [FieldOffset(0x18), Obsolete("Renamed to AimingCamera")] public Camera4* Camera4;

    [MemberFunction("E8 ?? ?? ?? ?? 39 B0")]
    public partial Camera* GetActiveCamera();
}
