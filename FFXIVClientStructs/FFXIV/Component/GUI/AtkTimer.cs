namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkTimer
//   Component::GUI::AtkEventTarget
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AtkTimer {
    [FieldOffset(0x00)] public AtkEventTarget EventTarget;

    /// <summary> Indicates the time at which the timer ends. </summary>
    [FieldOffset(0x10)] public uint EndTime;
    /// <summary> Indicates the time elapsed since the timer started. </summary>
    [FieldOffset(0x14)] public uint ElapsedTime;
    /// <summary> Indicates the duration between each timer tick. </summary>
    [FieldOffset(0x18)] public ulong IntervalDuration;
    [FieldOffset(0x20)] public ulong CurrentTime;
    /// <summary> Indicates whether the timer is currently active or not. </summary>
    /// <returns> <c>false</c> when EntTime is reached, <c>true</c> otherwise. </returns>
    [FieldOffset(0x28)] public bool IsActive;
}
