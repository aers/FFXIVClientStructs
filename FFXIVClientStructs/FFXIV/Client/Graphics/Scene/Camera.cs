namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene; 

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe struct Camera
{
    [FieldOffset(0x00)] public Object Object;
    [FieldOffset(0x80)] public Vector3 Vector_0;
    [FieldOffset(0x90)] public Vector3 Vector_1;
    [FieldOffset(0xA0)] public Vector3 Vector_2;
    [FieldOffset(0xB0)] public Vector3 Vector_3;
    [FieldOffset(0xC0)] public Vector3 Vector_4;
    [FieldOffset(0xD0)] public Vector3 Vector_5;
    [FieldOffset(0xE0)] public Render.Camera* RenderCamera;
}