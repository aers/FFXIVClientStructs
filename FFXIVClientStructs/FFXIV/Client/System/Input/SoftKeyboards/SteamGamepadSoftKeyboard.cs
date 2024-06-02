namespace FFXIVClientStructs.FFXIV.Client.System.Input.SoftKeyboards;

// Client::System::Input::SoftKeyboards::SteamGamepadSoftKeyboard
//   Client::System::Input::SoftKeyboardDeviceInterface
// ctor called from AtkModule.ctor, but cannot be sanely sigged.
// likewise, no sane sigs for StaticVTable
[GenerateInterop]
[Inherits<SoftKeyboardDeviceInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct SteamGamepadSoftKeyboard {
    [FieldOffset(0x08)] public byte Enabled;
    [FieldOffset(0x10)] public SoftKeyboardDeviceInterface.SoftKeyboardInputInterface* TargetInputInterface;
}
