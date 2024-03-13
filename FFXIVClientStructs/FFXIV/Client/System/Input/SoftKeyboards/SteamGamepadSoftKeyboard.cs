using System.Collections;

namespace FFXIVClientStructs.FFXIV.Client.System.Input.SoftKeyboards;

// ctor called from AtkModule.ctor, but cannot be sanely sigged.
// likewise, no sane sigs for StaticVTable
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct SteamGamepadSoftKeyboard {
    [FieldOffset(0x00)] public SoftKeyboardDeviceInterface SoftKeyboardDeviceInterface;

    [FieldOffset(0x08)] public byte Enabled;
    [FieldOffset(0x10)] public SoftKeyboardDeviceInterface.SoftKeyboardInputInterface* TargetInputInterface;
}
