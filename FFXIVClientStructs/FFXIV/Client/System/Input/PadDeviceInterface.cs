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

    [VirtualFunction(4)]
    public partial int GetNumberOfDevices();

    [VirtualFunction(5)]
    public partial GamepadInputData* GetData();

    [VirtualFunction(6)]
    public partial void SetActiveDevice(int deviceIndex);

    [VirtualFunction(7)]
    public partial int GetActiveDeviceIndex();

    [VirtualFunction(8)]
    public partial void ApplyForceFeedback();

    [VirtualFunction(9)]
    public partial void ApplySettings();

    [VirtualFunction(10)]
    public partial void LoadInputMapping();

    [VirtualFunction(11)]
    public partial void ResetInputMapping();

    [VirtualFunction(12)]
    public partial void ClearPadData();

    /// <summary>
    /// Sets the vibration levels.
    /// </summary>
    /// <param name="rightMotorSpeed">Speed of the right motor in percent (0 - 100).</param>
    /// <param name="leftMotorSpeed">Speed of the left motor in percent (0 - 100).</param>
    [VirtualFunction(13)]
    public partial void SetVibration(int rightMotorSpeed, int leftMotorSpeed);

    [VirtualFunction(14)]
    public partial void SetPovInputDisabled(bool disabled);

    [VirtualFunction(15)]
    public partial bool GetPovInputDisabled();

    // [VirtualFunction(16)]
    // public partial void Vf16(nint a2, nint a3);

    // [VirtualFunction(17)]
    // public partial nint Vf17(nint a2);

    // [VirtualFunction(18)]
    // public partial bool Vf18();

    // [VirtualFunction(19)]
    // public partial void Vf19();

    // [VirtualFunction(20)]
    // public partial bool Vf20(nint a2);

    // [VirtualFunction(21)]
    // public partial bool Vf21(nint a2);

    // [VirtualFunction(22)]
    // public partial bool Vf22(nint a2);

    // [VirtualFunction(23)]
    // public partial bool Vf23(byte a2, byte a3, byte a4);

    // [VirtualFunction(24)]
    // public partial bool Vf23(int a2);

    [VirtualFunction(25)]
    public partial bool IsDualSense();

    [VirtualFunction(26)]
    public partial bool IsDualShock4();
}
