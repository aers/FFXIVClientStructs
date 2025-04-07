using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaViewPortrait
//   Client::UI::Misc::CharaView
// ctor "E8 ?? ?? ?? ?? 48 8B F8 45 33 C0"
[GenerateInterop]
[Inherits<CharaView>]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
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
    [FieldOffset(0x400)] public bool CharacterVisible;
    [FieldOffset(0x401)] public bool CharaViewPortraitCharacterDataCopied;
    [FieldOffset(0x402)] public bool CharaViewPortraitCharacterLoaded;
    [FieldOffset(0x403)] public bool IsAnimationPauseStatePending;
    [FieldOffset(0x404)] public bool PendingAnimationPauseState;

    [FieldOffset(0x408)] public AgentInterface* EventAgent;
    [FieldOffset(0x410)] public int AgentEventId;
    [FieldOffset(0x418)] public ulong AgentEventKind;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 45 33 C0")]
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

    [MemberFunction("E8 ?? ?? ?? ?? EB 89 48 8B 8F")]
    public partial void ResetCamera(); // sets position, target, zoom etc.

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 47 10 41 B9")]
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

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4F 10 88 85")]
    public partial bool IsAnimationPaused();

    [MemberFunction("E8 ?? ?? ?? ?? B2 01 48 8B CF E8 ?? ?? ?? ?? 32 C0")]
    public partial void ToggleAnimationPlayback(bool paused);
}
