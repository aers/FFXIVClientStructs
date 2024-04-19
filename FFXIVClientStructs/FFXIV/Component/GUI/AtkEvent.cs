namespace FFXIVClientStructs.FFXIV.Component.GUI;

// max known: 79
// seems to have generic events followed by component-specific events
public enum AtkEventType : byte {
    MouseDown = 3,
    MouseUp = 4,
    MouseMove = 5,
    MouseOver = 6,
    MouseOut = 7,
    MouseClick = 9,
    InputReceived = 12,
    FocusStart = 18,
    FocusStop = 19,

    // AtkComponentButton & children
    ButtonPress = 23, // sent on MouseDown on button
    ButtonRelease = 24, // sent on MouseUp and MouseOut
    ButtonClick = 25, // sent on MouseUp and MouseClick on button     

    ListItemRollOver = 33,
    ListItemRollOut = 34,
    ListItemToggle = 35,

    // AtkComponentDragDrop 
    DragDropBegin = 47, // sent on MouseDown over a draggable icon (will NOT send for a locked icon)
    DragDropInsert = 50, // sent when dropping an icon into a hotbar/inventory slot or similar
    DragDropRollOver = 52,
    DragDropRollOut = 53,
    DragDropDiscard = 54, // sent when dropping an icon into empty screenspace, eg to remove an action from a hotbar
    DragDropCancel = 55, // sent on MouseUp if the cursor has not moved since DragDropBegin, OR on MouseDown over a locked icon

    [Obsolete("Use AtkEventType.DragDropDiscard instead")]
    DragDropUnk54 = 54,
    [Obsolete("Use AtkEventType.DragDropCancel instead")]
    DragDropUnk55 = 55,

    // AtkComponentIconText
    IconTextRollOver = 56,
    IconTextRollOut = 57,
    IconTextClick = 58,

    // AtkSimpleTween
    TweenProgress = 64,
    TweenComplete = 65,

    // AtkComponentWindow
    WindowRollOver = 67,
    WindowRollOut = 68,
    WindowChangeScale = 69,
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkEvent {
    [FieldOffset(0x0)] public AtkResNode* Node; // extra node param, unused a lot
    [FieldOffset(0x8)] public AtkEventTarget* Target; // target of event (eg clicking a button, target is the button node)
    [FieldOffset(0x10)] public AtkEventListener* Listener; // listener of event
    [FieldOffset(0x18)] public uint Param; // arg3 of ReceiveEvent
    [FieldOffset(0x20)] public AtkEvent* NextEvent;
    [FieldOffset(0x28)] public AtkEventType Type; // TODO: Change enum to uint
    [FieldOffset(0x29)] public byte Unk29;
    [FieldOffset(0x2A)] public byte Flags; // 0: handled, 5: force handled (see AtkEvent::SetEventIsHandled)

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 9C")]
    public partial void SetEventIsHandled(bool forced = false);
}
