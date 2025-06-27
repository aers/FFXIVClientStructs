using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkTimer
//   Component::GUI::AtkEventTarget
[GenerateInterop]
[Inherits<AtkEventTarget>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkTimer : ICreatable {
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

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 46 78")]
    public partial void Ctor();

    [MemberFunction("40 55 56 48 83 EC 28 8B EA 48 8B F1 F6 C2 02 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 7C 24 ?? 48 8B 79 F8 4C 89 74 24")]
    public partial AtkTimer* Dtor(byte freeFlags);

    [MemberFunction("E9 ?? ?? ?? ?? 83 FA 01 75 30")]
    public partial void Start(bool fireTimerStartEvent = false);
}
