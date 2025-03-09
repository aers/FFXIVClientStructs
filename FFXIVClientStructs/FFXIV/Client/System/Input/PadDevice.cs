namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::PadDevice
//   Client::System::Input::PadDeviceInterface
//   Client::System::Input::InputDevice
//   Client::System::Input::RepeatCounter
[GenerateInterop]
[Inherits<PadDeviceInterface>, Inherits<InputDevice>, Inherits<RepeatCounter>]
[StructLayout(LayoutKind.Explicit, Size = 0x4F00)]
public unsafe partial struct PadDevice {
    [FieldOffset(0x78)] public GamepadInputData GamepadInputData;
}
