using System.Text;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::CharaCard
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public unsafe partial struct CharaCard {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? C6 40 ?? ?? E8 ?? ?? ?? ?? C6 43", 3)]
    public static partial CharaCard* Instance();

    [FieldOffset(0x000)] public BannerData TempBannerData; // used temporarily when sending the packet
    [FieldOffset(0x034)] public BannerData CurrentBannerData;
    [FieldOffset(0x068)] public CharaCardData TempCharaCardData;
    [FieldOffset(0x124)] public CharaCardData CurrentCharaCardData;
    [FieldOffset(0x1E0)] public CharaCardFlags Flags;

    [MemberFunction("40 53 48 81 EC 80 0F 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 70 0F 00 00 48 8B 0D ?? ?? ?? ?? 48 8B DA E8 ?? ?? ?? ?? 45 33 C9 C7 44 24 20 5E 03 00 00 45 33 C0 48 C7 44 24 28 20 00 00 00 48 8D 54 24 20 48 89 5C 24 40 48 8B C8 C7 44 24 48 01 00 00 00")]
    public partial void RequestCharaCardForContentId(ulong contentId);

    [MemberFunction("40 53 48 81 EC 80 0F 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 70 0F 00 00 48 8B 0D ?? ?? ?? ?? 48 8B DA E8 ?? ?? ?? ?? 8B 4B 78 48 8D 54 24 20 48 89 4C 24 40 45 33 C9 48 8B C8 C7 44 24 20 5E 03 00 00 45 33 C0 48 C7 44 24 28 20 00 00 00 C7 44 24 48 01 00 00 00")]
    public partial void RequestCharaCardForGameObject(GameObject* gameObject);

    [MemberFunction("48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 8B 0D")]
    public partial void RequestCharaCardUpdate();

    [MemberFunction("40 53 48 83 EC ?? 8B 05 ?? ?? ?? ?? 48 8B DA")]
    public partial void HandleCurrentCharaCardDataPacket(AgentCharaCard.CharaCardPacket* packet);
}

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public struct BannerData {
    [FieldOffset(0x00)] public bool HasData;
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
        [FieldOffset(0x00), CExporterIgnore, FixedSizeArray] internal FixedSizeArray82<byte> _data;

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
        [FieldOffset(0x43)] private byte Unk43;
        [FieldOffset(0x44)] public byte PrivacyFlags; // &1 == Friends Only
        [FieldOffset(0x45), FixedSizeArray] internal FixedSizeArray12<byte> _itemStain1Ids;
        [FieldOffset(0x51)] private byte Unk51;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x36)]
    public partial struct Data16Struct {
        [FieldOffset(0x00), CExporterIgnore, FixedSizeArray] internal FixedSizeArray27<ushort> _data;

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
        [FieldOffset(0x00), CExporterIgnore, FixedSizeArray] internal FixedSizeArray13<uint> _data;

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
