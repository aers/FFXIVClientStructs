using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene; 

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct Camera
{
    [FieldOffset(0x00)] public Object Object;
    [FieldOffset(0x80)] public Vector3 Vector_0;
    [FieldOffset(0x90)] public Vector3 Vector_1;
    [FieldOffset(0xA0)] public Matrix4x4 ViewMatrix;
    [FieldOffset(0xE0)] public Render.Camera* RenderCamera;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E0 48 8B EB")]
    public partial void ScreenPointToRay(Ray* ray, int x, int y);

    public Ray ScreenPointToRay(Vector2 screenPoint) {
	    return ScreenPointToRay((int)screenPoint.X, (int)screenPoint.Y);
    }

    public Ray ScreenPointToRay(int x, int y) {
        var pRay = stackalloc Ray[1];
        ScreenPointToRay(pRay, x, y);
        return *pRay;
    }
}