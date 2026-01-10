using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::CameraBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct CameraBase {
    [FieldOffset(0x10)] public Graphics.Scene.Camera SceneCamera;
    // IdleCam stuff
    [FieldOffset(0x110)] private uint Unk110; // IdleCam next object index for scanning
    [FieldOffset(0x114)] private uint Unk114; // IdleCam random decision "bool"?
    [FieldOffset(0x118)] private float Unk118; // IdleCam range?
    [FieldOffset(0x11C)] private byte Unk11C; // flags

    [VirtualFunction(2)]
    public partial void UpdateState();

    [VirtualFunction(3)]
    public partial void Update();

    [VirtualFunction(5)]
    public partial void ResetAngles();

    /// <remarks> Also called YAngle in ConfigOptions. </remarks>
    [VirtualFunction(6)]
    public partial float GetPitch();

    [VirtualFunction(7)]
    public partial float GetYaw();

    [VirtualFunction(8)]
    public partial void ResetAngles2();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 18 48 8D 0D ?? ?? ?? ?? B3 01")]
    public partial bool ShouldDrawGameObject(GameObject* gameObject, Vector3* sceneCameraPos, Vector3* lookAtVector);
}
