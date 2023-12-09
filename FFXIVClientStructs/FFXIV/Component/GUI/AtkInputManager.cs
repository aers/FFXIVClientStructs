namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct AtkInputManager {
    [FieldOffset(0)] public AtkTextInput* TextInput;
}
