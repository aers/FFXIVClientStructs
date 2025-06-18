namespace FFXIVClientStructs.FFXIV.Component.GUI;

// seems to have generic events followed by component-specific events
public enum AtkEventType : byte {
    // AtkResNode
    MouseDown = 3,
    MouseUp = 4,
    MouseMove = 5,
    MouseOver = 6,
    MouseOut = 7,
    MouseWheel = 8,
    MouseClick = 9,
    MouseDoubleClick = 10,

    InputReceived = 12,
    InputNavigation = 13, // for LEFT, RIGHT, UP, DOWN, TAB_NEXT, TAB_PREV, TAB_BOTH_NEXT, TAB_BOTH_PREV, PAGEUP, PAGEDOWN

    // AtkComponentTextInput and AtkComponentNumericInput
    InputBaseInputReceived = 15, // fired for moving the text cursor, deletion of a character and inserting a new line, etc.

    FocusStart = 18,
    FocusStop = 19,

    Resize = 21, // ChatLogPanel

    // AtkComponentButton & children
    ButtonPress = 23, // sent on MouseDown on button
    ButtonRelease = 24, // sent on MouseUp and MouseOut
    ButtonClick = 25, // sent on MouseUp and MouseClick on button

    ValueUpdate = 27, // NumericInput, ScrollBar, etc.

    // AtkComponentSlider
    SliderValueUpdate = 29,
    SliderReleased = 30,

    // AtkComponentList & children
    ListItemRollOver = 33,
    ListItemRollOut = 34,
    ListItemClick = 35,
    ListItemDoubleClick = 36,
    ListItemSelect = 38,

    // AtkComponentDragDrop
    DragDropBegin = 50, // sent on MouseDown over a draggable icon (will NOT send for a locked icon)
    DragDropEnd = 51,
    DragDropInsertAttempt = 52, // always fired before it checks whether or not it can actually accept the drop
    DragDropInsert = 53, // sent when dropping an icon into a hotbar/inventory slot or similar
    DragDropCanAcceptCheck = 54, // optional, allows conditional drop acceptance
    DragDropRollOver = 55,
    DragDropRollOut = 56,
    DragDropDiscard = 57, // sent when dropping an icon into empty screenspace, eg to remove an action from a hotbar
    DragDropCancel = 58, // sent on MouseUp if the cursor has not moved since DragDropBegin, OR on MouseDown over a locked icon

    // AtkComponentIconText
    IconTextRollOver = 59,
    IconTextRollOut = 60,
    IconTextClick = 61,

    // AtkDialogue
    DialogueClose = 62,
    DialogueSubmit = 63,

    // AtkTimer
    TimerTick = 64,
    TimerEnd = 65,

    // AtkSimpleTween
    TweenProgress = 67,
    TweenComplete = 68,

    // AtkAddonControl
    ChildAddonAttached = 69, // found inside AtkAddonControl_Update

    // AtkComponentWindow
    WindowRollOver = 70,
    WindowRollOut = 71,
    WindowChangeScale = 72,

    // AtkTextNode
    LinkMouseClick = 75,
    LinkMouseOver = 76,
    LinkMouseOut = 77,

    Unk83 = 83, // found inside AtkComponentScrollBar.Deinitialize, AtkComponentDragDrop.BeginDragDrop - "clicked on viewport" event?
}

// Component::GUI::AtkEvent
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkEvent {
    [FieldOffset(0x0)] public AtkResNode* Node; // extra node param, unused a lot
    [FieldOffset(0x8)] public AtkEventTarget* Target; // target of event (eg clicking a button, target is the button node)
    [FieldOffset(0x10)] public AtkEventListener* Listener; // listener of event
    [FieldOffset(0x18)] public uint Param; // arg3 of ReceiveEvent
    [FieldOffset(0x20)] public AtkEvent* NextEvent;
    [FieldOffset(0x28)] public AtkEventState State;

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 9C")]
    public partial void SetEventIsHandled(bool forced = false);
}

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct AtkEventState {
    [FieldOffset(0x0)] public AtkEventType EventType;
    // AtkInputManager_HandleInput reads these flags (at the very end) and writes them as 3 bools to AtkCollisionManager, which
    // are used in AtkModule_HandleInput to clear Gamepad inputs from UIInputData??
    [FieldOffset(0x1), Obsolete("Renamed to ReturnFlags")] public byte UnkFlags1;
    [FieldOffset(0x1)] public byte ReturnFlags;
    [FieldOffset(0x2)] public AtkEventStateFlags StateFlags;
    [FieldOffset(0x3)] public byte UnkFlags3; // for cleanup maybe?
}

[Flags]
public enum AtkEventStateFlags : byte {
    None = 0,

    Handled = 0b0000_0001, // set in SetEventIsHandled

    /// <summary>
    /// Specifies whether the event is dispatched again using another <see cref="AtkEventType"/>.
    /// </summary>
    Forwarded = 0b0000_0010,

    Unk3 = 0b0000_0100,

    /// <summary>
    /// Specifies whether <see cref="AtkEventState.ReturnFlags"/> is copied to <see cref="AtkEventDispatcher.Event.ReturnFlags"/>.
    /// </summary>
    HasReturnFlags = 0b0000_1000,
    [Obsolete("Renamed to HasReturnFlags")] Unk4 = 0b0000_1000,

    /// <summary>
    /// Specifies whether the event is a global event.<br/>
    /// When this is set, <see cref="AtkEventListener.ReceiveGlobalEvent(AtkEventType, int, AtkEvent*, AtkEventData*)"/> is called.
    /// </summary>
    IsGlobalEvent = 0b0001_0000,

    Unk6 = 0b0010_0000, // set in SetEventIsHandled, depending on a2. maybe prevents propagation/bubbling?
    Unk7 = 0b0100_0000,

    /// <summary>
    /// Specifies whether the <see cref="AtkEvent"/> should be freed.
    /// </summary>
    Completed = 0b1000_0000
}
