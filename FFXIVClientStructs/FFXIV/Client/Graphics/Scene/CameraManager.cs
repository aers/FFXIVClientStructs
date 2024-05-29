namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct CameraManager {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 48 83 C1 10 48 C7 40 ?? ?? ?? ?? ??", 3, isPointer: true)]
    public static partial CameraManager* Instance();

    [FieldOffset(0x50)] public int CameraIndex;
    [FieldOffset(0x58)][FixedSizeArray] internal FixedSizeArray14<Pointer<Camera>> _cameras;

    public Camera* CurrentCamera => Cameras[CameraIndex];
}
