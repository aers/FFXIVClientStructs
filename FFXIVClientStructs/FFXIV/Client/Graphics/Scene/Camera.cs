using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Camera
//   Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<Object>]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct Camera {
    [FieldOffset(0x80)] public Vector3 LookAtVector;
    [FieldOffset(0x90)] public Vector3 Vector_1;
    [FieldOffset(0xA0)] public Matrix4x4 ViewMatrix; // TODO: change to InverseViewMatrix
    [FieldOffset(0xE0)] public Render.Camera* RenderCamera;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E0 48 8B EB")]
    public partial void ScreenPointToRay(Ray* ray, int x, int y);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C7 0F 28 CE")]
    private static partial Vector2* WorldToScreenPoint(Vector2* screenPoint, Vector3* worldPoint);

    public Ray ScreenPointToRay(Vector2 screenPoint) {
        return ScreenPointToRay((int)screenPoint.X, (int)screenPoint.Y);
    }

    public Ray ScreenPointToRay(int x, int y) {
        var pRay = stackalloc Ray[1];
        ScreenPointToRay(pRay, x, y);
        return *pRay;
    }

    public static Vector3 ScreenToWorldPoint(Vector2 screenPoint) {
        var ray = CameraManager.Instance()->CurrentCamera->ScreenPointToRay(screenPoint);
        BGCollisionModule.Raycast(ray.Origin, ray.Direction, out var hit);
        return hit.Point;
    }

    public static Vector2 WorldToScreenPoint(Vector3 worldPoint) {
        var screen = stackalloc Vector2[1];
        return *WorldToScreenPoint(screen, &worldPoint);
    }

    public bool ScreenToWorld(Vector2 screenPos, out Vector3 worldPos) {
        var ray = ScreenPointToRay(screenPos);
        var result = BGCollisionModule.Raycast(ray.Origin, ray.Direction, out var hit);
        worldPos = hit.Point;
        return result;
    }

    public bool WorldToScreen(Vector3 worldPos, out Vector2 screenPos) {
        var device = Device.Instance();
        float width = device->Width;
        float height = device->Height;
        var pCoords = Vector3.Transform(worldPos, ViewMatrix * RenderCamera->ProjectionMatrix);
        screenPos = new Vector2(pCoords.X / MathF.Abs(pCoords.Z), pCoords.Y / MathF.Abs(pCoords.Z));
        screenPos.X = 0.5f * width * (screenPos.X + 1.0f);
        screenPos.Y = 0.5f * height * (1.0f - screenPos.Y);
        return pCoords.Z > 0.0f;
    }
}
