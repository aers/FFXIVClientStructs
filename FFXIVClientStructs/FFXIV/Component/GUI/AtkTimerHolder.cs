namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkTimerHolder {
    /// <remarks> Microseconds since game start, used to update AtkTimers. </remarks>
    [FieldOffset(0x0)] public ulong MicrosecondsTimer;
    [FieldOffset(0x8)] public StdVector<AtkTimer> AtkTimers;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 46 18 48 03 03")]
    public partial bool RegisterTimer(AtkTimer* timer);
}
