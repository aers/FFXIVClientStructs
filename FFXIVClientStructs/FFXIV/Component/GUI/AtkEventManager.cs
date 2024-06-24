namespace FFXIVClientStructs.FFXIV.Component.GUI;

// not entirely sure this class exists
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventManager {
    [FieldOffset(0x0)] public AtkEvent* Event; // linked list of events using AtkEvent->NextEvent

    [MemberFunction("E8 ?? ?? ?? ?? F6 45 0C 20 75 22")]
    public partial void RegisterEvent(AtkEventType eventType, uint eventParam, AtkResNode* nodeParam, AtkEventTarget* target, AtkEventListener* listener, bool systemEvent);

    [MemberFunction("E8 ?? ?? ?? ?? F6 43 0C 20")]
    public partial void UnregisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, bool systemEvent);
}
