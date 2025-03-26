using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
[Inherits<HelperInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct BannerHelper {
    [FieldOffset(0x10)] public DefaultBannerPreset DefaultBannerPreset;
    [FieldOffset(0x48)] public bool IsDefaultPresetLoaded;
    [FieldOffset(0x49)] public bool IsPortraitClientObjectSetUp; // For CharaViewPortrait, ClientObject 248, EventNpc 1023070
    /// <remarks> True when EditingPortrait condition is set while editing/viewing local Banners. </remarks>
    [FieldOffset(0x4A)] public bool IsEditingBanner; // 
    /// <remarks> True when EditingPortrait condition is set while editing/viewing local CharaCard. </remarks>
    [FieldOffset(0x4B)] public bool IsEditingCharaCard;

    #region CharaView Helpers

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 41 0F B7 40")]
    public partial void ExportedPortraitData_ApplyBannerModuleEntry(ExportedPortraitData* to, BannerModuleEntry* from);

    [MemberFunction("E8 ?? ?? ?? ?? F6 45 72 01")]
    public partial void CharaViewCharacterData_ApplyCharaCardData(CharaViewCharacterData* to, CharaCardData* from);

    #endregion

    #region BannerData Helpers

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 75 28 49 8B 8E")]
    public partial void RequestCurrentBannerData();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 49 8B 4F 28 4C 89 6C 24")]
    public partial bool HasCurrentBannerData();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 55 B0 48 8B CF E8 ?? ?? ?? ?? 48 8B BC 24")]
    public partial void BannerData_ApplyBannerModuleEntry(BannerData* to, BannerModuleEntry* from);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B AC 24 ?? ?? ?? ?? 48 8B 4C 24 ?? 48 33 CC E8 ?? ?? ?? ?? 48 83 C4 60")]
    public partial bool SendBannerData(BannerData* bannerData);

    #endregion

    #region CharaCardData Helpers

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 6E 28")]
    public partial void RequestCurrentCharaCard();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 17 48 8B 4F 28")]
    public partial bool HasCurrentCharaCard();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 4C 48 8D 54 24")]
    public partial bool HasCharaCardCreated();

    [MemberFunction("C6 02 03 41 0F B7 41")]
    public partial void CharaCardData_ApplyCharaViewCharacterDataAndBannerModuleEntry(CharaCardData* to, CharaViewCharacterData* from1, BannerModuleEntry* from2);

    [MemberFunction("48 89 5C 24 ?? 41 80 78")]
    public partial void CharaCardData_ApplyCharaViewCharacterData(CharaCardData* to, CharaViewCharacterData* from);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4B 28 41 B8")]
    public partial bool SendCharaCardData(CharaCardData* charaCardData, CharaCardDataChangeReason reason);

    #endregion

    #region BannerGearData Helpers

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 43 54")]
    public partial void BannerGearData_ApplyClassJobIdAndGearVisibilityFromGearset(BannerGearData* bannerGearData);

    [MemberFunction("40 53 48 83 EC 40 0F B6 42 63")]
    public partial bool BannerGearData_ApplyGearFromGearset(BannerGearData* bannerGearData);

    [MemberFunction("E8 ?? ?? ?? ?? FE C3 41 3A DE")]
    public partial void BannerGearData_UpdateGearsetChecksum(BannerGearData* bannerGearData);

    #endregion

    #region BannerModuleEntry Helpers

    [MemberFunction("41 0F B7 40 ?? 4C 8B D2")]
    public partial void BannerModuleEntry_ApplyDefaultBannerPreset(BannerModuleEntry* to, DefaultBannerPreset* from);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4B 64 48 8D 54 24")]
    public partial void BannerModuleEntry_ApplyBannerData(BannerModuleEntry* to, BannerData* from);

    [MemberFunction("E8 ?? ?? ?? ?? EB 12 4D 8B C6")]
    public partial void BannerModuleEntry_ApplyCharaCardData(BannerModuleEntry* to, CharaCardData* from);

    [MemberFunction("41 0F B6 80 ?? ?? ?? ?? 88 42 60")]
    public partial void BannerModuleEntry_ApplyRaceGenderHeightTribe(BannerModuleEntry* bannerModuleEntry, Character* character);

    [MemberFunction("E8 ?? ?? ?? ?? 88 44 24 22 40 84 ED")]
    public partial bool BannerModuleEntry_IsCurrentCharaCardBannerOutdated(BannerModuleEntry* bannerModuleEntry, bool logError); // not exactly sure

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1D 4C 8D 44 24")]
    public partial bool BannerModuleEntry_IsCharacterDataOutdated(BannerModuleEntry* bannerModuleEntry, bool logError);

    #endregion
}

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public partial struct ExportedPortraitData {
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

[GenerateInterop]
[Inherits<ExportedPortraitData>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public partial struct DefaultBannerPreset {
    [FieldOffset(0x34)] public ushort BannerFrame;
    [FieldOffset(0x36)] public ushort BannerDecoration;
}

[StructLayout(LayoutKind.Explicit, Size = 0x64)]
public struct BannerGearData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray14<uint> _itemIds;
    [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray14<byte> _stain0Ids;
    [FieldOffset(0x46), FixedSizeArray] internal FixedSizeArray14<byte> _stain1Ids;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    [FieldOffset(0x58)] public uint Checksum;
    [FieldOffset(0x5C)] public BannerGearVisibilityFlag GearVisibilityFlag;
    [FieldOffset(0x60)] public byte EnabledGearsetIndex;
    [FieldOffset(0x61)] public byte ClassJobId;
}

[Flags]
public enum BannerGearVisibilityFlag : uint {
    None = 0,
    HeadgearHidden = 1 << 0,
    WeaponHidden = 1 << 1,
    VisorClosed = 1 << 2,
}

public enum CharaCardDataChangeReason {
    Banner = 1,
    Design = 2,
    Profile = 3,
    Permissions = 4,
    SearchComment = 5, // Only when plate wasn't created yet?!
}
