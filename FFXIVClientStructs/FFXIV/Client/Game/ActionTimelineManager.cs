namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct ActionTimelineManager {
    [FieldOffset(0x10)] public ActionTimelineDriver Driver;

    [FieldOffset(0x2C0)] public float OverallSpeed; // The overall speed which is applied to all slots as well as things like particles attached to the owner

    [FieldOffset(0x2DC)] public ushort BaseOverride; // Forces base animation when character is in a Normal or AnimLock state

    [FieldOffset(0x2DE)] public ushort LipsOverride; // Forces the character lips to play timeline

    [FieldOffset(0x310)] public ushort BannerTimelineRowId;
    [FieldOffset(0x312)] public byte BannerFacialRowId;

    // [FieldOffset(0x315)] public byte BannerFacialBannerCondition; // maybe?

    [FieldOffset(0x32C)] public uint BannerTimelineAdditionalData;
    [FieldOffset(0x330)] public uint BannerTimelineIcon;
    [FieldOffset(0x334)] public ushort BannerTimelineUnlockCondition;
    [FieldOffset(0x336)] public ushort BannerTimelineSortKey;
    [FieldOffset(0x338)] public byte BannerTimelineType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct ActionTimelineDriver {
    public const int TimelineSlotCount = 13;

    [FieldOffset(0xE0)] public unsafe fixed ushort TimelineIds[TimelineSlotCount]; // The timeline active in each slot or 0 when none

    [FieldOffset(0x154)] public unsafe fixed float TimelineSpeeds[TimelineSlotCount]; // Speed for each slot

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B BC 24 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ?? 49 8B 5B ??")]
    public partial void PlayTimeline(ushort actionTimelineId, void* a2 = null); // Determines which slot the timeline belongs in and then plays it on that slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B 08 48 81 C7")]
    public partial void SetSlotSpeed(uint slot, float speed); // Sets the speed of the animation slot
}

public enum ActionTimelineSlots : int {
    Base = 0,
    UpperBody = 1,
    Facial = 2,
    Add = 3,
    // 4-6 unknown purpose
    Lips = 7,
    Parts1 = 8,
    Parts2 = 9,
    Parts3 = 10,
    Parts4 = 11,
    Overlay = 12
}
