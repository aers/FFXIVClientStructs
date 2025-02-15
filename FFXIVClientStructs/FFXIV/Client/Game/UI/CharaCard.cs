using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::CharaCard
[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public struct CharaCard {
    [FieldOffset(0x000)] public BannerData TempBannerData; // used temporarily when sending the packet
    [FieldOffset(0x034)] public BannerData CurrentBannerData;
    [FieldOffset(0x068)] public CharaCardData TempCharaCardData;
    [FieldOffset(0x124)] public CharaCardData CurrentCharaCardData;
    [FieldOffset(0x1E0)] public CharaCardFlags Flags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public struct BannerData {
    [FieldOffset(0x00)] public byte HasData;
    [FieldOffset(0x01)] public byte Expression;
    [FieldOffset(0x02)] public byte CameraZoom;
    [FieldOffset(0x03)] public byte DirectionalLightingColorRed;
    [FieldOffset(0x04)] public byte DirectionalLightingColorGreen;
    [FieldOffset(0x05)] public byte DirectionalLightingColorBlue;
    [FieldOffset(0x06)] public byte DirectionalLightingBrightness;
    [FieldOffset(0x07)] public byte AmbientLightingColorRed;
    [FieldOffset(0x08)] public byte AmbientLightingColorGreen;
    [FieldOffset(0x09)] public byte AmbientLightingColorBlue;
    [FieldOffset(0x0A)] public byte AmbientLightingBrightness;
    [FieldOffset(0x0B)] public byte Flags;
    [FieldOffset(0x0C)] public ushort BannerTimeline;
    [FieldOffset(0x0E)] public ushort AnimationProgress;
    [FieldOffset(0x10)] public ushort HeadDirectionY;
    [FieldOffset(0x12)] public ushort HeadDirectionX;
    [FieldOffset(0x14)] public ushort EyeDirectionY;
    [FieldOffset(0x16)] public ushort EyeDirectionX;
    [FieldOffset(0x18)] public ushort CameraPositionX;
    [FieldOffset(0x1A)] public ushort CameraPositionY;
    [FieldOffset(0x1C)] public ushort CameraPositionZ;
    [FieldOffset(0x1E)] public ushort CameraTargetX;
    [FieldOffset(0x20)] public ushort CameraTargetY;
    [FieldOffset(0x22)] public ushort CameraTargetZ;
    [FieldOffset(0x24)] public ushort ImageRotation;
    [FieldOffset(0x26)] public ushort DirectionalLightingVerticalAngle;
    [FieldOffset(0x28)] public ushort DirectionalLightingHorizontalAngle;
    [FieldOffset(0x2A)] public ushort BannerDecoration;
    [FieldOffset(0x2C)] public ushort BannerBg;
    [FieldOffset(0x2E)] public ushort BannerFrame;
    [FieldOffset(0x30)] public uint Checksum;
}

[StructLayout(LayoutKind.Explicit, Size = 0xBC)]
public partial struct CharaCardData {
    [FieldOffset(0x00)] public Data8Struct Data8;
    [FieldOffset(0x52)] public Data16Struct Data16;
    [FieldOffset(0x88)] public Data32Struct Data32;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x52)]
    public partial struct Data8Struct {
        [FieldOffset(0x00), CExportIgnore, FixedSizeArray] internal FixedSizeArray82<byte> _data;

        [FieldOffset(0x00)] public byte Version;
        [FieldOffset(0x01)] public byte Expression;
        [FieldOffset(0x02)] public byte CameraZoom;
        [FieldOffset(0x03)] public byte DirectionalLightingColorRed;
        [FieldOffset(0x04)] public byte DirectionalLightingColorGreen;
        [FieldOffset(0x05)] public byte DirectionalLightingColorBlue;
        [FieldOffset(0x06)] public byte DirectionalLightingBrightness;
        [FieldOffset(0x07)] public byte AmbientLightingColorRed;
        [FieldOffset(0x08)] public byte AmbientLightingColorGreen;
        [FieldOffset(0x09)] public byte AmbientLightingColorBlue;
        [FieldOffset(0x0A)] public byte AmbientLightingBrightness;
        [FieldOffset(0x0B)] public byte ClassJobId;
        [FieldOffset(0x0C)] public CustomizeData CustomizeData;
        [FieldOffset(0x26), FixedSizeArray] internal FixedSizeArray12<byte> _itemStain0Ids;
        [FieldOffset(0x32)] public byte GearVisibilityFlag;
        [FieldOffset(0x33)] public byte TopBorder;
        [FieldOffset(0x34)] public byte BottomBorder;
        [FieldOffset(0x35)] public byte PreferredClassJobId;
        [FieldOffset(0x36), FixedSizeArray] internal FixedSizeArray3<byte> _activeHoursWeekdays;
        [FieldOffset(0x39), FixedSizeArray] internal FixedSizeArray3<byte> _activeHoursWeekends;
        [FieldOffset(0x3C), FixedSizeArray] internal FixedSizeArray6<byte> _playStyles;
        [FieldOffset(0x42)] public byte Flags; // &1 == WasResetDueToFantasia; &2 == Visible to No One
        [FieldOffset(0x43)] public byte Unk43;
        [FieldOffset(0x44)] public byte PrivacyFlags; // &1 == Friends Only
        [FieldOffset(0x45), FixedSizeArray] internal FixedSizeArray12<byte> _itemStain1Ids;
        [FieldOffset(0x51)] public byte Unk51;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x36)]
    public partial struct Data16Struct {
        [FieldOffset(0x00), CExportIgnore, FixedSizeArray] internal FixedSizeArray27<ushort> _data;

        [FieldOffset(0x00)] public ushort BannerTimeline;
        [FieldOffset(0x02)] public ushort AnimationProgress;
        [FieldOffset(0x04)] public ushort HeadDirectionY;
        [FieldOffset(0x06)] public ushort HeadDirectionX;
        [FieldOffset(0x08)] public ushort EyeDirectionY;
        [FieldOffset(0x0A)] public ushort EyeDirectionX;
        [FieldOffset(0x0C)] public ushort CameraPositionX;
        [FieldOffset(0x0E)] public ushort CameraPositionY;
        [FieldOffset(0x10)] public ushort CameraPositionZ;
        [FieldOffset(0x12)] public ushort CameraTargetX;
        [FieldOffset(0x14)] public ushort CameraTargetY;
        [FieldOffset(0x16)] public ushort CameraTargetZ;
        [FieldOffset(0x18)] public ushort ImageRotation;
        [FieldOffset(0x1A)] public ushort DirectionalLightingVerticalAngle;
        [FieldOffset(0x1C)] public ushort DirectionalLightingHorizontalAngle;
        [FieldOffset(0x1E)] public ushort BannerDecoration;
        [FieldOffset(0x20)] public ushort BannerBg;
        [FieldOffset(0x22)] public ushort BannerFrame;
        [FieldOffset(0x24)] public ushort TitleId;
        [FieldOffset(0x26)] public ushort BasePlate;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray5<ushort> _decorations;
        [FieldOffset(0x32), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x34)]
    public partial struct Data32Struct {
        [FieldOffset(0x00), CExportIgnore, FixedSizeArray] internal FixedSizeArray13<uint> _data;

        [FieldOffset(0x00)] public uint Timestamp; // what for?
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray12<uint> _itemIds;
    }
}

[Flags]
public enum CharaCardFlags {
    None = 0,
    HasCurrentBannerData = 1,
    HasCurrentCharaCardData = 2,
    HasCurrentCharaCardDataTimestamp = 4,
}
