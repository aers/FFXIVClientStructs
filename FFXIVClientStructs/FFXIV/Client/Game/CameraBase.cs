namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe struct CameraBase
{
    [FieldOffset(0x00)] public void** vtbl;
    [FieldOffset(0x10)] public Graphics.Scene.Camera SceneCamera;
    [FieldOffset(0x100)] public uint UnkUInt;
    [FieldOffset(0x108)] public uint UnkFlags;
}