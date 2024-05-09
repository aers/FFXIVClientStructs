namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct AtkTimerHolder {
    /// <remarks> Microseconds since game start, used to update AtkTimers. </remarks>
    [FieldOffset(0x0)] public ulong MicrosecondsTimer;
    [FieldOffset(0x8)] public StdVector<AtkTimer> AtkTimers;
}
