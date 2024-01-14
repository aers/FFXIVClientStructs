using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::GroupPoseModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 33 C0"
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe partial struct GroupPoseModule {
    public static GroupPoseModule* Instance() => Framework.Instance()->GetUiModule()->GetGroupPoseModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    // [FieldOffset(0x40)] public byte Unk40;
    // [FieldOffset(0x41)] public byte Unk41;

    // [FieldOffset(0x44)] public float Unk44;
    // [FieldOffset(0x48)] public float Unk48;
    [FieldOffset(0x4C)] public float CameraAngle; // 0.5 to -0.5
    // [FieldOffset(0x50)] public float Unk50;
    // [FieldOffset(0x54)] public float Unk54;

    [FieldOffset(0x60)] public float CameraRotation; // -PI to PI

    [FieldOffset(0x70)] public Vector4 CameraPosition; // maybe?
    [FieldOffset(0x80)] public bool IsCharacterOrientedCamera;

    [FixedSizeArray<Light>(3)]
    [FieldOffset(0x90)] public fixed byte Lights[3 * 0x30];

    [FieldOffset(0x120)] public bool IsCharacterOrientedLight;
    [FieldOffset(0x121)] public bool IsManualBrightnessEnabled;

    [FieldOffset(0x124)] public float ManualBrightness;
    [FieldOffset(0x128)] public byte CharacterLighting;

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
