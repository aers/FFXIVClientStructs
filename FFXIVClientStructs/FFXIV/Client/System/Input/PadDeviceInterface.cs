namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::PadDeviceInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct PadDeviceInterface {
    /// <summary>
    /// Sets the vibration levels.
    /// </summary>
    /// <param name="rightMotorSpeed">Speed of the right motor in percent (0 - 100).</param>
    /// <param name="leftMotorSpeed">Speed of the left motor in percent (0 - 100).</param>
    [VirtualFunction(13)]
    public partial void SetVibration(int rightMotorSpeed, int leftMotorSpeed);

    [VirtualFunction(2)]
    public partial nint Poll();
}
