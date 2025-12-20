using FFXIVClientStructs.FFXIV.Common.Math;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::GroupPoseModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct GroupPoseModule {
    public static GroupPoseModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetGroupPoseModule();
    }

    // [FieldOffset(0x48)] private byte Unk40;
    // [FieldOffset(0x49)] private byte Unk41;

    // [FieldOffset(0x4C)] private float Unk44;
    // [FieldOffset(0x50)] private float Unk48;
    [FieldOffset(0x54)] public float CameraAngle; // 0.5 to -0.5
    // [FieldOffset(0x58)] private float Unk50;
    // [FieldOffset(0x5C)] private float Unk54;

    [FieldOffset(0x68)] public float CameraRotation; // -PI to PI

    [FieldOffset(0x78)] public Vector4 CameraPosition; // maybe?
    [FieldOffset(0x88)] public bool IsCharacterOrientedCamera;

    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray3<Light> _lights;

    [FieldOffset(0x128)] public bool IsCharacterOrientedLight;
    [FieldOffset(0x129)] public bool IsManualBrightnessEnabled;

    [FieldOffset(0x12C)] public float ManualBrightness;
    [FieldOffset(0x130)] public byte CharacterLighting;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct Light {
        [FieldOffset(0)] public bool IsEnabled;

        [FieldOffset(0x4)] public float Red; // 0 - 4.0
        [FieldOffset(0x8)] public float Green; // 0 - 4.0
        [FieldOffset(0xC)] public float Blue; // 0 - 4.0
        [FieldOffset(0x10)] public uint Type; // 0 - 2

        [FieldOffset(0x20)] public Vector4 Position;
    }
}
