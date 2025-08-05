namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkTimerHolder {
    /// <remarks> Microseconds since game start, used to update AtkTimers. </remarks>
    [FieldOffset(0x0)] public ulong MicrosecondsTimer;
    [FieldOffset(0x8)] public StdVector<AtkTimer> AtkTimers;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? ?? ?? ?? 48 89 43 ?? C6 43 ?? ?? EB")]
    public partial bool RegisterTimer(AtkTimer* timer);
}
