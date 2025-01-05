namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::VibrationControl
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public struct VibrationControl {
    [FieldOffset(0x11C)] public bool IsVibrating;
}
