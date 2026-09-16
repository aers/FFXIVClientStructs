namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::KeyboardDeviceInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct KeyboardDeviceInterface {
    [VirtualFunction(0)]
    public partial KeyboardDeviceInterface* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial bool Initialize();

    [VirtualFunction(2)]
    public partial void Update(float dt);

    [VirtualFunction(3)]
    public partial void Deinitialize();

    [VirtualFunction(4)]
    public partial KeyboardInputData* GetData();

    [VirtualFunction(5)]
    public partial void ResetState(bool clearDown);

    [VirtualFunction(6)]
    public partial void SendKey(SeVirtualKey key);

    [VirtualFunction(7)]
    public partial bool GetIsKeyboardConnected();
}
