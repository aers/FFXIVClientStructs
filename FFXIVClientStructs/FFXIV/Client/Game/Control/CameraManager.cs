namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::CameraManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x180)]
public unsafe partial struct CameraManager {
    public static CameraManager* Instance() => (CameraManager*)Control.Instance();

    [FieldOffset(0x00)] public Camera* Camera;
    [FieldOffset(0x08)] public LowCutCamera* LowCutCamera;
    [FieldOffset(0x10)] public LobbyCamera* LobbCamera;
    [FieldOffset(0x18)] public Camera3* Camera3;
    [FieldOffset(0x20)] public Camera4* Camera4;

    [FieldOffset(0x48)] public int ActiveCameraIndex;
    [FieldOffset(0x4C)] public int PreviousCameraIndex;

    [FieldOffset(0x60)] public CameraBase UnkCamera; //not a pointer

    [MemberFunction("E8 ?? ?? ?? ?? 45 32 FF 40 32 F6")]
    public partial Camera* GetActiveCamera();
}
