using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ActionTimelineDriver
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 C7 83 ?? ?? ?? ?? ?? ?? ?? ?? B8"
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct ActionTimelineDriver {
    public const int TimelineSlotCount = 14;

    // starting from 0x10 is a 0x60-sized struct containing animation request info?! can be passed as a3 to PlayTimeline

    [FixedSizeArray<Pointer<Pointer<SchedulerTimeline>>>(TimelineSlotCount)] // technically incorrect, but it's really all we need
    [FieldOffset(0x70)] public unsafe fixed byte SchedulerTimelines[TimelineSlotCount * 0x8];
    [FieldOffset(0xE0)] public unsafe fixed ushort TimelineIds[TimelineSlotCount]; // The timeline active in each slot or 0 when none

    [FieldOffset(0x154)] public unsafe fixed float TimelineSpeeds[TimelineSlotCount]; // Speed for each slot

    [FieldOffset(0x1C8)] public Character.Character* Parent;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B BC 24 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ?? 49 8B 5B ??")]
    public partial void PlayTimeline(ushort actionTimelineId, void* a3 = null); // Determines which slot the timeline belongs in and then plays it on that slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B 08 48 81 C7")]
    public partial void SetSlotSpeed(uint slot, float speed); // Sets the speed of the animation slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 46 ?? 0F 28 D0")]
    public partial float GetSlotSpeed(uint slot);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 F8 8D 8F")]
    public partial ushort GetSlotTimeline(uint slot);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B7 C6 4D 8B CC")]
    public partial void SetSlotTimeline(uint slot, ushort actionTimelineId);

    public SchedulerTimeline* GetSchedulerTimeline(uint slot) {
        var baseTimelineSlot = SchedulerTimelinesSpan[(int)slot].Value;
        return baseTimelineSlot == null ? null : baseTimelineSlot->Value;
    }
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
