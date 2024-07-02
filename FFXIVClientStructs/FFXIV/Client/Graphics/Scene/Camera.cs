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
    [FieldOffset(0xA0)] public Matrix4x4 ViewMatrix;
    [FieldOffset(0xE0)] public Render.Camera* RenderCamera;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E0 48 8B EB")]
    public partial void ScreenPointToRay(Ray* ray, int x, int y);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C7 0F 28 CE")]
    public static partial Vector2* WorldToScreenPoint(Vector2* screenPoint, Vector3* worldPoint);

    public Ray ScreenPointToRay(Vector2 screenPoint) {
        var ray = new Ray();
        ScreenPointToRay(&ray, (int)screenPoint.X, (int)screenPoint.Y);
        return ray;
    }

    public bool ScreenToWorld(Vector2 screenPos, out Vector3 worldPos) {
        var ray = ScreenPointToRay(screenPos);
        var result = BGCollisionModule.RaycastMaterialFilter(ray.Origin, ray.Direction, out var hit);
        worldPos = hit.Point;
        return result;
    }

    public bool WorldToScreen(Vector3 worldPos, out Vector2 screenPos) {
        var device = Device.Instance();
        float width = device->Width;
        float height = device->Height;
        var pCoords = Vector4.Transform(new Vector4(worldPos, 1f), ViewMatrix * RenderCamera->ProjectionMatrix);
        if (Math.Abs(pCoords.W) < float.Epsilon) {
            screenPos = Vector2.Zero;
            return false;
        }
        
        pCoords *= MathF.Abs(1.0f / pCoords.W);
        screenPos = new Vector2 {
            X = (pCoords.X + 1.0f) * width * 0.5f,
            Y = (1.0f - pCoords.Y) * height * 0.5f
        };

        return IsOnScreen(new Vector3(pCoords.X, pCoords.Y, pCoords.Z));

        static bool IsOnScreen(Vector3 pos) {
            return -1.0 <= pos.X && pos.X <= 1.0 && -1.0 <= pos.Y && pos.Y <= 1.0 && pos.Z <= 1.0 && 0.0 <= pos.Z;
        }
    }
}
