namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkEventDispatcher
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkEventDispatcher {
    [FieldOffset(0)] public AtkEventManager* AtkEventManager;
    [FieldOffset(0x8)] public StdVector<Pointer<AtkEvent>> Events;
    [FieldOffset(0x20)] public byte Unk20;

    /// <returns>A bool indicating if the event was handled.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 74 24 ?? 0F B6 C8")]
    public partial bool DispatchEvent(Event* evt);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5B 20 41 B2 01")]
    public partial void RemoveEvent(AtkEvent* atkEvent);

    // Component::GUI::AtkEventDispatcher::Event
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct Event {
        [FieldOffset(0x0)] public AtkEventState State;
        [FieldOffset(0x4), Obsolete("Renamed to ReturnFlags")] public uint UnkFlags;
        /// <summary>
        /// <see cref="AtkEventState.ReturnFlags"/> is copied in this field (as uint, was byte), whenever <see cref="AtkEventState.StateFlags"/> is set to <see cref="AtkEventStateFlags.HasReturnFlags"/>.<br/>
        /// Usage depends on AtkEventType and the call site that dispatched the event.
        /// </summary>
        [FieldOffset(0x4)] public uint ReturnFlags;
        [FieldOffset(0x8)] public AtkEventData EventData;
    }
}
