using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::CameraBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct CameraBase {
    [FieldOffset(0x10)] public Graphics.Scene.Camera SceneCamera;
    [FieldOffset(0x100)] public uint UnkUInt;
    [FieldOffset(0x108)] public uint UnkFlags;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 18 48 8D 0D ?? ?? ?? ?? B3 01")]
    public partial bool ShouldDrawGameObject(GameObject* gameObject, Vector3* sceneCameraPos, Vector3* lookAtVector);
}
