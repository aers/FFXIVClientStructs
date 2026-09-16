using FFXIVClientStructs.FFXIV.Client.System.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::PadDeviceInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct PadDeviceInterface {
    [VirtualFunction(0)]
    public partial PadDeviceInterface* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial bool Initialize(SystemConfig* systemConfig, bool a3);

    [VirtualFunction(2)]
    public partial void Update();

    [VirtualFunction(2), Obsolete("Use Update")]
    public partial nint Poll();

    [VirtualFunction(3)]
    public partial void Deinitialize();

    [VirtualFunction(5)]
    public partial GamepadInputData* GetData();

    /// <summary>
    /// Sets the vibration levels.
    /// </summary>
    /// <param name="rightMotorSpeed">Speed of the right motor in percent (0 - 100).</param>
    /// <param name="leftMotorSpeed">Speed of the left motor in percent (0 - 100).</param>
    [VirtualFunction(13)]
    public partial void SetVibration(int rightMotorSpeed, int leftMotorSpeed);
}
