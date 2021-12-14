using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // there's 70+ of these
    public enum AtkEventType
    {   
        MouseDown = 3,
        MouseUp = 4,
        MouseMove = 5,
        MouseOver = 6,                   // used for changing the cursor state when you mouseover stuff
        MouseOut = 7,
        InputReceived = 12,
        StateChanged = 25,               // sent by AtkButtonComponent (and others?) when button state changes
    }
    
    [StructLayout(LayoutKind.Explicit, Size=0x30)]
    public unsafe partial struct AtkEvent
    {
        [FieldOffset(0x0)] public AtkResNode* Node; // extra node param, unused a lot
        [FieldOffset(0x8)] public AtkEventTarget* Target; // target of event (eg clicking a button, target is the button node)
        [FieldOffset(0x10)] public AtkEventListener* Listener; // listener of event
        [FieldOffset(0x18)] public uint Param; // arg3 of ReceiveEvent
        [FieldOffset(0x20)] public AtkEvent* NextEvent;
        [FieldOffset(0x28)] public byte Type;
        [FieldOffset(0x29)] public byte Unk29;
        [FieldOffset(0x30)] public byte Flags; // 0: handled, 5: force handled (see AtkEvent::SetEventIsHandled)
    }
}