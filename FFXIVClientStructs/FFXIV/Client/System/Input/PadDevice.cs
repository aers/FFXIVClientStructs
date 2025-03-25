namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::PadDevice
//   Client::System::Input::PadDeviceInterface
//   Client::System::Input::InputDevice
//   Client::System::Input::RepeatCounter
[GenerateInterop]
[Inherits<PadDeviceInterface>, Inherits<InputDevice>, Inherits<RepeatCounter>]
[StructLayout(LayoutKind.Explicit, Size = 0x4F88)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 7E ?? 48 89 06 48 8D 4E", 3)]
public unsafe partial struct PadDevice {
    [FieldOffset(0x78)] public GamepadInputData GamepadInputData;
}
