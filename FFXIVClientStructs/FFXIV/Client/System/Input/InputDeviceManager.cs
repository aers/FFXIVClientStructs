namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::InputDeviceManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct InputDeviceManager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? 48 85 C9 74 23 48 8B 49 08", 3, isPointer: true)]
    public static partial InputDeviceManager* Instance();

    [FieldOffset(0x00)] public PadDevice* PadDevice;
    [FieldOffset(0x08)] public MouseDevice* MouseDevice;
    [FieldOffset(0x10)] public KeyboardDevice* KeyboardDevice;

    [FieldOffset(0x20)] public VibrationControl* VibrationControl;
}
