namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::MouseDevice
//   Client::System::Input::MouseDeviceInterface
//   Client::System::Input::RepeatCounter
//     Client::System::Input::InputDevice
//       Client::System::Common::NonCopyable
//   Client::System::Input::InputDevice
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<MouseDeviceInterface>, Inherits<RepeatCounter>, Inherits<InputDevice>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public partial struct MouseDevice {
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 49 8B D8 C6 05")]
    public static partial void ProcessMouseInputMessage(nint hWnd, uint uMsg, nint wParam);

    /// <remarks>
    /// Schedules the cursor to move to the specified coordinates on the next mouse device update.
    /// </remarks>
    [MemberFunction("89 0D ?? ?? ?? ?? 89 15 ?? ?? ?? ?? C6 05 ?? ?? ?? ?? 01 C3")]
    public static partial void ScheduleCursorMove(int x, int y);
}
