namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe struct ShadowCamera {
    [FieldOffset(0x00)] public Camera Camera;
}
