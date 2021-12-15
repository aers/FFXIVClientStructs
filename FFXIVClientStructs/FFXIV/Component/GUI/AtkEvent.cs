using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // max known: 79
    // seems to have generic events followed by component-specific events
    public enum AtkEventType
    {   
        MouseDown = 3,
        MouseUp = 4,
        MouseMove = 5,
        MouseOver = 6,                  
        MouseOut = 7,
        MouseClick = 9,                  
        InputReceived = 12,
        // AtkComponentButt on & children
        ButtonPress = 23,                // sent on MouseDown on button
        ButtonRelease = 24,              // sent on MouseUp and MouseOut
        ButtonClick = 25,                // sent on MouseUp and MouseClick on button     
        // AtkComponentDragDrop 
        DragDropRollOver = 52,
        DragDropRollOut = 53,
        DragDropUnk54 = 54,
        DragDropUnk55 = 55,
        // AtkComponentIconText
        IconTextRollOver = 56,           
        IconTextRollOut = 57,
        IconTextClick = 58
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