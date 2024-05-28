namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkEventListener
// no explicit constructor, just an event interface with 3 virtual functions
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventListener {
    [VirtualFunction(0)]
    public partial void Dtor(byte flags);
    
    [VirtualFunction(1)]
    public partial void ReceiveGlobalEvent(AtkEventType eventType, int eventParam, AtkEvent* atkEvent, nint atkEventData = 0);
    
    [VirtualFunction(2)]
    public partial void ReceiveEvent(AtkEventType eventType, int eventParam, AtkEvent* atkEvent, nint atkEventData = 0);
}
