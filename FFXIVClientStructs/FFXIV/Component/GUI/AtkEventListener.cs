namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkEventListener
// no explicit constructor, just an event interface with 3 virtual functions
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventListener {
    [VirtualFunction(0)]
    public partial AtkEventListener* Dtor(byte freeFlags);

    // the "base class event handler"?! seems like it's never overwritten for any AtkUnitBase
    [VirtualFunction(1)]
    public partial void ReceiveGlobalEvent(AtkEventType eventType, int eventParam, AtkEvent* atkEvent, AtkEventData* atkEventData = null);

    [VirtualFunction(2)]
    public partial void ReceiveEvent(AtkEventType eventType, int eventParam, AtkEvent* atkEvent, AtkEventData* atkEventData = null);
}
