namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ActionTimelineManager {
    [StaticAddress("4C 8B 43 48 48 8B 0D ?? ?? ?? ??", 7)]
    public static partial ActionTimelineManager* Instance();

    [MemberFunction("48 83 EC 38 48 8B 02 C7 44 24")]
    public partial bool PreloadActionTmbByKey(byte** key);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C6 48 89 45 A7")]
    public static partial byte* GetActionTimelineKey(uint actionTimelineRowId);
}
