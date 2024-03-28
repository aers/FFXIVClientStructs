using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::BannerModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7"
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct BannerModule {
    public static BannerModule* Instance() => Framework.Instance()->GetUiModule()->GetBannerModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FieldOffset(0x40)] public BannerModuleData* Data;

    /// <summary>
    /// Create a new Banner entry.
    /// </summary>
    /// <returns>BannerModuleEntry* of the newly created Banner, or null if out of Ids.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 47 41 8B D6")]
    public partial BannerModuleEntry* CreateBanner();

    /// <summary>
    /// Delete a Banner by Id.
    /// </summary>
    /// <param name="bannerId">The BannerId of the Banner to delete.</param>
    /// <returns>bool if the deletion was successful or not.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 40 0A F0 FF C3 48 FF C7 83 FB 6E 72 D6 40 0F B6 C6 48 8B 8C 24 ?? ?? ?? ?? 48 33 CC E8 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ?? 49 8B 5B 18 49 8B 6B 20 49 8B 73 28 49 8B E3 5F C3 CC CC")]
    public partial bool DeleteBanner(int bannerId);

    /// <summary>
    /// Get the next free BannerId.
    /// </summary>
    /// <returns>Data->NextId</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 6E 7C 15")]
    public partial byte GetNextId();

    /// <summary>
    /// Get the Banner entry by Id.
    /// </summary>
    /// <param name="bannerId">The BannerId.</param>
    /// <returns>BannerModuleEntry*, or null if not found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 40 7E")]
    public partial BannerModuleEntry* GetBannerById(int bannerId);

    /// <summary>
    /// Get the Id of a Banner via the index of the Data.Entries array.
    /// </summary>
    /// <param name="bannerIndex">Index in Entries array.</param>
    /// <returns>BannerID, or -1 if not found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 79 0C")]
    public partial int GetBannerIdByBannerIndex(int bannerIndex);
}

// ctor "E8 ?? ?? ?? ?? 48 89 43 40 48 8B 4B 40 48 85 C9 74 0A"
[StructLayout(LayoutKind.Explicit, Size = 0x3E60)]
public unsafe partial struct BannerModuleData {
    [FixedSizeArray<BannerModuleEntry>(110)]
    [FieldOffset(0x00)] public fixed byte Entries[0x90 * 110];
    [FieldOffset(0x3DE0)] public fixed byte BannerId2BannerIndex[110];
    [FieldOffset(0x3E4E)] public byte NextId;

    [FieldOffset(0x3E58)] public BannerModule* BannerModule;

    [MemberFunction("40 56 48 83 EC 20 80 B9 ?? ?? ?? ?? ?? 48 8B F1 7C 08")]
    public partial BannerModuleEntry* CreateBanner();

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 63 FA 48 8B D9 85 D2 0F 88")]
    public partial bool DeleteBanner(int bannerIndex);
}

// ctor "E8 ?? ?? ?? ?? 0F B6 84 3E"
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct BannerModuleEntry {
    [FieldOffset(0x00)] public fixed byte BannerTimelineName[0x40];
    // [FieldOffset(0x40)] public fixed byte Flags[4]; // see "8B C2 4C 8B C9 99"
    [FieldOffset(0x44)] public HalfVector4 CameraPosition;
    [FieldOffset(0x4C)] public HalfVector4 CameraTarget;
    [FieldOffset(0x54)] public HalfVector2 HeadDirection;
    [FieldOffset(0x58)] public HalfVector2 EyeDirection;
    [FieldOffset(0x5C)] public short DirectionalLightingVerticalAngle;
    [FieldOffset(0x5E)] public short DirectionalLightingHorizontalAngle;
    [FieldOffset(0x60)] public byte Race; // CustomizeData[0]
    [FieldOffset(0x61)] public byte Sex; // CustomizeData[1]
    [Obsolete("Renamed to Sex")]
    [FieldOffset(0x61)] public byte Gender; // CustomizeData[1]
    [FieldOffset(0x62)] public byte Height; // CustomizeData[3]
    [FieldOffset(0x63)] public byte Tribe; // CustomizeData[4]
    [FieldOffset(0x64)] public byte DirectionalLightingColorRed;
    [FieldOffset(0x65)] public byte DirectionalLightingColorGreen;
    [FieldOffset(0x66)] public byte DirectionalLightingColorBlue;
    [FieldOffset(0x67)] public byte AmbientLightingColorRed;
    [FieldOffset(0x68)] public byte AmbientLightingColorGreen;
    [FieldOffset(0x69)] public byte AmbientLightingColorBlue;
    // [FieldOffset(0x6A)] public byte Unk6A;
    // [FieldOffset(0x6B)] public byte Unk6B;
    [FieldOffset(0x6C)] public float AnimationProgress;
    [FieldOffset(0x70)] public uint BannerTimelineIcon;
    [FieldOffset(0x74)] public uint LastUpdated; // unix timestamp
    [FieldOffset(0x78)] public uint Checksum; // see GenerateChecksum
    [FieldOffset(0x7C)] public ushort BannerBg;
    [FieldOffset(0x7E)] public ushort BannerFrame;
    [FieldOffset(0x80)] public ushort BannerDecoration;
    [FieldOffset(0x82)] public ushort BannerTimeline;
    [FieldOffset(0x84)] public short ImageRotation;
    [FieldOffset(0x86)] public byte BannerIndex;
    [FieldOffset(0x87)] public byte BannerId;
    [FieldOffset(0x88)] public byte BannerTimelineClassJobCategory;
    [FieldOffset(0x89)] public byte Expression;
    [FieldOffset(0x8A)] public byte CameraZoom;
    [FieldOffset(0x8B)] public byte DirectionalLightingBrightness;
    [FieldOffset(0x8C)] public byte AmbientLightingBrightness;
    [FieldOffset(0x8D)] public byte HasBannerTimelineCustomName;
    // [FieldOffset(0x8E)] public byte Unk8E;
    // [FieldOffset(0x8F)] public byte Unk8F;

    [MemberFunction("0F B7 42 7C 66 39 41 7C")]
    public partial bool Equals(BannerModuleEntry* other);

    /// <param name="itemIds">A pointer to 14 Item Ids</param>
    /// <param name="stainIds">A pointer to 14 Stain Ids</param>
    /// <param name="gearVisibilityFlag">Gear Visibility Flags</param>
    [MemberFunction("E8 ?? ?? ?? ?? 89 43 48 48 83 C4 20")]
    public static partial uint GenerateChecksum(uint* itemIds, byte* stainIds, BannerGearVisibilityFlag gearVisibilityFlag);
}

[Flags]
public enum BannerGearVisibilityFlag : uint {
    None = 0,
    HeadgearHidden = 1 << 0,
    WeaponHidden = 1 << 1,
    VisorClosed = 1 << 2,
}
