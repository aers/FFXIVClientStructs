using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene; 

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct Camera
{
    [FieldOffset(0x00)] public Object Object;
    [FieldOffset(0x80)] public Vec3 LookAtVector;
    [FieldOffset(0x90)] public Vec3 Vector_1;
    [FieldOffset(0xA0)] public Mat4x4 ViewMatrix;
    [FieldOffset(0xE0)] public Render.Camera* RenderCamera;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E0 48 8B EB")]
    public partial void ScreenPointToRay(Ray* ray, int x, int y);

    public Ray ScreenPointToRay(Vec2 screenPoint) {
	    return ScreenPointToRay((int)screenPoint.X, (int)screenPoint.Y);
    }

    public Ray ScreenPointToRay(int x, int y) {
        var pRay = stackalloc Ray[1];
        ScreenPointToRay(pRay, x, y);
        return *pRay;
    }

    public static Vec3 ScreenToWorldPoint(Vec2 screenPoint) {
	    var ray = CameraManager.Instance()->CurrentCamera->ScreenPointToRay(screenPoint);
	    BGCollisionModule.Raycast(ray.Origin, ray.Direction, out var hit);
	    return hit.Point;
    }

    public static Vec2 WorldToScreenPoint(Vec3 worldPoint) {
	    var screen = stackalloc float[2];
	    WorldToScreenPoint(screen, worldPoint);
	    return *(Vec2*)screen;
    }

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B E9 48 8B DA 48 8D 0D")]
    private static partial float* WorldToScreenPoint(float* screenPoint, Vec3 worldPoint);
}