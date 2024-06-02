namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler;

// Client::System::Scheduler::ActionTimelineManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ActionTimelineManager {
    [StaticAddress("4C 8B 43 48 48 8B 0D ?? ?? ?? ??", 7)]
    public static partial ActionTimelineManager* Instance();

    [MemberFunction("48 83 EC 38 48 8B 02 C7 44 24")]
    public partial bool PreloadActionTmb(PreloadActionTmbInfo* info);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct PreloadActionTmbInfo {
        [FieldOffset(0x00)] public byte* Key;

        // ActionTimeline Row Index
        // or
        // WeaponTimeline Row Index + 0x20000
        [FieldOffset(0x08)] public uint Index;
    }
}
