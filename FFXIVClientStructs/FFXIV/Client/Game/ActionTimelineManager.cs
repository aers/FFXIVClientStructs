using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::System::Scheduler::ActionTimelineManager
// ctor "E8 ?? ?? ?? ?? 48 8B C8 48 89 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 05"
// TODO: move into correct namespace
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct ActionTimelineManager {
    [FieldOffset(0x08)] public Character.Character* Parent;

    [FieldOffset(0x10)] public ActionTimelineDriver Driver;

    [FieldOffset(0x2C4)] public float OverallSpeed; // The overall speed which is applied to all slots as well as things like particles attached to the owner

    [FieldOffset(0x2E0)] public ushort BaseOverride; // Forces base animation when character is in a Normal or AnimLock state

    [FieldOffset(0x2E2)] public ushort LipsOverride; // Forces the character lips to play timeline

    [FieldOffset(0x310)] public ushort BannerTimelineRowId;
    [FieldOffset(0x312)] public byte BannerFacialRowId;

    // [FieldOffset(0x315)] public byte BannerFacialBannerCondition; // maybe?

    [FieldOffset(0x32C)] public uint BannerTimelineAdditionalData;
    [FieldOffset(0x330)] public uint BannerTimelineIcon;
    [FieldOffset(0x334)] public ushort BannerTimelineUnlockCondition;
    [FieldOffset(0x336)] public ushort BannerTimelineSortKey;
    [FieldOffset(0x338)] public byte BannerTimelineType;

    /// <summary> Computes height difference between the player the action timeline belongs to and target to height adjust emotes. </summary>
    /// <param name="target"> The object id of the target of the emote. </param>
    /// <param name="emoteId"> The row id of the executed emote. </param>
    /// <returns> Returns 0 or one of the row ids for height adjustment for emotes (like kneeling to hug small objects). </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 F8 45 85 FF")]
    public partial uint GetHeightAdjustActionTimelineRowId(GameObjectID target, int emoteId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 D6 41 8B D7")]
    public partial void SetSlotSpeed(uint slot, float speed); // Sets the speed of the animation slot on the target actor and any children (mounts, ornaments)

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C7 ?? 48 83 EE ?? 75 ?? 48 8B 74 24 ?? 48 8B 6C 24")]
    public partial void SetLipsOverrideTimeline(ushort actionTimelineId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 80 8E ?? ?? ?? ?? ?? 48 8D 8B")]
    public partial bool CalculateAndApplyOverallSpeed(); // Calculates the current overall speed and applies it, returns true if the speed changed
}

[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct ActionTimelineDriver {
    public const int TimelineSlotCount = 13;

    [FieldOffset(0xE0)] public unsafe fixed ushort TimelineIds[TimelineSlotCount]; // The timeline active in each slot or 0 when none

    [FieldOffset(0x154)] public unsafe fixed float TimelineSpeeds[TimelineSlotCount]; // Speed for each slot

    [FieldOffset(0x1C8)] public Character.Character* Parent;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B BC 24 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ?? 49 8B 5B ??")]
    public partial void PlayTimeline(ushort actionTimelineId, void* a2 = null); // Determines which slot the timeline belongs in and then plays it on that slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B 08 48 81 C7")]
    public partial void SetSlotSpeed(uint slot, float speed); // Sets the speed of the animation slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 46 ?? 0F 28 D0")]
    public partial float GetSlotSpeed(uint slot);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 F8 8D 8F")]
    public partial ushort GetSlotTimeline(uint slot);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B7 C6 4D 8B CC")]
    public partial void SetSlotTimeline(uint slot, ushort actionTimelineId);
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
