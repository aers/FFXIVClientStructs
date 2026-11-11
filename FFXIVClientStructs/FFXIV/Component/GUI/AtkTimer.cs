using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkTimer
//   Component::GUI::AtkEventTarget
[GenerateInterop]
[Inherits<AtkEventTarget>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? C6 41 ?? ?? ?? ?? ?? 33 C0 48 89 41 ?? 89 41 ?? 48 89 41", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkTimer : ICreatable<AtkTimer> {
    [FieldOffset(0x08)] public AtkEventManager EventManager;
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

    [VirtualFunction(1)]
    public partial AtkTimer* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 46 78")]
    public partial AtkTimer* Ctor();

    [MemberFunction("E9 ?? ?? ?? ?? 83 FA 01 75 30")]
    public partial void Start(bool fireTimerStartEvent = false);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 4D 8B FC")]
    public partial AtkEvent* RegisterEvent(AtkEventType eventType, uint param, AtkEventListener* listener, AtkResNode* node);
}
