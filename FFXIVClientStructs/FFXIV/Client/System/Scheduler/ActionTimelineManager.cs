namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler;

// Client::System::Scheduler::ActionTimelineManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ActionTimelineManager {
    [StaticAddress("4C 8B 43 48 48 8B 0D ?? ?? ?? ??", 7, isPointer: true)]
    public static partial ActionTimelineManager* Instance();

    // [FieldOffset(0x18)] public TimelineGroup* Timeline1;
    // [FieldOffset(0x20)] public TimelineGroup* LayoutTimelines;
    // [FieldOffset(0x28)] public TimelineGroup* Timeline3;
    // [FieldOffset(0x30)] public TimelineGroup* WeaponTimelines;
    // [FieldOffset(0x38)] public TimelineGroup* CharaTimelines;
    // [FieldOffset(0x40)] public ActionTimelineThread* Thread; 
    // [FieldOffset(0x50)] public TimelineGroup* TimelineGroup1;
    // [FieldOffset(0x58)] public TimelineGroup* TimelineGroup2;
    // [FieldOffset(0x60)] public TimelineGroup* TimelineGroup3;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D7 48 8B D8")]
    public partial TimelineGroup* InsertTimelineGroup(int index);
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8D 4B 30 E8 ?? ?? ?? ?? 48 8B 4D 68")]
    public partial SchedulerInstanceObject** AddLayoutTimelineObject(SchedulerInstanceObject** obj, void* unknown1, void* unknown2);

    [MemberFunction("48 83 EC 38 48 8B 02 C7 44 24")]
    public partial bool PreloadActionTmb(PreloadActionTmbInfo* info);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct PreloadActionTmbInfo {
        [FieldOffset(0x00)] public CStringPointer Key;

        // ActionTimeline Row Index
        // or
        // WeaponTimeline Row Index + 0x20000
        [FieldOffset(0x08)] public uint Index;
    }
}

[GenerateInterop]
[Inherits<Threading.Thread>]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public partial struct ActionTimelineThread;
