using FFXIVClientStructs.FFXIV.Client.System.Configuration;
using FFXIVClientStructs.Interop.DirectInput;
using FFXIVClientStructs.Interop.XInput;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::PadDevice
//   Client::System::Input::PadDeviceInterface
//   Client::System::Input::InputDevice
//   Client::System::Input::RepeatCounter
[GenerateInterop]
[Inherits<PadDeviceInterface>, Inherits<InputDevice>, Inherits<RepeatCounter>]
[StructLayout(LayoutKind.Explicit, Size = 0x4F88)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 7E ?? 48 89 06 48 8D 4E", 3, 27)]
public unsafe partial struct PadDevice {
    [FieldOffset(0x48)] public StdVector<GamepadDevice> GamepadDevices;
    [FieldOffset(0x60)] private StdVector<GamepadDevice> GamepadDevices2;
    [FieldOffset(0x78)] public GamepadInputData GamepadInputData;
    [FieldOffset(0x2C4)] public PadSettings Settings;
    [FieldOffset(0x438)] public SystemConfig* SystemConfig;
    [FieldOffset(0x440)] public int ActiveGamepadDeviceIndex;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x868)]
    public partial struct GamepadDevice {
        [FieldOffset(0x00)] public bool IsPollingRequired; // DIDC_POLLEDDEVICE | DIDC_POLLEDDATAFORMAT
        [FieldOffset(0x01)] public bool UseDefaultInputMapping;
        [FieldOffset(0x02), FixedSizeArray] internal FixedSizeArray32<bool> _buttons;
        [FieldOffset(0x24)] public uint Index; // XInput dwUserIndex
        [FieldOffset(0x28)] public int NumberOfAxes; // DIEFFECT.cAxes
        // 100 (float?) values here
        [FieldOffset(0x19C)] public AxisAspects LX;
        [FieldOffset(0x1AC)] public AxisAspects LY;
        [FieldOffset(0x1BC)] public AxisAspects LZ;
        [FieldOffset(0x1CC)] public AxisAspects RX;
        [FieldOffset(0x1DC)] public AxisAspects RY;
        [FieldOffset(0x1EC)] public AxisAspects RZ;
        [FieldOffset(0x1FC)] public AxisAspects Slider;
        [FieldOffset(0x20C)] public float DPadX;
        [FieldOffset(0x210)] public float DPadY;
        [FieldOffset(0x214), CExporterTypeForce("XINPUT_STATE", true)] public XInputState XInputState;
        [FieldOffset(0x224)] public AxisCalibration LXCalibration;
        [FieldOffset(0x254)] public AxisCalibration LYCalibration;
        [FieldOffset(0x284)] public AxisCalibration LZCalibration;
        [FieldOffset(0x2B4)] public AxisCalibration RXCalibration;
        [FieldOffset(0x2E4)] public AxisCalibration RYCalibration;
        [FieldOffset(0x314)] public AxisCalibration RZCalibration;
        [FieldOffset(0x344)] public AxisCalibration SliderCalibration;
        [FieldOffset(0x374), CExporterTypeForce("DIDEVCAPS", true)] public DIDeviceCapabilities Capabilities; // from IDirectInputDevice8->GetCapabilities
        [FieldOffset(0x3A0), CExporterTypeForce("DIDEVICEINSTANCEA", true)] public DIDeviceInstance DeviceInfo; // from IDirectInputDevice8->GetDeviceInfo

        [FieldOffset(0x810), CExporterTypeForce("LPDIRECTINPUTDEVICE8A", true)] public nint DirectInputDevice;
        [FieldOffset(0x818), CExporterTypeForce("LPDIRECTINPUTEFFECT", true)] public nint DirectInputEffect;
        [FieldOffset(0x820)] public float DeadZone;
        [FieldOffset(0x824)] public bool PovInputDisabled;
        [FieldOffset(0x825), FixedSizeArray] internal FixedSizeArray24<byte> _alias; // device-specific input mapping
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct AxisAspects {
        [FieldOffset(0x00)] public float Position; // DIDOI_ASPECTPOSITION
        [FieldOffset(0x04)] public float Velocity; // DIDOI_ASPECTVELOCITY
        [FieldOffset(0x08)] public float Acceleration; // DIDOI_ASPECTACCEL
        [FieldOffset(0x0C)] public float Force; // DIDOI_ASPECTFORCE
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct AxisCalibration {
        [FieldOffset(0x00)] public AxisAspectCalibration Position;
        [FieldOffset(0x0C)] public AxisAspectCalibration Velocity;
        [FieldOffset(0x18)] public AxisAspectCalibration Acceleration;
        [FieldOffset(0x24)] public AxisAspectCalibration Force;

        [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
        public struct AxisAspectCalibration {
            [FieldOffset(0x00)] public float Offset;
            [FieldOffset(0x08)] public float Sensitivity;
        }
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x174)]
    public partial struct PadSettings {
        [FieldOffset(0x00)] public uint PadGuid;
        [FieldOffset(0x04), CExporterTypeForce("GUID", true)] public Guid InstanceGuid;
        [FieldOffset(0x14), CExporterTypeForce("GUID", true)] public Guid ProductGuid;
        [FieldOffset(0x24), CExporterTypeForce("GUID", true)] public Guid ActiveInstanceGuid;
        [FieldOffset(0x34), CExporterTypeForce("GUID", true)] public Guid ActiveProductGuid;
        [FieldOffset(0x44)] public uint AlwaysInput;
        [FieldOffset(0x48)] public float DeadArea;
        [FieldOffset(0x4C), FixedSizeArray] internal FixedSizeArray24<byte> _alias; // device-specific input mapping
        [FieldOffset(0x64)] public int ForceFeedBack;

        [FieldOffset(0x168)] public bool PovInputDisabled;
        [FieldOffset(0x169)] public bool PadAvailable;
    }
}
