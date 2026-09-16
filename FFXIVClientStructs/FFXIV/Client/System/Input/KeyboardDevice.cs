using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::KeyboardDevice
//   Client::System::Input::KeyboardDeviceInterface
//   Client::System::Input::RepeatCounter
[GenerateInterop]
[Inherits<KeyboardDeviceInterface>, Inherits<RepeatCounter>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct KeyboardDevice {
    [FieldOffset(0x28)] public GameWindow* GameWindow;
    [FieldOffset(0x30)] public bool IsKeyboardConnected;
    [FieldOffset(0x38)] private Threading.Thread* UnkThread;

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 56 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 4D 8B F9")]
    public static partial void ProcessKeyboardInputMessage(nint hWnd, uint uMsg, nint wParam, nint lParam);
}
