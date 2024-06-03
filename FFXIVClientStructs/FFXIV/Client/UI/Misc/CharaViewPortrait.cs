using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaViewPortrait
//   Client::UI::Misc::CharaView
// ctor "E8 ?? ?? ?? ?? 48 8B F8 45 33 C0"
[GenerateInterop]
[Inherits<CharaView>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C0)]
public unsafe partial struct CharaViewPortrait : ICreatable {
    // Spherical Camera?
    [FieldOffset(0x2D0)] public Vector4 CameraPosition;
    [FieldOffset(0x2E0)] public Vector4 CameraTarget;
    [FieldOffset(0x2F0)] public float CameraYaw; // automatically calculated
    [FieldOffset(0x2F4)] public float CameraPitch; // automatically calculated
    [FieldOffset(0x2F8)] public float CameraDistance; // automatically calculated euclidean distance
    [FieldOffset(0x2FC)] public short ImageRotation; // -90 to 90
    [FieldOffset(0x2FE)] public byte CameraZoom; // 0 to 200

    [FieldOffset(0x300)] public float CameraZoomNormalized; // automatically calculated
    [FieldOffset(0x304)] public byte DirectionalLightingColorRed;
    [FieldOffset(0x305)] public byte DirectionalLightingColorGreen;
    [FieldOffset(0x306)] public byte DirectionalLightingColorBlue;
    [FieldOffset(0x307)] public byte DirectionalLightingBrightness;
    [FieldOffset(0x308)] public short DirectionalLightingVerticalAngle; // -180 to 180
    [FieldOffset(0x30A)] public short DirectionalLightingHorizontalAngle; // -180 to 180
    [FieldOffset(0x30C)] public byte AmbientLightingColorRed;
    [FieldOffset(0x30D)] public byte AmbientLightingColorGreen;
    [FieldOffset(0x30E)] public byte AmbientLightingColorBlue;
    [FieldOffset(0x30F)] public byte AmbientLightingBrightness;

    [FieldOffset(0x314)] public short PoseClassJob;
    [FieldOffset(0x316)] public short BannerBg;
    [FieldOffset(0x318)] public byte BackgroundState; // 0 = do nothing, 1 = loads texture by icon from row, 2 = renders KernelTexture?, 3 = done

    [FieldOffset(0x320)] public AtkTexture BackgroundTexture;

    [FieldOffset(0x338)] public CharaViewCharacterData PortraitCharacterData;
    [FieldOffset(0x3A0)] public bool CharacterVisible;
    [FieldOffset(0x3A1)] public bool CharaViewPortraitCharacterDataCopied;
    [FieldOffset(0x3A2)] public bool CharaViewPortraitCharacterLoaded;

    public static CharaViewPortrait* Create()
        => IMemorySpace.GetUISpace()->Create<CharaViewPortrait>();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 45 33 C0")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 10 C6 80 ?? ?? ?? ?? ?? 48 8B 4B 10")]
    public partial void Setup(uint clientObjectId, CharaViewCharacterData* characterData, long a4, int a5, long a6); // a4 is set to +0x3A8, a5 is set to +0x3B0, a6 is set to +0x3B8

    [VirtualFunction(4)]
    public partial void SetCameraDistance(float deltaDistance);

    [VirtualFunction(5)]
    public partial void SetCameraYawAndPitch(float deltaRotation, float deltaPitch);

    [VirtualFunction(6)]
    public partial void SetCameraXAndY(float deltaX, float deltaY);

    [VirtualFunction(10)]
    public partial void Update();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4D 18 48 8B 01")]
    public partial void ResetCamera(); // sets position, target, zoom etc.

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 47 10")]
    public partial void SetCameraPosition(HalfVector4* cam, HalfVector4* target);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 97 ?? ?? ?? ?? 0F 28 D0")]
    public partial float GetAnimationTime();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 97 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 C0")]
    public partial void SetAmbientLightingColor(uint red, uint green, uint blue);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4F 20 E8 ?? ?? ?? ?? 44 0F B6 8B ?? ?? ?? ?? 0F B6 D0")]
    public partial void SetAmbientLightingBrightness(byte brightness);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B 18 0F B6 47 29 F3 0F 10 35 ?? ?? ?? ?? 48 8B 74 24 ??")]
    public partial void SetDirectionalLightingColor(uint red, uint green, uint blue);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4F 20 E8 ?? ?? ?? ?? 44 0F B7 83")]
    public partial void SetDirectionalLightingBrightness(byte brightness);

    [MemberFunction("E8 ?? ?? ?? ?? EB 5A 48 8D 4F 20")]
    public partial void SetDirectionalLightingAngle(short vertical, short horizontal);

    [MemberFunction("E8 ?? ?? ?? ?? EB 17 48 8D 4F 20")]
    public partial void SetCameraZoom(byte zoom);

    [MemberFunction("E8 ?? ?? ?? ?? 41 B7 01 48 63 47 48")]
    public partial void SetBackground(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 FF 74 53")]
    public partial void SetPose(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 74 56")]
    public partial void SetPoseTimed(ushort id, float time);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 F6 74 4F 48 63 83 ?? ?? ?? ??")]
    public partial void SetExpression(byte id);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 44 24 ?? 66 89 43 7C")]
    public partial nint ExportPortraitData(ExportedPortraitData* output);

    [MemberFunction("E8 ?? ?? ?? ?? 83 BE ?? ?? ?? ?? ?? 4C 8B B4 24 ?? ?? ?? ?? 74 2D")]
    public partial nint ImportPortraitData(ExportedPortraitData* input);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 57 ?? 48 8B CB")]
    public partial void ApplyCameraPositions(); // use this after manually setting camera positions

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 4F 24 E8 ?? ?? ?? ?? 0F B7 4F 22 0F 28 F0 E8 ?? ?? ?? ?? 0F 28 C8 0F 28 D6 48 8B CB E8 ?? ?? ?? ?? 44 0F B6 4F ?? 48 8B CB 44 0F B6 47 ?? 0F B6 57 26 E8 ?? ?? ?? ?? 48 8B 4B 18 0F B6 47 29 F3 0F 10 35 ?? ?? ?? ?? 48 8B 74 24 ??")]
    public partial void SetHeadDirection(float a2, float a3);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 4F ?? 48 8B CB 44 0F B6 47 ?? 0F B6 57 26 E8 ?? ?? ?? ?? 48 8B 4B 18 0F B6 47 29 F3 0F 10 35 ?? ?? ?? ?? 48 8B 74 24 ??")]
    public partial void SetEyeDirection(float a2, float a3);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 48 8B 01 FF 90 ?? ?? ?? ?? 48 8B 48 08")]
    public partial void ResetEyeDirection();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ??")]
    public partial void ResetHeadDirection();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B DF BA ?? ?? ?? ??")]
    public partial void ToggleCharacterVisibility(bool visible);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 45 A4")]
    public partial void ToggleGearVisibility(bool hideVisor, bool hideWeapon, bool closeVisor);
}

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe struct ExportedPortraitData {
    [FieldOffset(0x0)] public HalfVector4 CameraPosition;
    [FieldOffset(0x8)] public HalfVector4 CameraTarget;
    [FieldOffset(0x10)] public short ImageRotation;
    [FieldOffset(0x12)] public byte CameraZoom;
    [FieldOffset(0x14)] public ushort BannerTimeline;
    [FieldOffset(0x18)] public float AnimationProgress;
    [FieldOffset(0x1C)] public byte Expression;
    [FieldOffset(0x1E)] public HalfVector2 HeadDirection;
    [FieldOffset(0x22)] public HalfVector2 EyeDirection;
    [FieldOffset(0x26)] public byte DirectionalLightingColorRed;
    [FieldOffset(0x27)] public byte DirectionalLightingColorGreen;
    [FieldOffset(0x28)] public byte DirectionalLightingColorBlue;
    [FieldOffset(0x29)] public byte DirectionalLightingBrightness;
    [FieldOffset(0x2A)] public short DirectionalLightingVerticalAngle;
    [FieldOffset(0x2C)] public short DirectionalLightingHorizontalAngle;
    [FieldOffset(0x2E)] public byte AmbientLightingColorRed;
    [FieldOffset(0x2F)] public byte AmbientLightingColorGreen;
    [FieldOffset(0x30)] public byte AmbientLightingColorBlue;
    [FieldOffset(0x31)] public byte AmbientLightingBrightness;
    [FieldOffset(0x32)] public ushort BannerBg;
}
