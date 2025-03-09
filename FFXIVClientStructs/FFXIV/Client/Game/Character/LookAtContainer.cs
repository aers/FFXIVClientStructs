using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::LookAtContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xBE0)]
public unsafe partial struct LookAtContainer {
    [FieldOffset(0x10)] public CharacterLookAtController Controller;
    /// <summary>
    /// When using /facecamera, this is the rotation of the camera.<br/>
    /// When editing banner and the character is following the camera (either with head or eyes), this field holds the position of the camera.
    /// </summary>
    [FieldOffset(0xBA0)] public Vector3 CameraVector; // maybe Vector4 with unused W field?

    [FieldOffset(0xBB0)] public byte FaceCameraFlag; // looks like a bitfield but only with one bit used

    [FieldOffset(0xBB4)] public Vector2 BannerHeadDirection; // TODO: these are of type Client::Game::Control::MoveControl::SplineVector2
    [FieldOffset(0xBBC)] public Vector2 BannerEyeDirection;
    [FieldOffset(0xBC4)] public BannerCameraFollowFlags BannerCameraFollowFlag;

    public bool IsFacingCamera {
        get => (FaceCameraFlag & 0x1) == 0x1;
        set {
            if (value) FaceCameraFlag |= 0x1;
            else FaceCameraFlag = (byte)(FaceCameraFlag & ~1);
        }
    }

    [Flags]
    public enum BannerCameraFollowFlags : byte {
        None = 0,
        Head = 1,
        Eyes = 2,
    }
}
