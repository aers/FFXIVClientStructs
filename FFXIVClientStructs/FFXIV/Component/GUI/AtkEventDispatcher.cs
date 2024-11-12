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
        // AtkEventState.UnkFlags1 are saved in this field (as uint), whenever AtkEventStateFlags.Unk4 is set.
        [FieldOffset(0x4)] public uint UnkFlags;
        [FieldOffset(0x8)] public AtkEventData EventData;
    }
}
