namespace FFXIVClientStructs.FFXIV.Client.System.Input;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct SoftKeyboardDevice {
    [FieldOffset(0x00), CExportIgnore] public void** vtbl;

    [VirtualFunction(0)] 
    public partial void Dtor(bool freeMemory);
    
    [VirtualFunction(1)]
    public partial bool Enable();
    
    [VirtualFunction(2)]
    public partial void DumpInput();
    
    [VirtualFunction(3)]
    public partial nint Disable();

    [VirtualFunction(4)]
    public partial nint IsEnabled();

    [VirtualFunction(5)]
    public partial nint OpenSoftKeyboard(SoftKeyboardDeviceInterface.SoftKeyboardInputInterface* targetInterface);

    [VirtualFunction(6)]
    public partial void CloseSoftKeyboard(); // called from AtkComponentTextInput#vf4 and AtkComponentTextInput#Finalize

    [VirtualFunction(7)]
    public partial void IsSoftKeyboardOpen();
}
