using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaViewPortrait
//   Client::UI::Misc::CharaView
[GenerateInterop]
[Inherits<CharaView>]
[StructLayout(LayoutKind.Explicit, Size = 0x430)]
public unsafe partial struct CharaViewPortrait {
    // Spherical Camera?
    [FieldOffset(0x320)] public Vector4 CameraPosition;
    [FieldOffset(0x330)] public Vector4 CameraTarget;
    [FieldOffset(0x340)] public float CameraYaw; // automatically calculated
    [FieldOffset(0x344)] public float CameraPitch; // automatically calculated
    [FieldOffset(0x348)] public float CameraDistance; // automatically calculated euclidean distance
    [FieldOffset(0x34C)] public short ImageRotation; // -90 to 90
    [FieldOffset(0x34E)] public byte CameraZoom; // 0 to 200

    [FieldOffset(0x350)] public float CameraZoomNormalized; // automatically calculated
    [FieldOffset(0x354)] public byte DirectionalLightingColorRed;
    [FieldOffset(0x355)] public byte DirectionalLightingColorGreen;
    [FieldOffset(0x356)] public byte DirectionalLightingColorBlue;
    [FieldOffset(0x357)] public byte DirectionalLightingBrightness;
    [FieldOffset(0x358)] public short DirectionalLightingVerticalAngle; // -180 to 180
    [FieldOffset(0x35A)] public short DirectionalLightingHorizontalAngle; // -180 to 180
    [FieldOffset(0x35C)] public byte AmbientLightingColorRed;
    [FieldOffset(0x35D)] public byte AmbientLightingColorGreen;
    [FieldOffset(0x35E)] public byte AmbientLightingColorBlue;
    [FieldOffset(0x35F)] public byte AmbientLightingBrightness;

    [FieldOffset(0x364)] public short PoseClassJob;
    [FieldOffset(0x366)] public short BannerBg;
    [FieldOffset(0x368)] public byte BackgroundState; // 0 = do nothing, 1 = loads texture by icon from row, 2 = renders KernelTexture?, 3 = done

    [FieldOffset(0x370)] public AtkTexture BackgroundTexture;

    [FieldOffset(0x388)] public CharaViewCharacterData PortraitCharacterData;
    [FieldOffset(0x404)] public bool CharacterVisible;
    [FieldOffset(0x405)] public bool CharaViewPortraitCharacterDataCopied;
    [FieldOffset(0x406)] public bool CharaViewPortraitCharacterLoaded;
    [FieldOffset(0x407)] public bool IsAnimationPauseStatePending;
    [FieldOffset(0x408)] public bool PendingAnimationPauseState;

    [FieldOffset(0x410)] public AgentInterface* EventAgent;
    [FieldOffset(0x418)] public int AgentEventId;
    [FieldOffset(0x420)] public ulong AgentEventKind;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7C 24 ?? EB ?? 33 F6")]
    public partial CharaViewPortrait* Ctor();

    /// <summary>
    /// Sets up the CharaViewPortrait.
    /// </summary>
    /// <param name="clientObjectId">The ClientObjectId to use.</param>
    /// <param name="characterData">The character data.</param>
    /// <param name="agent">An optional agent pointer.<br/>If set, vf8 will send an event with the given <paramref name="agentEventId"/> (as int in AtkValue[0]) containing a pointer to the CharaViewTexture (as int64 in AtkValue[1]).</param>
    /// <param name="agentEventId">An id passed as int in AtkValue[0] of the event.</param>
    /// <param name="agentEventKind">The eventKind parameter passed to agent->ReceiveEvent.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 10 C6 80 ?? ?? ?? ?? ?? 48 8B 4B 10")]
    public partial void Setup(uint clientObjectId, CharaViewCharacterData* characterData, AgentInterface* agent, int agentEventId, ulong agentEventKind);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 89 B3 ?? ?? ?? ?? 48 8B 8C 24")]
    public partial void ResetCamera(); // sets position, target, zoom etc.

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 47 10 41 B9")]
    public partial void SetCameraPosition(HalfVector4* cam, HalfVector4* target);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 97 ?? ?? ?? ?? 0F 28 D0")]
    public partial float GetAnimationTime();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 96 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? BB")]
    public partial void SetAmbientLightingColor(uint red, uint green, uint blue);

    [MemberFunction("E8 ?? ?? ?? ?? BB ?? ?? ?? ?? 48 8D 45 ?? 8B D3 33 C9 0F 1F 44 00")]
    public partial void SetAmbientLightingBrightness(byte brightness);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B 18 0F B6 47 29 F3 0F 10 35 ?? ?? ?? ?? 48 8B 74 24 ??")]
    public partial void SetDirectionalLightingColor(uint red, uint green, uint blue);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 86 ?? ?? ?? ?? 0F B7 96 ?? ?? ?? ?? 48 8B 8E")]
    public partial void SetDirectionalLightingBrightness(byte brightness);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8D 4E ?? E8 ?? ?? ?? ?? 0F B7 97")]
    public partial void SetDirectionalLightingAngle(short vertical, short horizontal);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 89 5C 24 ?? 48 8D 4E")]
    public partial void SetCameraZoom(byte zoom);

    [MemberFunction("E8 ?? ?? ?? ?? 41 B7 01 48 63 47 48")]
    public partial void SetBackground(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 FF 74 ?? 48 63 83")]
    public partial void SetPose(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 74 ?? 48 63 83")]
    public partial void SetPoseTimed(ushort id, float time);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 F6 74 4F 48 63 83 ?? ?? ?? ??")]
    public partial void SetExpression(byte id);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 45 ?? F3 0F 10 45")]
    public partial void ExportPortraitData(ExportedPortraitData* output);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B DE BA")]
    public partial void ImportPortraitData(ExportedPortraitData* input);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 57 ?? 48 8B CB")]
    public partial void ApplyCameraPositions(); // use this after manually setting camera positions

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 4F 24 E8 ?? ?? ?? ?? 0F B7 4F 22 0F 28 F0 E8 ?? ?? ?? ?? 0F 28 C8 0F 28 D6 48 8B CB E8 ?? ?? ?? ?? 44 0F B6 4F ?? 48 8B CB 44 0F B6 47 ?? 0F B6 57 26 E8 ?? ?? ?? ?? 48 8B 4B 18 0F B6 47 29 F3 0F 10 35 ?? ?? ?? ?? 48 8B 74 24 ??")]
    public partial void SetHeadDirection(float a2, float a3);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 4F ?? 48 8B CB 44 0F B6 47 ?? 0F B6 57 26 E8 ?? ?? ?? ?? 48 8B 4B 18 0F B6 47 29 F3 0F 10 35 ?? ?? ?? ?? 48 8B 74 24 ??")]
    public partial void SetEyeDirection(float a2, float a3);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? ?? ?? ?? FF 90 ?? ?? ?? ?? 48 8B 48")]
    public partial void ResetEyeDirection();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? E9")]
    public partial void ResetHeadDirection();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B DF BA ?? ?? ?? ??")]
    public partial void ToggleCharacterVisibility(bool visible);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 45 A4")]
    public partial void ToggleGearVisibility(bool hideVisor, bool hideWeapon, bool closeVisor, bool hideVieraEars);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4F 10 88 85")]
    public partial bool IsAnimationPaused();

    [MemberFunction("E8 ?? ?? ?? ?? B2 ?? 48 8B CE E8 ?? ?? ?? ?? 32 C0")]
    public partial void ToggleAnimationPlayback(bool paused);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 A8 ?? 74 ?? 49 8B 4C 24")]
    public partial PortraitError GetPortraitError();

    [Flags]
    public enum PortraitError {
        None = 0,

        /// <remarks> LogMessage#5861: "Unable to save portrait. Character's expression is not in frame." </remarks>
        ExpressionNotInFrame = 1 << 0,

        /// <remarks> LogMessage#5871: "Unable to save. The camera is too close to the character." </remarks>
        CameraTooClose = 1 << 1,

        /// <remarks> LogMessage#5872: "Unable to save. The  is too far from the character." </remarks>
        CameraTooFar = 1 << 2,

        /// <remarks> LogMessage#5850: "Unable to save portrait. Character is not in frame." </remarks>
        CharacterNotInFrame = 1 << 3,

        /// <remarks> LogMessage#5882: "Unable to save portrait. A weapon or accessory is interfering with the camera." </remarks>
        Obstructed = 1 << 4,
    }
}
