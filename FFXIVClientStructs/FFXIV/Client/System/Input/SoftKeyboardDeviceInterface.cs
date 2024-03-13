namespace FFXIVClientStructs.FFXIV.Client.System.Input;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct SoftKeyboardDeviceInterface {
    [FieldOffset(0x00), CExportIgnore] public void** vtbl;

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
}
