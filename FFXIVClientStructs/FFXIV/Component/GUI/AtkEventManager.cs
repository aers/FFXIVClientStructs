namespace FFXIVClientStructs.FFXIV.Component.GUI;

// not entirely sure this class exists
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventManager {
    [FieldOffset(0x0)] public AtkEvent* Event; // linked list of events using AtkEvent->NextEvent

    [MemberFunction("E8 ?? ?? ?? ?? 44 88 BF")]
    public partial void RegisterEvent(AtkEventType eventType, uint eventParam, AtkResNode* nodeParam, AtkEventTarget* target, AtkEventListener* listener, bool systemEvent);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC ?? 48 8B 05 ?? ?? ?? ?? 45 32 D2")]
    public partial void UnregisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, bool systemEvent);
}
