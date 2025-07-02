namespace FFXIVClientStructs.FFXIV.Component.GUI;

// not entirely sure this class exists
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventManager {
    [FieldOffset(0x0)] public AtkEvent* Event; // linked list of events using AtkEvent->NextEvent

    [MemberFunction("E8 ?? ?? ?? ?? F6 45 0C 20 75 22")]
    public partial AtkEvent* RegisterEvent(AtkEventType eventType, uint eventParam, AtkResNode* nodeParam, AtkEventTarget* target, AtkEventListener* listener, bool isGlobalEvent);

    [MemberFunction("E8 ?? ?? ?? ?? F6 43 0C 20")]
    public partial bool UnregisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, bool isGlobalEvent);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 89 3B 48 85 F6")]
    public partial void ClearEvents();
}
