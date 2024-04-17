namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct AtkInputManager {
    [FieldOffset(0)] public AtkTextInput* TextInput;
}
