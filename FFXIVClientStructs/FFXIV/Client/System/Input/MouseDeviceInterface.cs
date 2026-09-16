namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::MouseDeviceInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct MouseDeviceInterface {
    [VirtualFunction(0)]
    public partial MouseDeviceInterface* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial bool Initialize();

    [VirtualFunction(2)]
    public partial void Update(float dt);

    [VirtualFunction(3)]
    public partial void Deinitialize();

    [VirtualFunction(4)]
    public partial CursorInputData* GetData();

    /// <summary>
    /// Resets pressed and released mouse button state, as well as mouse wheel state.
    /// </summary>
    [VirtualFunction(5)]
    public partial void ResetState();

    [VirtualFunction(6)]
    public partial void SetAcquired(bool acquired);
}
