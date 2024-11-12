using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::ActionTimelineSequencer
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 48 89 AB"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct ActionTimelineSequencer {
    // starting from 0x10 is a 0x60-sized struct containing animation request info?! can be passed as a3 to PlayTimeline

    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray14<Pointer<Pointer<SchedulerTimeline>>> _schedulerTimelines; // technically incorrect, but it's really all we need

    [FieldOffset(0xE0), FixedSizeArray] internal FixedSizeArray14<ushort> _timelineIds; // The timeline active in each slot or 0 when none
    [FieldOffset(0x154), FixedSizeArray] internal FixedSizeArray14<float> _timelineSpeeds; // Speed for each slot

    [FieldOffset(0x1C8)] public Character.Character* Parent;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B BC 24 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ?? 49 8B 5B 40")]
    public partial void PlayTimeline(ushort actionTimelineId, void* a3 = null); // Determines which slot the timeline belongs in and then plays it on that slot

    [MemberFunction("83 FA 0E 73 22")]
    public partial void SetSlotSpeed(uint slot, float speed); // Sets the speed of the animation slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 47 08 0F 28 D0")]
    public partial float GetSlotSpeed(uint slot);

    [MemberFunction("E8 ?? ?? ?? ?? 66 83 F8 4D")]
    public partial ushort GetSlotTimeline(uint slot);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B7 C6 4D 8B CC")]
    public partial void SetSlotTimeline(uint slot, ushort actionTimelineId);

    /// <remarks>
    /// Slots:
    /// Base = 0,
    /// UpperBody = 1,
    /// Facial = 2,
    /// Add = 3,
    /// 4-6 unknown purpose
    /// Lips = 7,
    /// Parts1 = 8,
    /// Parts2 = 9,
    /// Parts3 = 10,
    /// Parts4 = 11,
    /// Overlay = 12
    /// </remarks>
    public SchedulerTimeline* GetSchedulerTimeline(uint slot) {
        var baseTimelineSlot = SchedulerTimelines[(int)slot].Value;
        return baseTimelineSlot == null ? null : baseTimelineSlot->Value;
    }
}
