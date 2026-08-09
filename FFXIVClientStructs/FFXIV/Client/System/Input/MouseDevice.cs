namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::MouseDevice
//   Client::System::Input::MouseDeviceInterface
//   Client::System::Input::InputDevice
//   Client::System::Input::RepeatCounter
[GenerateInterop]
[Inherits<MouseDeviceInterface>, Inherits<InputDevice>, Inherits<RepeatCounter>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public partial struct MouseDevice {
    /// <remarks>
    /// Schedules the cursor to move to the specified coordinates on the next mouse device update.
    /// </remarks>
    [MemberFunction("89 0D ?? ?? ?? ?? 89 15 ?? ?? ?? ?? C6 05 ?? ?? ?? ?? 01 C3")]
    public static partial void ScheduleCursorMove(int x, int y);
}
