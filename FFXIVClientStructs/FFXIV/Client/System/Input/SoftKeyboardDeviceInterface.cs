using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::SoftKeyboardDeviceInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct SoftKeyboardDeviceInterface {
    [VirtualFunction(0)]
    public partial void Dtor(bool freeMemory);

    [VirtualFunction(1)]
    public partial bool Enable();

    [VirtualFunction(2)]
    public partial void DumpInput(); // called from Component::GUI::AtkModule_HandleInput

    [VirtualFunction(3)]
    public partial void Disable();

    [VirtualFunction(4)]
    public partial bool IsEnabled();

    [VirtualFunction(5)]
    public partial bool OpenSoftKeyboard(SoftKeyboardInputInterface* targetInterface);

    [VirtualFunction(6)]
    public partial void CloseSoftKeyboard(); // called from AtkComponentTextInput#vf4 and AtkComponentTextInput#Finalize

    [VirtualFunction(7)]
    public partial bool IsSoftKeyboardOpen();

    // Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface
    [GenerateInterop(true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct SoftKeyboardInputInterface {
        // CAUTION: May be the concrete class' dtor!
        [VirtualFunction(0)]
        public partial void Dtor(bool freeMemory);

        [VirtualFunction(2)]
        public partial void WriteString(Utf8String* stringToWrite);

        [VirtualFunction(4)]
        public partial uint GetInputMaxLength();
    }
}
