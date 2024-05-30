namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public partial struct CameraBase {
    [FieldOffset(0x10)] public Graphics.Scene.Camera SceneCamera;
    [FieldOffset(0x100)] public uint UnkUInt;
    [FieldOffset(0x108)] public uint UnkFlags;
}
