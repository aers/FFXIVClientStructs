using FFXIVClientStructs.FFXIV.Common.Math;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::BannerModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct BannerModule {
    public static BannerModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetBannerModule();
    }

    [FieldOffset(0x48)] public BannerModuleData* Data;

    /// <summary>
    /// Create a new Banner entry.
    /// </summary>
    /// <returns>BannerModuleEntry* of the newly created Banner, or null if out of Ids.</returns>
    [MemberFunction("48 89 6C 24 ?? 56 48 83 EC 20 48 8B 71 48")]
    public partial BannerModuleEntry* CreateBanner();

    /// <summary>
    /// Delete a Banner by Id.
    /// </summary>
    /// <param name="bannerId">The BannerId of the Banner to delete.</param>
    /// <returns>bool if the deletion was successful or not.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0A F0 FF C3 48 FF C7 83 FB 6E 72 D6 48 8B 5C 24 ??")]
    public partial bool DeleteBanner(int bannerId);

    /// <summary>
    /// Get the next free BannerId.
    /// </summary>
    /// <returns>Data->NextId</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 6E 7D 58")]
    public partial int GetNextId();

    /// <summary>
    /// Get the Banner entry by Id.
    /// </summary>
    /// <param name="bannerId">The BannerId.</param>
    /// <returns>BannerModuleEntry*, or null if not found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 0F B6 80")]
    public partial BannerModuleEntry* GetBannerById(int bannerId);

    /// <summary>
    /// Get the Id of a Banner via the index of the Data.Entries array.
    /// </summary>
    /// <param name="bannerIndex">Index in Entries array.</param>
    /// <returns>BannerID, or -1 if not found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 49 8B CE 8B E8")]
    public partial int GetBannerIdByBannerIndex(int bannerIndex);
}

// created in BannerModule vf8
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3E60)]
public unsafe partial struct BannerModuleData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray110<BannerModuleEntry> _entries;
    [FieldOffset(0x3DE0), FixedSizeArray] internal FixedSizeArray110<byte> _bannerId2BannerIndex;
    [FieldOffset(0x3E4E)] public byte NextId;

    [FieldOffset(0x3E58)] public BannerModule* BannerModule;
}

// ctor "E8 ?? ?? ?? ?? 0F B6 84 3E"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct BannerModuleEntry {
    [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _bannerTimelineName;
    // [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray4<byte> _flags; // see "8B C2 4C 8B C9 99"
    [FieldOffset(0x44)] public HalfVector4 CameraPosition;
    [FieldOffset(0x4C)] public HalfVector4 CameraTarget;
    [FieldOffset(0x54)] public HalfVector2 HeadDirection;
    [FieldOffset(0x58)] public HalfVector2 EyeDirection;
    [FieldOffset(0x5C)] public short DirectionalLightingVerticalAngle;
    [FieldOffset(0x5E)] public short DirectionalLightingHorizontalAngle;
    [FieldOffset(0x60)] public byte Race; // CustomizeData[0]
    [FieldOffset(0x61)] public byte Sex; // CustomizeData[1]
    [FieldOffset(0x62)] public byte Height; // CustomizeData[3]
    [FieldOffset(0x63)] public byte Tribe; // CustomizeData[4]
    [FieldOffset(0x64)] public byte DirectionalLightingColorRed;
    [FieldOffset(0x65)] public byte DirectionalLightingColorGreen;
    [FieldOffset(0x66)] public byte DirectionalLightingColorBlue;
    [FieldOffset(0x67)] public byte AmbientLightingColorRed;
    [FieldOffset(0x68)] public byte AmbientLightingColorGreen;
    [FieldOffset(0x69)] public byte AmbientLightingColorBlue;
    [FieldOffset(0x6C)] public float AnimationProgress;
    [FieldOffset(0x70)] public uint BannerTimelineIcon;
    [FieldOffset(0x74)] public int LastUpdated; // unix timestamp
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

    [MemberFunction("0F B7 42 7C 4C 8B C1")]
    public partial bool EqualTo(BannerModuleEntry* other);

    /// <param name="itemIds">A pointer to 14 Item Ids</param>
    /// <param name="stainIds">A pointer to 28 Stain Ids</param>
    /// <param name="glassesIds">A pointer to 2 Glasses Ids</param>
    /// <param name="gearVisibilityFlag">Gear Visibility Flags</param>
    [MemberFunction("E8 ?? ?? ?? ?? 89 43 58 48 8B 4D F0")]
    public static partial uint GenerateChecksum(uint* itemIds, byte* stainIds, ushort* glassesIds, BannerGearVisibilityFlag gearVisibilityFlag);
}
