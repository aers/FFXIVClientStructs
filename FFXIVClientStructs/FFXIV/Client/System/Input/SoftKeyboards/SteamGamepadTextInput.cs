namespace FFXIVClientStructs.FFXIV.Client.System.Input.SoftKeyboards;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct SteamGamepadTextInput {
    [FieldOffset(0x00)] public SoftKeyboardDevice* PlatformInputMethod;

    [FieldOffset(0x08)] public byte Enabled;
    [FieldOffset(0x10)] public void* TargetSoftKeyboardInputInterface; // populated as part of 140577A90
}
