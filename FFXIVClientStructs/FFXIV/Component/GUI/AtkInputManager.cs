namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18A0)]
public unsafe partial struct AtkInputManager {
    [FieldOffset(0)] public AtkTextInput* TextInput;

    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray256<FocusEntry> _focusList;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct FocusEntry {
        [FieldOffset(0x0)] public AtkEventListener* AtkEventListener;
        [FieldOffset(0x8)] public AtkEventTarget* AtkEventTarget;
        [FieldOffset(0x10)] public int Unk10;
    }
}
