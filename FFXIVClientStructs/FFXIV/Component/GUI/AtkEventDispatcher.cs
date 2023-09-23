namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkEventDispatcher {
    [FieldOffset(0)] public AtkEventManager* AtkEventManager;
    [FieldOffset(0x8)] public StdVector<Pointer<AtkEvent>> Events;
    // [FieldOffset(0x20)] public byte Unk20;

    // [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 4C 8B 74 24")]
    // public partial void DispatchEvent(nint a2);

    // [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5B 20 41 B2 01")]
    // public partial void RemoveEvent(nint a2);
}
