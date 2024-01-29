using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaViewPortrait
//   Client::UI::Misc::CharaView
// ctor "E8 ?? ?? ?? ?? 48 8B F8 45 33 C0"
[StructLayout(LayoutKind.Explicit, Size = 0x3C0)]
public unsafe partial struct CharaViewPortrait : ICreatable {
    [FieldOffset(0)] public CharaView Base;

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
    [FieldOffset(0x3A1)] public bool CharacterDataCopied;
    [FieldOffset(0x3A2)] public bool CharacterLoaded;

    public static CharaViewPortrait* Create()
        => IMemorySpace.GetUISpace()->Create<CharaViewPortrait>();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? EB 0B")]
    public readonly partial void Ctor();

    [VirtualFunction(0)]
    public readonly partial void Dtor(bool freeMemory);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 10 C6 80 ?? ?? ?? ?? ?? 48 8B 4B 10")]
    public readonly partial void Initialize(int clientObjectId, CharaViewCharacterData* characterData, long a4, int a5, long a6); // a4 is set to +0x3A8, a5 is set to +0x3B0, a6 is set to +0x3B8

    [VirtualFunction(2)]
    public readonly partial void Release(); // aka Finalize

    [VirtualFunction(3)]
    public readonly partial void ResetPositions();

    [VirtualFunction(4)]
    public readonly partial void SetCameraDistance(float deltaDistance);

    [VirtualFunction(5)]
    public readonly partial void SetCameraYawAndPitch(float deltaRotation, float deltaPitch);

    [VirtualFunction(6)]
    public readonly partial void SetCameraXAndY(float deltaX, float deltaY);

    [VirtualFunction(10)]
    public readonly partial void Update();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4C 24 ?? 48 8B 01 FF 90")]
    public readonly partial void ResetCamera(); // sets position, target, zoom etc.

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 43 10 48 8D 4C 24")]
    public readonly partial void SetCameraPosition(HalfVector4* cam, HalfVector4* target);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 93 ?? ?? ?? ?? 0F 28 D0")]
    public readonly partial float GetAnimationTime();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 96 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? BB")]
    public readonly partial void SetAmbientLightingColor(uint red, uint green, uint blue);

    [MemberFunction("E8 ?? ?? ?? ?? BB ?? ?? ?? ?? 48 8D 45 C7 8B D3 33 C9 0F 1F 40 00")]
    public readonly partial void SetAmbientLightingBrightness(byte brightness);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 96 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? 44 0F B7 86")]
    public readonly partial void SetDirectionalLightingColor(uint red, uint green, uint blue);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4F 20 E8 ?? ?? ?? ?? 44 0F B7 83")]
    public readonly partial void SetDirectionalLightingBrightness(byte brightness);

    [MemberFunction("E8 ?? ?? ?? ?? EB 5A 48 8D 4F 20")]
    public readonly partial void SetDirectionalLightingAngle(short vertical, short horizontal);

    [MemberFunction("E8 ?? ?? ?? ?? EB 17 48 8D 4F 20")]
    public readonly partial void SetCameraZoom(byte zoom);

    [MemberFunction("E8 ?? ?? ?? ?? 41 B5 01 49 63 46 48")]
    public readonly partial void SetBackground(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 BC 24 ?? ?? ?? ?? 84 DB")]
    public readonly partial void SetPose(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B7 93")]
    public readonly partial void SetPoseTimed(ushort id, float time);

    [MemberFunction("E8 ?? ?? ?? ?? 84 DB 0F 84 ?? ?? ?? ?? 48 63 87 ?? ?? ?? ?? 45 33 C9")]
    public readonly partial void SetExpression(byte id);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 45 F2")]
    public readonly partial nint ExportPortraitData(ExportedPortraitData* output);

    [MemberFunction("E8 ?? ?? ?? ?? 83 BE ?? ?? ?? ?? ?? 4C 8B B4 24 ?? ?? ?? ?? 74 2D")]
    public readonly partial nint ImportPortraitData(ExportedPortraitData* input);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 53 ?? 48 8B CF")]
    public readonly partial void ApplyCameraPositions(); // use this after manually setting camera positions

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 43 24 66 85 C0 75 05 0F 28 D6 EB 35 0F B7 D0 8B CA 8B C2 C1 E9 0A 81 E2 ?? ?? ?? ?? 83 E1 1F C1 E0 10 C1 E1 17 25 ?? ?? ?? ?? 81 C1 ?? ?? ?? ?? C1 E2 0D 0B C8 0B CA 89 4C 24 40")]
    public readonly partial void SetHeadDirection(float a2, float a3);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 4B ?? 48 8B CF 44 0F B6 43 ?? 0F B6 53 26 E8 ?? ?? ?? ?? 48 8B 4F 18 0F B6 43 29 F3 0F 10 35 ?? ?? ?? ?? 88 87 ?? ?? ?? ?? 48 85 C9 74 13 0F B6 C0 66 0F 6E C8 0F 5B C9 F3 0F 5E CE E8 ?? ?? ?? ?? 0F B7 43 2C 0F B7 53 2A 48 8B 4F 18 66 89 97 ?? ?? ?? ?? 66 89 87 ?? ?? ?? ?? 48 85 C9 74 17 98 66 0F 6E D0 0F BF C2 0F 5B D2 66 0F 6E C8 0F 5B C9 E8 ?? ?? ?? ?? 44 0F B6 4B ?? 48 8B CF 44 0F B6 43 ?? 0F B6 53 2E E8 ?? ?? ?? ?? 48 8B 4F 18 0F B6 43 31 88 87 ?? ?? ?? ?? 48 85 C9 74 13 0F B6 C0 66 0F 6E C8 0F 5B C9 F3 0F 5E CE E8 ?? ?? ?? ?? 0F B7 43 32 48 8B 5C 24")]
    public readonly partial void SetEyeDirection(float a2, float a3);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 48 8B 01")]
    public readonly partial void ResetEyeDirection();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? E9")]
    public readonly partial void ResetHeadDirection();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B DD BA ?? ?? ?? ?? 48 C1 E3 04 49 03 DE")]
    public readonly partial void ToggleCharacterVisibility(bool visible);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 45 92 C7 83")]
    public readonly partial void ToggleGearVisibility(bool hideVisor, bool hideWeapon, bool closeVisor);
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
